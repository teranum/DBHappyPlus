# [![NuGet version](https://badge.fury.io/nu/DBCommAgent.NET.png)](https://badge.fury.io/nu/DBCommAgent.NET)  DBCommAgent.NET (DB금융투자 국내-주식/파생)
- DB금융투자 국내-주식/파생 OpenApi C# wrapper class
- 개발환경: Visual Studio 2022, netstandard2.0

---------------

```c#
using DBCommAgent.NET;
...
    // 메인 윈도우 클래스 멤버로 선언
    private readonly AxDBCommAgent _axDBCommAgent;

    public ctor()
    {
        // nint Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle(); // WPF 에서만 필요
        _axDBCommAgent = new (Handle);

        // 이벤트 핸들러 등록
        _axDBCommAgent.OnAgentEventHandler += _axDBCommAgent_OnAgentEventHandler;
        ...

    }

    private void _axDBCommAgent_OnAgentEventHandler(object sender, _DDBCommAgentEvents_OnAgentEventHandlerEvent e)
    {
        ...
    }


```
