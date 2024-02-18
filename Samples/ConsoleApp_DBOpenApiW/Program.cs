using DBOpenApiW.NET;

namespace ConsoleApp;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        new Sample().Run();
        NativeLoop.LoopForever(); // if need for break, press CTRL+C
    }
}

class Sample
{
    readonly AxDBOpenApiW api = new();
    public void Run()
    {
        if (!api.Created)
        {
            Console.WriteLine("OpenApi 미설치");
            return;
        }

        api.OnDBOAEventConnect += Api_OnDBOAEventConnect;

        Console.WriteLine("로그인 요청...");
        if (0 != api.DBOACommConnect())
        {
            Console.WriteLine("로그인(DBOACommConnect): 요청실패");
            return;
        }

        // 작업 추가...
    }

    private string _UserID = string.Empty;
    private void Api_OnDBOAEventConnect(object sender, _DDBOpenApiWEvents_OnDBOAEventConnectEvent e)
    {
        Console.WriteLine($"OnDBOAEventConnect: sUserID={e.sUserID}, nErrCode={e.nErrCode}");

        if (0 != e.nErrCode) // 로그인 실패
        {
            Console.WriteLine("OnDBOAEventConnect: 로그인 실패");
            return;
        }

        Console.WriteLine("OnDBOAEventConnect: 로그인 성공");
        _UserID = e.sUserID;

        // 작업 추가...
    }
}
