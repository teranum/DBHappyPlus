namespace CSharp;

internal class _03 : SampleBase
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

        // 조회
        var OutRec = await api.GetMarketInfoAsync(marketKind);
        print(OutRec);
    }
}
