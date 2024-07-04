using System.Text.Json;

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

    /// <summary>응답데이터1</summary>
    public JsonElement? Out { get; init; }
    /// <summary>응답데이터2</summary>
    public JsonElement? Out1 { get; init; }
    /// <summary>응답데이터3</summary>
    public JsonElement? Out2 { get; init; }
    /// <summary>응답데이터4</summary>
    public JsonElement? Out3 { get; init; }
}
