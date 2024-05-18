using System.Text.Json;

namespace DBOpenApi.NET;

/// <summary>
/// 실시간 웹소켓 이벤트
/// </summary>
/// <param name="TrCode">Tr코드</param>
/// <param name="Key">키</param>
/// <param name="RealtimeBody">실시간응잡(JsonElement)</param>
public class RealtimeEventArgs(string TrCode, string Key, JsonElement RealtimeBody) : EventArgs
{
    /// <summary>Tr코드</summary>
    public string TrCode { get; } = TrCode;
    /// <summary>키</summary>
    public string Key { get; } = Key;
    /// <summary>실시간응답(JsonElement)</summary>
    public JsonElement RealtimeBody { get; } = RealtimeBody;
}
