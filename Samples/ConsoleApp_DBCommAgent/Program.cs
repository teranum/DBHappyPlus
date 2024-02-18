using ConsoleApp_DBCommAgent;
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
