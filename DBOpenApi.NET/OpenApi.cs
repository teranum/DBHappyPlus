﻿using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DBOpenApi.NET;

/// <summary>
/// DB증권 OpenApi
/// </summary>
public class OpenApi
{
    /// <summary>
    /// 로그인 서버 타입
    /// </summary>
    public enum SERVER_TYPE
    {
        /// <summary>실투자</summary>
        실투자,
        /// <summary>모의투자</summary>
        모의투자,
    }


    private readonly HttpClient _httpClient;
    private ClientWebSocket? _wssClient;
    private string _authorization = string.Empty;
    private string _macAddress = string.Empty;
    private long _expires_in;
    private readonly JsonSerializerOptions _jsonOptions;

    /// <summary>
    /// 서버 메시지 이벤트
    /// </summary>
    public event EventHandler<MessageEventArgs>? OnMessageEvent;

    /// <summary>
    /// 실시간 웹소켓 이벤트
    /// </summary>
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

    /// <summary>
    /// 로그인 서버 타입 (실투자, 모의투자)
    /// </summary>
    public SERVER_TYPE ServerType { get; private set; }

    /// <summary>
    /// 로그인 된 경우 true
    /// </summary>
    public bool Connected { get; private set; }

    /// <summary>
    /// 로그인 된 경우 액세스 토큰
    /// </summary>
    public string access_token => _authorization;

    /// <summary>
    /// 마지막 에러 메시지
    /// </summary>
    public string LastErrorMessage = string.Empty;

    /// <summary>
    /// MAC 주소 (법인 경우 필수 세팅)
    /// </summary>
    public string MacAddress
    {
        get => _macAddress;
        set => _macAddress = value;
    }


    /// <summary>
    /// 접근토큰 유효기간(초)
    /// </summary>
    /// <returns></returns>
    public long GetExpires() => _expires_in;

    /// <summary>
    /// 연결 요청
    /// </summary>
    /// <param name="appKey">포탈에서 발급된 고객의 앱Key</param>
    /// <param name="appSecretKey">포탈에서 발급된 고객의 앱 비밀Key</param>
    /// <param name="access_token">이미 발급받은 액서스 키</param>
    /// <param name="is_simulation">모의투자 인 경우 true로 설정</param>
    /// <param name="wss_domain">해외선물옵션인 경우 LibConst.WssUrlGlobal 로 설정</param>
    /// <returns>true: 연결성공, false: 연결실패</returns>
    public async ValueTask<bool> Login(string appKey, string appSecretKey, string access_token = "", bool is_simulation = false, string wss_domain = "")
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


        ServerType = is_simulation ? SERVER_TYPE.모의투자 : SERVER_TYPE.실투자;
        //// 모의투자인지 실투자인지 구분한다
        //Dictionary<string, object?> CSPEQ00400 = new();
        //var response = await RequestTrData("CSPEQ00400", CSPEQ00400);
        //if (response is null)
        //{
        //    // 요청 실패
        //    LastErrorMessage = "모의투자/실투자 구분 요청 실패";
        //    return false;
        //}

        //if (response.rsp_msg.StartsWith("모의투자", StringComparison.Ordinal))
        //{
        //    ServerType = SERVER_TYPE.모의투자;
        //}

        // 실시간 웹소켓 연결
        if (string.IsNullOrEmpty(wss_domain))
        {
            wss_domain = ServerType == SERVER_TYPE.실투자 ? LibConst.WssUrlReal : LibConst.WssUrlSimulation;
        }
        Uri wssUri = new(wss_domain + "/websocket");

        _wssClient = new ClientWebSocket();
        if (_wssClient.ConnectAsync(wssUri, CancellationToken.None).Wait(2000))
        {
            Connected = true;
            _ = WebsocketListen(_wssClient);

            return true;
        }

        LastErrorMessage = "Websocket서버 연결 응답 없습니다";
        return false;
    }

    /// <summary>연결 해제</summary>
    public void Close()
    {
        if (Connected)
        {
            if (_wssClient is not null && _wssClient.State == WebSocketState.Open)
                _wssClient.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None).Wait();
            Connected = false;
        }
    }

    /// <summary>
    /// 실시간 시세등록
    /// </summary>
    /// <param name="tr_cd">DB증권 거래코드</param>
    /// <param name="tr_key">단축코드 6자리 또는 8자리 (단건, 연속)</param>
    /// <returns>true: 요청성공, false: 요청실패</returns>
    public Task<bool> AddRealtimeRequest(string tr_cd, string tr_key) => RealtimeRequest<WssRequest>(new(new(_authorization, "3"), new(tr_cd, tr_key)));

    /// <summary>
    /// 실시간 시세해제
    /// </summary>
    /// <param name="tr_cd">DB증권 거래코드</param>
    /// <param name="tr_key">단축코드 6자리 또는 8자리 (단건, 연속)</param>
    /// <returns>true: 요청성공, false: 요청실패</returns>
    public Task<bool> RemoveRealtimeRequest(string tr_cd, string tr_key) => RealtimeRequest<WssRequest>(new(new(_authorization, "4"), new(tr_cd, tr_key)));

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
                    if (webSocket.State != WebSocketState.Closed)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                        if (_wssClient == webSocket) _wssClient = null;
                    }
                    OnWssClosed("Websocket: " + result.CloseStatusDescription ?? "Closed");
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

    /// <summary>
    /// 실시간 요청
    /// </summary>
    /// <typeparam name="T">request 타입</typeparam>
    /// <param name="request">request</param>
    /// <returns></returns>
    protected async Task<bool> RealtimeRequest<T>(T request)
    {
        if (!Connected || _wssClient is null || _wssClient.State != WebSocketState.Open)
        {
            LastErrorMessage = "Websocket 연결이 되어 있지 않습니다";
            return false;
        }
        LastErrorMessage = string.Empty;
        try
        {
            string jsonbody = JsonSerializer.Serialize(request);
            await _wssClient.SendAsync(Encoding.UTF8.GetBytes(jsonbody), WebSocketMessageType.Text, true, CancellationToken.None);
            return true;
        }
        catch (Exception ex)
        {
            LastErrorMessage = ex.Message;
            return false;
        }
    }

    private async ValueTask<T?> PostUrlEncodedAsync<T>(string path, IEnumerable<KeyValuePair<string, string>> nameValueCollection)
    {
        LastErrorMessage = string.Empty;
        try
        {
            var response = await _httpClient.PostAsync(path, new FormUrlEncodedContent(nameValueCollection)).ConfigureAwait(false);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                }
                LastErrorMessage = await response.Content.ReadAsStringAsync().ConfigureAwait(false) ?? response.StatusCode.ToString();
            }
        }
        catch (Exception ex)
        {
            LastErrorMessage = ex.Message;
        }
        return default;
    }

    record OAuth(string access_token, string scope, string token_type, long expires_in);

    record WssRequest(WssRequest.Header header, WssRequest.Body body)
    {
        public record Header(string token, string tr_type);
        public record Body(string tr_cd, string tr_key);
    }
    record RealtimeResponseModel(RealtimeResponseModel.Header header, object body)
    {
        public record Header(string tr_type, string rsp_cd, string rsp_msg, string tr_cd, string tr_key);
    }

    /// <summary>
    /// 요청 전문을 보낸다<br/>
    /// 
    /// </summary>
    /// <param name="tr_cd">tr_cd</param>
    /// <param name="request"></param>
    /// <param name="cont_yn">연속조회 여부: "Y" 또는 "N"</param>
    /// <param name="cont_key">연속조회 키</param>
    /// <param name="path">URL경로</param>
    /// <returns>응답 데이터</returns>
    public async Task<ResponseData?> RequestTrData(string tr_cd, IDictionary<string, object?> request, string cont_yn = "N", string cont_key = "", string path = "")
    {
        LastErrorMessage = string.Empty;

        if (string.IsNullOrEmpty(path))
        {
            if (LibConst.Paths.TryGetValue(tr_cd, out LibConst.TrSpec? trSpec))
                path = trSpec.Path;
            else
            {
                LastErrorMessage = "요청코드 경로를 찾을 수 없습니다";
                return null;
            }
        }

        // 요청 전문을 만든다
        string jsonbody = JsonSerializer.Serialize(request);
        var content = new StringContent(jsonbody, Encoding.UTF8, "application/json");
        HttpRequestMessage httpRequestMessage = new(HttpMethod.Post, path)
        {
            Content = content,
        };

        httpRequestMessage.Headers.Add("cont_yn", cont_yn);
        httpRequestMessage.Headers.Add("cont_key", cont_key);

        // 법인 경우 mac_address 필수
        if (_macAddress.Length > 0) httpRequestMessage.Headers.Add("mac_address", _macAddress);

        // 요청을 보낸다
        try
        {
            var httpresponseMsg = await _httpClient.SendAsync(httpRequestMessage);
            var jsonResponse = await httpresponseMsg.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<ResponseData>(jsonResponse, _jsonOptions);
            if (response != null)
            {
                response.cont_yn = httpresponseMsg.Headers.GetValues("cont_yn").FirstOrDefault() ?? "N";
                response.cont_key = httpresponseMsg.Headers.GetValues("cont_key").FirstOrDefault() ?? "";
            }
            return response;
        }
        catch (Exception ex)
        {
            LastErrorMessage = $"RequestTrData Error: {ex.Message}";
            return null;
        }
    }

    /// <summary>
    /// JSON 전문을 보낸다
    /// </summary>
    /// <param name="path">URL</param>
    /// <param name="jsonbody">JSON 전문</param>
    /// <param name="cont_yn">연속조회 여부</param>
    /// <param name="cont_key">연속조회 키</param>
    /// <returns></returns>
    public async Task<(string json_text, string cont_yn, string cont_key)?> RequestWithJson(string path, string jsonbody, string cont_yn = "N", string cont_key = "")
    {
        LastErrorMessage = string.Empty;

        // 요청 전문을 만든다
        var content = new StringContent(jsonbody, Encoding.UTF8, "application/json");
        HttpRequestMessage httpRequestMessage = new(HttpMethod.Post, path)
        {
            Content = content,
        };

        httpRequestMessage.Headers.Add("cont_yn", cont_yn);
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
            }
            if (httpresponseMsg.Headers.TryGetValues("cont_key", out values))
            {
                res_cont_key = values.FirstOrDefault() ?? "";
            }
            return (jsonResponse, res_cont_yn, res_cont_key);
        }
        catch (Exception ex)
        {
            LastErrorMessage = $"RequestTrData Error: {ex.Message}";
            return null;
        }
    }


}

/// <summary>
/// 응답 데이터
/// </summary>
public class ResponseData
{
    /// <summary>
    /// 연속조회 여부
    /// </summary>
    public string cont_yn = "N";

    /// <summary>연속조회 키</summary>
    public string cont_key = string.Empty;

    /// <summary>응답코드</summary>
    public string rsp_cd { get; set; } = string.Empty;

    /// <summary>응답메시지</summary>
    public string rsp_msg { get; set; } = string.Empty;

    /// <summary>응답데이터 Out</summary>
    public object? Out { get; set; }
    /// <summary>응답데이터 Out1</summary>
    public object? Out1 { get; set; }
    /// <summary>응답데이터 Out2</summary>
    public object? Out2 { get; set; }
    /// <summary>응답데이터 Out3</summary>
    public object? Out3 { get; set; }
    /// <summary>응답데이터 Out4</summary>
    public object? Out4 { get; set; }
    /// <summary>응답데이터 Out5</summary>
    public object? Out5 { get; set; }
}
