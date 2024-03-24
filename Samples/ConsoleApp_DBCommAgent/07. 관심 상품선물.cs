namespace CSharp;

internal class _07 : SampleBase
{
    public override async Task ActionImplement()
    {
        print("관심상품코드 요청중...");
        var all_CF = await api.GetMarketInfoAsync(DBCommAgent.NET.GroupKind.상품선물);

        var lifed_items = all_CF.Where(x => x.전일거래량 > 10000);
        print(lifed_items);

        var 상품코드 = api.시장분류코드[(int)DBCommAgent.NET.GroupKind.상품선물];
        var portfolis_items = lifed_items.Select(x => new KeyValuePair<string, string>(x.단축코드, 상품코드));


        (string Name, string Fid)[] NameFids =
            [
            ("종목명", "3"),
            ("시가", "13"),
            ("고가", "14"),
            ("저가", "15"),
            ("종가", "4"),
            ("거래량", "11"),
            ("전일가", "16"),
            ("전일거래량", "28"),
            ("호가단위", "2295"),
            ("거래승수", "1773"),
            ];
        // FIDS: 종목명, 시가, 고가, 저가, 종가, 거래량, 전일가, 전일거래량, 호가단위, 거래승수, 증거금
        var nameList = NameFids.Select(x => x.Name).ToArray();
        string regFids = string.Join(',', NameFids.Select(x=>x.Fid));
        var portfolio_info = await api.GetPortfolioAsync(portfolis_items, regFids);
        if (portfolio_info.FieldInfos.Count == NameFids.Length)
        {
            for (int i = 0; i < NameFids.Length; i++)
            {
                portfolio_info.FieldInfos[i].CAPTION = nameList[i];
            }

            for (int i = 0; i < portfolio_info.OutDatas.Length; i++)
            {
                double.TryParse(portfolio_info.OutDatas[i][9], out double 거래승수);
                portfolio_info.OutDatas[i][9] = $"{거래승수,10:N0}";
            }
        }

        print("관심 상품선물", nameList, portfolio_info.OutDatas);
    }
}
