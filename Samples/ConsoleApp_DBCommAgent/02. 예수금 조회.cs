namespace CSharp;

internal class _02 : SampleBase
{
    public override async Task ActionImplement()
    {
        var accounts = await api.GetAccountsAsync();

        // 계좌별 예수금 조회
        foreach (var account in accounts)
        {
            var tr_code = string.Empty;
            var keyValues = new Dictionary<string, object>(StringComparer.Ordinal);
            switch (account.상품상세코드명)
            {
                case "종합매매":
                case "순수위탁":
                    {
                        tr_code = "CDPCQ00100";
                        keyValues["Count"] = "00001";
                        keyValues["AcntNo"] = account.계좌번호;
                        keyValues["Pwd"] = account.비밀번호;
                    }
                    break;
                case "선물옵션":
                    {
                        tr_code = "CFOAQ50100";
                        keyValues["Count"] = "00001";
                        keyValues["AcntNo"] = account.계좌번호;
                        keyValues["InptPwd"] = api.GetEncrpyt(account.비밀번호);
                        keyValues["OrdDt"] = DateTime.Now.ToString("yyyyMMdd");
                        keyValues["BalEvalTp"] = "0";
                        keyValues["FutsPrcEvalTp"] = "1";
                    }
                    break;
                //case "해외선물옵션": // 해외선물옵션
                //    {
                //    }
                //    break;
                default:
                    break;
            }
            if (tr_code.Length == 0) continue;

            var OutRecs = await api.GetTRDataAsync(tr_code, keyValues);
            print($"{account.상품상세코드명}, {account.계좌번호}, {tr_code}");
            print($"[{api.LastCode}]: {api.LastMessage}");
            if (OutRecs != null)
            {
                foreach (var outrec in OutRecs)
                {
                    print(outrec);
                }
            }
        }
    }
}
