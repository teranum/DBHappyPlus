# [![NuGet version](https://badge.fury.io/nu/DBCommAgent.NET.png)](https://badge.fury.io/nu/DBCommAgent.NET)  DBCommAgent.NET (DB금융투자 국내-주식/파생)
- DB금융투자 국내-주식/파생 OpenApi C# wrapper class
- 개발환경: Visual Studio 2022, netstandard2.0

---------------

```c#
using DBCommAgent.NET;
...
    // 메인 윈도우 클래스 멤버로 선언
    private readonly AxDBCommAgent api;

    public ctor()
    {
        // nint Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle(); // WPF 에서만 필요
        api = new (Handle);

        // 이벤트 핸들러 등록
        api.OnAgentEventHandler += Api_OnAgentEventHandler;
        ...

    }

    private void login()
    {
        if (!api.Created)
        {
            OutLog("OpenApi 미설치");
            return;
        }

        if (api.GetLoginState() == 1)
        {
            OutLog("이미 로그인 되어 있습니다.");
            return;
        }

        int ret = api.CommInit();
        OutLog($"returned CommInit: {ret}");
        ret = api.CommLogin(textBox_userId.Text, textBox_password.Text, textBox_certPwd.Text);
        OutLog($"returned CommLogin: {ret}");
    }

    private void Api_OnAgentEventHandler(object sender, _DDBCommAgentEvents_OnAgentEventHandlerEvent e)
    {
        ...
    }


```

```c#
using DBCommAgent.NET;

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
    readonly AxDBCommAgent api = new();
    public void Run()
    {
        if (!api.Created)
        {
            Console.WriteLine("OpenApi 미설치");
            return;
        }

        api.OnAgentEventHandler += Api_OnAgentEventHandler;

        // 통신 초기화
        if (0 > api.CommInit())
        {
            Console.WriteLine("통신초기화(CommInit): 실패");
            return;
        }

        Console.WriteLine("로그인 요청...");
        if (1 != api.CommLogin(Secret.유저아이디, Secret.비번, Secret.공인비번))
        {
            Console.WriteLine("로그인(CommLogin): 실패");
            return;
        }

        // 로그인 상태 확인
        Console.WriteLine($"GetLoginState: {api.GetLoginState()}");
        Console.WriteLine($"GetApiAgentModulePath: {api.GetApiAgentModulePath()}");

        // 작업 추가...
    }

    private void Api_OnAgentEventHandler(object sender, _DDBCommAgentEvents_OnAgentEventHandlerEvent e)
    {
        Console.WriteLine($"OnAgentEventHandler: nEventType={e.nEventType}, nParam={e.nParam}, strParam={e.strParam}");
    }
}
```
