namespace CSharp;

internal class _06 : SampleBase
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
        var groupKind = (DBCommAgent.NET.GroupKind)(marketNum - 1);

        // 종목코드 입력
        var in_code = await GetInputAsync("종목코드를 입력해 주세요:");

        // 캔들종류 선택
        var candleRoundKindNames = Enum.GetNames(typeof(DBCommAgent.NET.CandleRoundType));
        for (int i = 0; i < candleRoundKindNames.Length; i++) print($"{i + 1}: {candleRoundKindNames[i]}");
        int candleRoundKindNum;
        while (true)
        {
            var in_candleRoundKind = await GetInputAsync($"봉차트 종류를 선택해 주세요 (1~{candleRoundKindNames.Length}):");
            int.TryParse(in_candleRoundKind, out candleRoundKindNum);
            if (candleRoundKindNum > 0 && candleRoundKindNum <= candleRoundKindNames.Length) break;
        }
        var candleRoundKind = (DBCommAgent.NET.CandleRoundType)(candleRoundKindNum - 1);

        int interval = 1;
        if (candleRoundKind < DBCommAgent.NET.CandleRoundType.일)
        {
            while (true)
            {
                var in_interval = await GetInputAsync("분(틱) 주기를 입력해 주세요 (ex 1, 3, 5, 10, ...):");
                int.TryParse(in_interval, out interval);
                if (interval > 0) break;
            }
        }
        int reqCount;
        while (true)
        {
            var in_reqCount = await GetInputAsync("요청개수를 입력해 주세요 (ex 1~9999):");
            int.TryParse(in_reqCount, out reqCount);
            if (reqCount > 0 && reqCount <= 9999) break;
        }

        // 차트조회
        var candles = await api.GetCandleDataAsync(groupKind, in_code, candleRoundKind, interval, reqCount);
        print(candles);
    }
}
