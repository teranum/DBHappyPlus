# [![NuGet version](https://badge.fury.io/nu/DBOpenApiW.NET.png)](https://badge.fury.io/nu/DBOpenApiW.NET)  DBOAMngW.NET (DB금융투자 해외파생 OCX버젼)
- DB금융투자 해외파생 OpenApi OCX version C# wrapper class
- 개발환경: Visual Studio 2022, netstandard2.0

---------------

```c#
using DBOpenApiW.NET;
...
    // 메인 윈도우 클래스 멤버로 선언
    private readonly AxDBOpenApiW _axDBOpenApiW;

    public ctor()
    {
        // nint Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle(); // WPF 에서만 필요
        _axDBOpenApiW = new (Handle);

        // 이벤트 핸들러 등록
        _axDBOpenApiW.OnDBOAEventConnect += _axDBOpenApiW_OnDBOAEventConnect;
        ...

    }

    private void _axDBOpenApiW_OnDBOAEventConnect(object sender, _DDBOpenApiWEvents_OnDBOAEventConnectEvent e)
    {
        ...
    }


```

