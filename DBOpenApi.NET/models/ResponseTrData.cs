namespace DBOpenApi.NET;

/// <summary>
/// 수신 데이터
/// </summary>
public class ResponseTrData
{
    /// <summary>TR코드</summary>
    public string tr_cd { get; set; } = string.Empty;
    /// <summary>연속조회 키</summary>
    public string cont_key { get; set; } = string.Empty;
    /// <summary>응답코드</summary>
    public string rsp_cd { get; set; } = string.Empty;
    /// <summary>응답메시지</summary>
    public string rsp_msg { get; set; } = string.Empty;
}
