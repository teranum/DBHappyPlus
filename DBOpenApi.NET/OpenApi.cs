using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DBOpenApi.NET;

/// <summary>
/// DB증권 OpenApi
/// </summary>
public class OpenApi : IOpenApi
{
    private readonly HttpClient _httpClient;
    private ClientWebSocket? _wssClient;
    private string _authorization = string.Empty;
    private string _macAddress = string.Empty;
    private long _expires_in;
    private readonly JsonSerializerOptions _jsonOptions;

    /// <inheritdoc cref="IOpenApi.OnMessageEvent"/>
    public event EventHandler<MessageEventArgs>? OnMessageEvent;

    /// <inheritdoc cref="IOpenApi.OnRealtimeEvent"/>
    public event EventHandler<RealtimeEventArgs>? OnRealtimeEvent;

    /// <summary>생성자</summary>
    public OpenApi()
    {
        _jsonOptions = new()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
        };

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(LibConst.BaseUrl),
        };
    }

    /// <inheritdoc cref="IOpenApi.IsSimulation"/>
    public bool IsSimulation { get; private set; }

    /// <inheritdoc cref="IOpenApi.Connected"/>
    public bool Connected { get; private set; }

    /// <inheritdoc cref="IOpenApi.AccessToken"/>
    public string AccessToken => _authorization;

    /// <inheritdoc cref="IOpenApi.LastErrorMessage"/>
    public string LastErrorMessage { get; private set; } = string.Empty;

    /// <inheritdoc cref="IOpenApi.MacAddress"/>
    public string MacAddress
    {
        get => _macAddress;
        set => _macAddress = value;
    }

    /// <inheritdoc cref="IOpenApi.Expires"/>
    public long Expires => _expires_in;

    /// <inheritdoc cref="IOpenApi.ConnectAsync"/>/>
    public async Task<bool> ConnectAsync(string appKey, string appSecretKey, string access_token = "", string wss_domain = "")
    {
        if (Connected)
        {
            LastErrorMessage = "Aleady connected";
            return true;
        }
        LastErrorMessage = string.Empty;

        if (!string.IsNullOrEmpty(access_token))
        {
            _authorization = access_token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorization);
        }
        else
        {
            // OAuth 인증키 가져오기
            OAuth? oAuth = await PostUrlEncodedAsync<OAuth>("/oauth2/token",
                [
                    new("grant_type", "client_credentials"),
                    new("appkey", appKey),
                    new("appsecretkey", appSecretKey),
                    new("scope", "oob"),
                ]);

            if (oAuth == null)
            {
                LastErrorMessage = $"인증키 가져오기 실패: {LastErrorMessage}";
                return false;
            }
            // 인증성공
            _authorization = oAuth.access_token;
            _expires_in = oAuth.expires_in;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(oAuth.token_type, _authorization);
        }

        // 모의투자인지 실투자인지 구분한다
        var request = new Dictionary<string, object?>()
        {
            { "IsuNo", "" },
            { "BnsDt", "" },
        };
        var response = await RequestTrAsync("FOCCQ10800", request);
        if (response == null)
        {
            // 요청 실패
            LastErrorMessage = "더미 요청 실패";
            return false;
        }

        IsSimulation = response.rsp_msg.Contains("모의투자");

        // 실시간 웹소켓 연결
        if (string.IsNullOrEmpty(wss_domain))
        {
            wss_domain = IsSimulation ? LibConst.WssUrlSimulation : LibConst.WssUrlReal;
        }
        Uri wssUri = new(wss_domain + "/websocket");

        try
        {
            _wssClient = new ClientWebSocket();
            if (_wssClient.ConnectAsync(wssUri, CancellationToken.None).Wait(5000))
            {
                Connected = true;
                _ = WebsocketListen(_wssClient);
                OnMessageEvent?.Invoke(this, new($"Websocket: Connected.({wssUri})"));

                // 더미 웹소켓 요청
                _ = await RequestRealtimeAsync("9999", "9999", true);
                return true;
            }
        }
        catch (Exception)
        {
            _wssClient = null;
            LastErrorMessage = "Websocket서버 연결 응답 없습니다";
            return false;
        }

        return false;
    }

    /// <inheritdoc cref="IOpenApi.CloseAsync"/>
    public async Task CloseAsync()
    {
        if (Connected)
        {
            if (_wssClient is not null && _wssClient.State == WebSocketState.Open)
                await _wssClient.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            Connected = false;
        }
    }

    private async Task WebsocketListen(ClientWebSocket webSocket)
    {
        ArraySegment<byte> buffer = new(new byte[1024]);
        while (webSocket.State == WebSocketState.Open)
        {
            using var ms = new MemoryStream();
            WebSocketReceiveResult? result;
            do
            {
                result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    OnWssClosed($"Websocket: Closed.({result.CloseStatusDescription ?? string.Empty})");
                    return;
                }

                await ms.WriteAsync(buffer.AsMemory(0, result.Count), CancellationToken.None);
            }
            while (!result.EndOfMessage);

            ms.Seek(0, SeekOrigin.Begin);

            if (result.MessageType == WebSocketMessageType.Text)
            {
                using var reader = new StreamReader(ms, Encoding.UTF8);
                OnWssReceive(await reader.ReadToEndAsync());
            }
        }
    }
    private void OnWssClosed(string message)
    {
        if (Connected)
        {
            //Connected = false;
            LastErrorMessage = message;
            OnMessageEvent?.Invoke(this, new(LastErrorMessage));
        }
    }
    private void OnWssReceive(string stringData)
    {
        try
        {
            RealtimeResponseModel? response = JsonSerializer.Deserialize<RealtimeResponseModel>(stringData);
            if (response != null && response.header != null)
            {
                if (response.header.tr_cd.Equals("9999"))
                {
                    // 더미 응답
                    return;
                }
                if (!string.IsNullOrEmpty(response.header.rsp_msg))
                {
                    OnMessageEvent?.Invoke(this, new($"{response.header.tr_cd}({response.header.tr_type}) : {response.header.rsp_msg}"));
                }

                if (response.body is JsonElement jsonElement)
                {
                    OnRealtimeEvent?.Invoke(this, new(response.header.tr_cd, response.header.tr_key, jsonElement));
                }
            }
        }
        catch (Exception ex)
        {
            LastErrorMessage = ex.Message;
            OnMessageEvent?.Invoke(this, new(ex.Message));
        }
    }

    private async Task<T?> PostUrlEncodedAsync<T>(string path, IEnumerable<KeyValuePair<string, string>> nameValueCollection)
    {
        LastErrorMessage = string.Empty;
        try
        {
            var response = await _httpClient.PostAsync(path, new FormUrlEncodedContent(nameValueCollection)).ConfigureAwait(false);
            if (response != null)
            {
                var bytes = await response.Content.ReadAsByteArrayAsync();
                var json_text = Encoding.UTF8.GetString(bytes);
                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<T>(json_text);
                }
                LastErrorMessage = json_text ?? response.StatusCode.ToString();
            }
        }
        catch (Exception ex)
        {
            LastErrorMessage = ex.Message;
        }
        return default;
    }

    record OAuth(string access_token, string scope, string token_type, long expires_in);

    record RealtimeResponseModel(RealtimeResponseModel.Header header, object body)
    {
        public record Header(string tr_type, string rsp_cd, string rsp_msg, string tr_cd, string tr_key);
    }

    /// <inheritdoc cref="IOpenApi.RequestRealtimeAsync"/>/>
    public async Task<bool> RequestRealtimeAsync(string tr_cd, string tr_key, bool bAdd)
    {
        if (!Connected || _wssClient is null || _wssClient.State != WebSocketState.Open)
        {
            LastErrorMessage = "Websocket 연결이 되어 있지 않습니다";
            return false;
        }
        LastErrorMessage = string.Empty;

        bool isAccount = LibConst.AccountRealTimes.Contains(tr_cd);

        string jsonbody = $"{{\"header\":{{\"token\":\"{_authorization}\",\"tr_type\":\"{(bAdd ? (isAccount ? "3" : "1") : (isAccount ? "4" : "2"))}\"}},\"body\":{{\"tr_cd\":\"{tr_cd}\",\"tr_key\":\"{tr_key}\"}}}}";
        try
        {
            await _wssClient.SendAsync(Encoding.UTF8.GetBytes(jsonbody), WebSocketMessageType.Text, true, CancellationToken.None);
            return true;
        }
        catch (Exception ex)
        {
            LastErrorMessage = ex.Message;
            return false;
        }
    }

    /// <inheritdoc cref="IOpenApi.RequestAsync"/>
    public async Task<(string jsonResponse, string cont_key)> RequestAsync(string path, string jsonRequest, string cont_key = "")
    {
        LastErrorMessage = string.Empty;

        // 요청 전문을 만든다
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        HttpRequestMessage httpRequestMessage = new(HttpMethod.Post, path)
        {
            Content = content,
        };

        httpRequestMessage.Headers.Add("cont_yn", cont_key.Length > 0 ? "Y" : "N");
        httpRequestMessage.Headers.Add("cont_key", cont_key);

        // 법인 경우 mac_address 필수
        if (_macAddress.Length > 0) httpRequestMessage.Headers.Add("mac_address", _macAddress);

        // 요청을 보낸다
        try
        {
            var httpresponseMsg = await _httpClient.SendAsync(httpRequestMessage);
            var jsonResponse = await httpresponseMsg.Content.ReadAsStringAsync();
            string res_cont_yn = string.Empty;
            string res_cont_key = string.Empty;
            if (httpresponseMsg.Headers.TryGetValues("cont_yn", out var values))
            {
                res_cont_yn = values.FirstOrDefault() ?? "";
                if (res_cont_yn.Equals("Y"))
                {
                    if (httpresponseMsg.Headers.TryGetValues("cont_key", out values))
                    {
                        res_cont_key = values.FirstOrDefault() ?? "";
                    }
                }
            }
            return (jsonResponse, res_cont_key);
        }
        catch (Exception ex)
        {
            LastErrorMessage = $"RequestTrData Error: {ex.Message}";
            return (string.Empty, string.Empty);
        }
    }

    /// <inheritdoc cref="IOpenApi.RequestTrAsync"/>
    public async Task<ResponseTrData?> RequestTrAsync(string tr_cd, IEnumerable<KeyValuePair<string, object?>> indatas, string cont_key = "")
    {
        var trSpec = LibConst.GetTrSpec(tr_cd);
        if (trSpec == null)
        {
            LastErrorMessage = "등록된 코드가 아닙니다.";
            return default;
        }

        var jsonRequest = new StringBuilder();
        jsonRequest.Append('{');
        jsonRequest.Append("\"In\":{");
        bool bFirst = true;
        foreach (var indata in indatas)
        {
            if (bFirst)
            {
                bFirst = false;
            }
            else
            {
                jsonRequest.Append(',');
            }
            if (indata.Value is string)
            {
                jsonRequest.Append($"\"{indata.Key}\":\"{indata.Value}\"");
            }
            else
            {
                jsonRequest.Append($"\"{indata.Key}\":{indata.Value}");
            }
        }
        jsonRequest.Append("}}");

        var response = await RequestAsync(trSpec.Path, jsonRequest.ToString(), cont_key);

        try
        {
            var dataResponse = JsonSerializer.Deserialize<ResponseTrData>(response.jsonResponse, _jsonOptions);
            if (dataResponse is not null)
            {
                dataResponse.tr_cd = tr_cd;
                dataResponse.cont_key = response.cont_key;
                return dataResponse;
            }
            LastErrorMessage = $"수신데이터가 없습니다.{tr_cd}";
        }
        catch (Exception ex)
        {
            LastErrorMessage = ex.Message;
        }
        return default;
    }
}
