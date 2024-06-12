namespace DBOpenApi.NET;

/// <summary>
/// 상수 정의
/// </summary>
public static class LibConst
{
    /// <summary>API 서버 주소</summary>
    public const string BaseUrl = "https://openapi.db-fi.com:8443";

    /// <summary>웹소켓 서버 주소(모의투자)</summary>
    public const string WssUrlReal = "wss://openapi.db-fi.com:7070";

    /// <summary>웹소켓 서버 주소(실시간)</summary>
    public const string WssUrlSimulation = "wss://openapi.db-fi.com:17070";

    /// <summary>웹소켓 서버 주소(해외선물옵션 실시간)</summary>
    public const string WssUrlGlobal = "wss://openapi.db-fi.com:7071";
}
