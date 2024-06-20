namespace CSharp;

internal class _04 : SampleBase
{
    public override async Task ActionImplement()
    {
        // 마켓입력
        var marketNames = Enum.GetNames(typeof(DBCommAgent.NET.GroupKind));
        for (int i = 0; i < marketNames.Length; i++) print($"{i + 1}: {marketNames[i]}");
        int marketNum;
        while (true)
        {
            var in_market = await GetInputAsync($"마켓을 선택해 주세요 (1~{marketNames.Length}):");
            int.TryParse(in_market, out marketNum);
            if (marketNum > 0 && marketNum <= marketNames.Length) break;
        }
        var marketKind = (DBCommAgent.NET.GroupKind)(marketNum - 1);

        // 종목코드 입력
        var in_code = await GetInputAsync("종목코드를 입력해 주세요:");

        // 시세조회
        var sise_info = await api.GetSiseInfoAsync(marketKind, in_code);
        print(sise_info);

        // 일별체결조회
        var dayTrade_info = await api.GetDayTradeInfoAsync(marketKind, in_code, count: 100);
        print(dayTrade_info);
    }
}
