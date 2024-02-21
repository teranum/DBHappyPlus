using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DBCommAgent.NET;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Interop;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ObservableObject]
    public partial class MainWindow : Window
    {
        private readonly AxDBCommAgent api;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            OutLog("Inited");

            nint Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();
            api = new(Handle);
            OutLog($"api Created: {api.Created}");

            api.OnAgentEventHandler += (s, e) => OutLog($"OnAgentEventHandler: nEventType={e.nEventType}, nParam={e.nParam}, strParam={e.strParam}");
            api.OnGetFidData += (s, e) => OutLog($"OnGetFidData: nRequestId={e.nRequestId}, pBlock={e.pBlock}, nBlockLength={e.nBlockLength}");
            api.OnGetRealData += (s, e) => OutLog($"OnGetRealData: strRealName={e.strRealName}, strRealKey={e.strRealKey}, pBlock={e.pBlock}, nBlockLength={e.nBlockLength}");
            api.OnGetTranData += (s, e) => OutLog($"OnGetTranData: nRequestId={e.nRequestId}, pBlock={e.pBlock}, nBlockLength={e.nBlockLength}");

            UserId = Secret.유저아이디;
            Password = Secret.비번;
            CertPass = Secret.공인비번;
        }

        public IList<string> Logs { get; } = new ObservableCollection<string>();
        void OutLog(string message) => Logs.Add(message);

        [ObservableProperty] string _UserId = string.Empty;
        [ObservableProperty] string _Password = string.Empty;
        [ObservableProperty] string _CertPass = string.Empty;
        [RelayCommand] void Clear() => Logs.Clear();

        [RelayCommand]
        void Login()
        {
            api.SetOffAgentMessageBox(1);

            int ret = api.CommInit();
            OutLog($"returned CommInit: {ret}");
            ret = api.CommLogin(UserId, Password, CertPass);
            OutLog($"returned CommLogin: {ret}");
            OutLog($"모듈경로: {api.GetApiAgentModulePath()}");
        }

        [RelayCommand]
        async Task ReqAsync(string content)
        {
            if (api.GetLoginState() != 1)
            {
                OutLog("Not Logined");
                return;
            }

            if (content.Equals("API승인계좌조회"))
            {
                string strTrCode = "MCMAM20016"; // API승인계좌내역조회
                int nReturn = await api.RequestTranAsync(
                    ("InRec1", [            // 블록네임
                    ("divMedia", "D"),      // 메체구분 D:API
                    ("divUser", "H"),       // 유저구분  H:HTS
                    ("htsId", UserId),      // 고객ID
                    ("procTp", "0"),        // 조회구분0:조회1:연속
                    ("nxtKey", ""),         // 연속키
                    ]), strTrCode, "N", "0", "", "9999", "Q", 0,
                    (ov, e) =>
                    {
                        _ = int.TryParse(api.GetTranOutputData(strTrCode, "OutRec1", "Count", 0), out int nRowCnt);
                        OutLog($"API승인계좌개수: {nRowCnt}");
                        for (int nRow = 0; nRow < nRowCnt; nRow++)
                        {
                            string strAPNO = api.GetTranOutputData(strTrCode, "OutRec2", "acntGoods", nRow);    //계좌상품번호	
                            string strCANO = api.GetTranOutputData(strTrCode, "OutRec2", "acntNo", nRow);       //계좌번호
                            OutLog($"계좌{nRow + 1}: {strAPNO}, {strCANO}");
                        }
                    }
                    );
                if (nReturn < 0)
                {
                    OutLog($"RequestTranAsync failed({nReturn}): {api.GetLastErrMsg()}");
                    return;
                }

                OutLog($"returned API승인계좌조회: {nReturn}");
            }
            else if (content.Equals("지수선물리스트"))
            {
                int nReturn = await api.RequestFidArrayAsync([
                    ("9001", "F"),
                    ("GID", "1499"),
                    ], "1,2,3,16", "0", "", "9999", 0,
                    (ov, e) =>
                    {
                        int nRowCnt = api.GetFidOutputRowCnt(e.nRequestId);
                        OutLog($"지수선물리스트: nRowCnt: {nRowCnt}");
                        if (nRowCnt > 0)
                        {
                            var datas = api.ParseFidBlockArray(nRowCnt, e.pBlock);
                            for (int i = 0; i < datas.Length; i++)
                            {
                                OutLog($"{i}: {datas[i][0]}, {datas[i][1]}, {datas[i][2]}, {datas[i][3]}");
                            }
                        }
                    }
                    );
                if (nReturn < 0)
                {
                    OutLog($"RequestFidArrayAsync failed({nReturn}): {api.GetLastErrMsg()}");
                    return;
                }

                OutLog($"returned 지수선물리스트: {nReturn}");
            }
            else if (content.Equals("지수차트요청"))
            {
                List<(double T, double O, double H, double L, double C, double V)> chartDatas = [];
                string code = "101V3000"; // 국내지수 선물코드
                string date = DateTime.Today.ToString("yyyyMMdd");
                int nReturn = await api.RequestFidArrayAsync(
                    [
                    ("9001", "F"),
                    ("9002", code),
                    ("9034", date),
                    ("9035", date),
                    ("9119", "3600"), // 60분봉
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
                    );
                if (nReturn < 0)
                {
                    OutLog($"RequestFidArrayAsync failed({nReturn}): {api.GetLastErrMsg()}");
                    return;
                }

                OutLog($"returned 차트요청: {nReturn}");
                OutLog($"지수차트요청 [{code}]: 데이터개수: {chartDatas.Count}");

                for (int i = 0; i < chartDatas.Count; i++)
                {
                    OutLog($"{i}: {chartDatas[i].T}, {chartDatas[i].O}, {chartDatas[i].H}, {chartDatas[i].L}, {chartDatas[i].C}, {chartDatas[i].V}");
                }
            }
        }
    }
}