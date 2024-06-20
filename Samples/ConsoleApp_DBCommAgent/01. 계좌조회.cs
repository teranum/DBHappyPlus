namespace CSharp;

internal class _01 : SampleBase
{
    public override async Task ActionImplement()
    {
        print("로그인 기능은 SampleBase Main 함수에서 구현됨");

        var accounts = await api.GetAccountsAsync();

        if (accounts.Count == 0)
        {
            print("계좌정보가 없습니다");
            return;
        }

        if (!api.IsSimulation) // 실계좌 일 경우 비번 설정
        {
            foreach (var account in accounts)
            {
                account.비밀번호 = Secret.AccPwd;
            }
        }

        print(accounts);
    }
}
