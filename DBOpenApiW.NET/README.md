# [![NuGet version](https://badge.fury.io/nu/DBOpenApiW.NET.png)](https://badge.fury.io/nu/DBOpenApiW.NET)  DBOpenApiW.NET (DB금융투자 해외파생 OCX버젼)
- DB금융투자 해외파생 OpenApi OCX version C# wrapper class
- 개발환경: Visual Studio 2022, netstandard2.0

---------------

```c#
using DBOpenApiW.NET;
...
    // 메인 윈도우 클래스 멤버로 선언
    private readonly AxDBOpenApiW _api;

    public ctor()
    {
        // nint Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle(); // WPF 에서만 필요
        _api = new (Handle);

        // 이벤트 핸들러 등록
        _api.OnDBOAEventConnect += Api_OnDBOAEventConnect;
        ...

    }

    private void Api_OnDBOAEventConnect(object sender, _DDBOpenApiWEvents_OnDBOAEventConnectEvent e)
    {
        ...
    }

    // 비동기 요청
    private async Task TestAsync()
    {
        // 차트데이터 연속조회, 30분봉 종가 받을수 있을때까지 무한 반복
        List<string> price_list = []; // 종가 리스트
        string sPreNext = string.Empty;
        do
        {
            _api.DBOASetInputValue(UserId,"종목코드", "HSIG24");
            _api.DBOASetInputValue(UserId, "N분", "30");
            _api.DBOASetInputValue(UserId, "요청데이터건수", "400");
            _api.DBOASetInputValue(UserId, "조회종료일", "20240215");
            int result = await _api.DBOACommRqDataAsync(UserId, "차트요청", "pibg7302", sPreNext, "0010",
            (e) =>
            {
                sPreNext = e.sPreNext; // 연속조회 키값
                int repeatCount = _api.DBOAGetRepeatCnt(UserId, e.sTrCode, e.sRecordName);
                for (int i = 0; i < repeatCount; i++)
                {
                    price_list.Add(_api.DBOAGetCommData(UserId, e.sTrCode, e.sRecordName, i, "종가"));
                }
            });
            if (result < 0)
            {
                Debug.WriteLine($"returned DBOAGetCommData: {result}");
                break; // 요청 오류시 중단
            }

            Debug.WriteLine($"Data received: {price_list.Count}");
            await Task.Delay(1000); // 1초간 지연... 데이터 요청수 많을시 서버차단 가능성 있음, 지연시간 조절 필요
        } while (sPreNext.Length > 0);

        Debug.WriteLine($"all Data received: {price_list.Count}");

        ... // 수집된 종가 데이터 처리
    }


```

