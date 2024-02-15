using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DBOpenApiW.NET;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Interop;

namespace Wpf86
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ObservableObject]
    public partial class MainWindow : Window
    {
        private readonly AxDBOpenApiW _api;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            OutLog("Inited");

            nint Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();
            _api = new(Handle);
            OutLog($"api Created: {_api.Created}");

            //_api.SetMultipleUser(0);

            _api.OnDBOAReceiveTrData += Api_OnDBOAReceiveTrData;
            _api.OnDBOAReceiveRealData += Api_OnDBOAReceiveRealData;
            _api.OnDBOAReceiveMsg += Api_OnDBOAReceiveMsg;
            _api.OnDBOAReceiveChejanData += Api_OnDBOAReceiveChejanData;
            _api.OnDBOAEventNotify += Api_OnDBOAEventNotify;
            _api.OnDBOAEventExtended += Api_OnDBOAEventExtended;
            _api.OnDBOAEventConnect += Api_OnDBOAEventConnect;

        }

        private void Api_OnDBOAReceiveTrData(object sender, _DDBOpenApiWEvents_OnDBOAReceiveTrDataEvent e)
        {
            OutLog($"OnDBOAReceiveTrData: {e.sUserID}, {e.sRQName}, {e.sTrCode}");
        }

        private void Api_OnDBOAReceiveRealData(object sender, _DDBOpenApiWEvents_OnDBOAReceiveRealDataEvent e)
        {
            OutLog($"OnDBOAReceiveRealData: {e.sUserID}, {e.sJongmokCode}, {e.sRealType}, {e.sRealData}");
        }

        private void Api_OnDBOAReceiveMsg(object sender, _DDBOpenApiWEvents_OnDBOAReceiveMsgEvent e)
        {
            OutLog($"OnDBOAReceiveMsg: {e.sUserID}, {e.sRQName}, {e.sTrCode}, {e.sMsg}");
        }

        private void Api_OnDBOAReceiveChejanData(object sender, _DDBOpenApiWEvents_OnDBOAReceiveChejanDataEvent e)
        {
            OutLog($"OnDBOAReceiveChejanData: {e.sUserID}, {e.sGubun}, {e.sFidList}");
        }

        private void Api_OnDBOAEventNotify(object sender, _DDBOpenApiWEvents_OnDBOAEventNotifyEvent e)
        {
            OutLog($"OnDBOAEventNotify: {e.sUserID}, {e.sNotifyType}, {e.sData}");
        }

        private void Api_OnDBOAEventExtended(object sender, _DDBOpenApiWEvents_OnDBOAEventExtendedEvent e)
        {
            OutLog($"OnDBOAEventExtended: {e.sUserID}, {e.nEventType}, {e.sData}");
        }

        private void Api_OnDBOAEventConnect(object sender, _DDBOpenApiWEvents_OnDBOAEventConnectEvent e)
        {
            OutLog($"OnDBOAEventConnect: {e.sUserID}, {e.nErrCode}");
        }

        [ObservableProperty] string _UserId = string.Empty;
        [ObservableProperty] string _Password = string.Empty;
        [ObservableProperty] string _CertPass = string.Empty;
        [RelayCommand] void Clear() => Logs.Clear();

        [RelayCommand]
        void Login()
        {
            int ret = _api.DBOACommLogin(UserId, Password, CertPass, 1);

            OutLog($"returned DBOACommConnect: {ret}");
        }

        public IList<string> Logs { get; } = new ObservableCollection<string>();
        void OutLog(string message) => Logs.Add(message);

        [RelayCommand]
        async Task ReqAsync(string content)
        {
            if (_api.DBOAGetConnectState(UserId) != 1)
            {
                OutLog("Not connected");
                return;
            }

            if (content.Equals("시장종목"))
            {
                OutLog($"DBOAGetAPIModulePath: {_api.DBOAGetAPIModulePath()}");

                OutLog($"DBOAGetGlobalFutureItemlist: {_api.DBOAGetGlobalFutureItemlist()}");

                OutLog($"DBOAGetGlobalOptionItemlist: {_api.DBOAGetGlobalOptionItemlist()}");
            }
            else if (content.Equals("차트요청"))
            {
                // 차트데이터 연속조회, 30분봉 종가 받을수 있을때까지 반복
                List<string> price_list = []; // 종가 리스트
                string sPreNext = string.Empty;
                do
                {
                    _api.DBOASetInputValue(UserId, "종목코드", "HSIG24");
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
                        OutLog($"returned DBOAGetCommData: {result}");
                        break; // 요청 오류시 중단
                    }

                    OutLog($"Data received: {price_list.Count}");
                    await Task.Delay(1000); // 1초간 지연... 데이터 요청수 많을시 서버차단 가능성 있음, 지연시간 조절 필요
                } while (sPreNext.Length > 0);

                OutLog($"all Data received: {price_list.Count}");
                //Logs.Concat(price_list);
            }
        }
    }
}