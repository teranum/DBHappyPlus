# [![NuGet version](https://badge.fury.io/nu/DBOpenApiW.NET.png)](https://badge.fury.io/nu/DBOpenApiW.NET)  DBOpenApiW.NET (DB금융투자 해외파생 OCX버젼)
- DB금융투자 해외파생 OpenApi OCX version C# wrapper class
- 개발환경: Visual Studio 2022, netstandard2.0

---------------

```c#
using DBOpenApiW.NET;
...
    // 메인 윈도우 클래스 멤버로 선언
    private readonly AxDBOpenApiW api;

    public ctor()
    {
        // nint Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle(); // WPF 에서만 필요
        api = new (Handle);

        // 이벤트 핸들러 등록
        api.OnDBOAEventConnect += Api_OnDBOAEventConnect;
        ...
    }

    private void login()
    {
        if (!api.Created)
        {
            OutLog("OpenApi 미설치");
            return;
        }

        int ret = api.DBOACommLogin(textBox_userId.Text, textBox_password.Text, textBox_certPwd.Text, 0);
        ...
    }

    private void Api_OnDBOAEventConnect(object sender, _DDBOpenApiWEvents_OnDBOAEventConnectEvent e)
    {
        ...
    }

```


```c#
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
```
