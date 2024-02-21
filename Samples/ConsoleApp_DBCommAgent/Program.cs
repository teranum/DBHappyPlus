using ConsoleApp_DBCommAgent;
using DBCommAgent.NET;

namespace ConsoleApp;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        new Sample().RunAsync();
        NativeLoop.LoopForever(); // if need for break, press CTRL+C
    }
}

class Sample
{
    readonly AxDBCommAgent api = new();
    private static void OutLog(string msg = "") => Console.WriteLine(msg);
    public async void RunAsync()
    {
        if (!api.Created)
        {
            OutLog("OpenApi 미설치");
            return;
        }

        api.OnAgentEventHandler += Api_OnAgentEventHandler;

        // 통신 초기화
        if (0 > api.CommInit())
        {
            OutLog("통신초기화(CommInit): 실패");
            return;
        }

        OutLog("로그인 요청...");
        if (1 != api.CommLogin(Secret.유저아이디, Secret.비번, Secret.공인비번))
        {
            OutLog("로그인(CommLogin): 실패");
            return;
        }

        // 로그인 상태 확인
        OutLog($"GetLoginState: {api.GetLoginState()}");
        OutLog($"GetApiAgentModulePath: {api.GetApiAgentModulePath()}");
        OutLog();

        // 지수선물 종목리스트 조회
        OutLog("지수선물 종목리스트 조회...");
        List<string> 지수선물코드리스트 = [];
        int nReturn = await api.RequestFidArrayAsync([
            ("9001", "F"),                      //입력조건시장분류코드
            ("GID", "1499"),                    //GID
            ], "1,2,3,16", "0", "", "9999", 0,
            (ov, e) =>
            {
                var blockData = api.GetCommFidDataBlock();
                지수선물코드리스트.Capacity = blockData.Rows;
                for (int i = 0; i < blockData.Rows; i++)
                {
                    지수선물코드리스트.Add(blockData[i, 0].Trim()); // 리스트에 종목코드 추가
                }
            }
            ).ConfigureAwait(true);
        if (nReturn < 0 || 지수선물코드리스트.Count == 0)
        {
            OutLog($"지수선물 종목리스트 조회실패({nReturn}): {api.GetLastErrMsg()}");
            return;
        }
        OutLog($"지수선물리스트 개수: {지수선물코드리스트.Count}");
        foreach (var item in 지수선물코드리스트)
        {
            OutLog(item);
        }
        OutLog();

        // 메인 월물 15분봉 차트 조회
        OutLog("메인 월물 15분봉 차트 조회...");
        string item_code = 지수선물코드리스트[0];
        int interval = 15;
        List<(double T, double O, double H, double L, double C, double V)> chartDatas = [];
        string date = DateTime.Today.ToString("yyyyMMdd");
        nReturn = await api.RequestFidArrayAsync(
            [
            ("9001", "F"),                      //입력조건시장분류코드
            ("9002", item_code),                //입력종목코드1
            ("9034", date),                     //시작일
            ("9035", date),                     //종료일
            ("9119", (interval*60).ToString()), //구 분코드( 30: 30초, 60: 1분, 600: 10분, 3600: 60분, 60*N: N분 )
            ("GID", "1005"),
            ], "9,8,13,14,15,4,83", "0", "", "9999", 100,
            (ov, e) =>
            {
                // 9:일자, 8:시간, 13:시가, 14:고가, 15:저가, 4:종가, 83:거래량
                // 메모리 블럭에서 데이터를 읽어온다.
                var commRecvData = api.GetCommFidDataBlock(); // 콜백함수에서만 사용가능
                chartDatas.Capacity = commRecvData.Rows;
                for (int i = 0; i < commRecvData.Rows; i++)
                {
                    chartDatas.Add((
                        double.Parse(commRecvData[i, 0]) * 1000000
                        + double.Parse(commRecvData[i, 1]), // T = 일자*1000000 + 시간
                        double.Parse(commRecvData[i, 2]),   // O
                        double.Parse(commRecvData[i, 3]),   // H
                        double.Parse(commRecvData[i, 4]),   // L
                        double.Parse(commRecvData[i, 5]),   // C
                        double.Parse(commRecvData[i, 6])    // V
                        ));
                }
            }
            ).ConfigureAwait(true);
        if (nReturn < 0)
        {
            OutLog($"RequestFidArrayAsync failed({nReturn}): {api.GetLastErrMsg()}");
            return;
        }

        OutLog($"지수차트요청 [{item_code}]: 데이터개수: {chartDatas.Count}");
        OutLog("index, 일자시간, 시가, 고가, 저가, 종가, 거래량");

        for (int i = 0; i < chartDatas.Count; i++)
        {
            OutLog($"{i:d2}: {chartDatas[i].T}, {chartDatas[i].O}, {chartDatas[i].H}, {chartDatas[i].L}, {chartDatas[i].C}, {chartDatas[i].V}");
        }

        // 작업 추가...
    }

    private void Api_OnAgentEventHandler(object sender, _DDBCommAgentEvents_OnAgentEventHandlerEvent e)
    {
        OutLog($"OnAgentEventHandler: nEventType={e.nEventType}, nParam={e.nParam}, strParam={e.strParam}");
    }
}
