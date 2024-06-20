namespace CSharp;

internal class _05 : SampleBase
{
    public override async Task ActionImplement()
    {
        var items = new List<KeyValuePair<string, string>>
        {
            new("1001", "U"),
            new("2001", "U"),
            new("101V3000", "F"),
            new("005930", "J"),
        };


        // FIDS: 종목명, 시가, 고가, 저가, 종가, 거래량, 전일가, 전일거래량

        var portfolio_info = await api.GetPortfolioAsync(items, "3,13,14,15,4,11,16,28");
        print(portfolio_info);
    }
}
