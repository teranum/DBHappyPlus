namespace DBOpenApi.NET;

/// <summary>
/// OpenAPI 인터페이스
/// </summary>
public interface IOpenApi
{
    /// <inheritdoc cref="MessageEventArgs"/>
    event EventHandler<MessageEventArgs>? OnMessageEvent;

    /// <inheritdoc cref="RealtimeEventArgs"/>
    event EventHandler<RealtimeEventArgs>? OnRealtimeEvent;

    /// <summary>연결 여부</summary>
    bool Connected { get; }

    /// <summary>모의투자 여부</summary>
    bool IsSimulation { get; }

    /// <summary>
    /// 비동기 연결 요청
    /// </summary>
    /// <param name="appKey">포탈에서 발급된 고객의 앱Key</param>
    /// <param name="appSecretKey">포탈에서 발급된 고객의 앱 비밀Key</param>
    /// <param name="access_token">이미 발급받은 액서스 키</param>
    /// <param name="wss_domain">웹소켓URL 수동으로 설정시 필요</param>
    /// <returns>true: 연결성공, false: 연결실패</returns>
    Task<bool> ConnectAsync(string appKey, string appSecretKey, string access_token = "", string wss_domain = "");

    /// <summary>비동기 연결 해제</summary>
    Task CloseAsync();

    /// <summary>
    /// 로그인 된 경우 액세스 토큰
    /// </summary>
    string AccessToken { get; }

    /// <summary>
    /// MAC 주소 (법인 경우 필수 세팅)
    /// </summary>
    string MacAddress { get; set; }

    /// <summary>
    /// 접근토큰 유효기간(초)
    /// </summary>
    /// <returns></returns>
    long Expires { get; }

    /// <summary>
    /// 마지막 에러 메시지
    /// </summary>
    string LastErrorMessage { get; }

    /// <summary>
    /// 실시간 시세 등록/해제
    /// </summary>
    /// <param name="tr_cd">증권 거래코드</param>
    /// <param name="tr_key">단축코드 6자리 또는 8자리 (단건, 연속)</param>
    /// <param name="bAdd">시세등록: true, 시세해제: false</param>
    /// <returns>true: 요청성공, false: 요청실패</returns>
    Task<bool> RequestRealtimeAsync(string tr_cd, string tr_key, bool bAdd);

    /// <summary>
    /// 비동기 JSON 요청
    /// </summary>
    /// <param name="path">URL경로</param>
    /// <param name="jsonRequest">요청 전문</param>
    /// <param name="cont_key">연속일 경우 그전에 내려온 연속키 값 올림</param>
    /// <returns></returns>
    Task<(string jsonResponse, string cont_key)> RequestAsync(string path, string jsonRequest, string cont_key = "");

    /// <summary>
    /// 비동기 TR 요청
    /// </summary>
    /// <param name="tr_cd">증권 거래코드</param>
    /// <param name="indatas">요청 데이터</param>
    /// <param name="cont_key">연속일 경우 그전에 내려온 연속키 값 올림</param>
    /// <returns></returns>
    Task<ResponseTrData?> RequestTrAsync(string tr_cd, IEnumerable<KeyValuePair<string, object?>> indatas, string cont_key = "");
}
