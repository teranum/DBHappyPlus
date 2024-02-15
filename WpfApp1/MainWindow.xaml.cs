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
        private readonly AxDBCommAgent _api;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            OutLog("Inited");

            nint Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();
            _api = new(Handle);
            OutLog($"api Created: {_api.Created}");

            _api.OnAgentEventHandler += Api_OnAgentEventHandler;
            _api.OnGetFidData += Api_OnGetFidData;
            _api.OnGetRealData += Api_OnGetRealData;
            _api.OnGetTranData += Api_OnGetTranData;
        }

        private void Api_OnAgentEventHandler(object sender, _DDBCommAgentEvents_OnAgentEventHandlerEvent e)
        {
            OutLog($"OnAgentEventHandler: nEventType={e.nEventType}, nParam={e.nParam}, strParam={e.strParam}");
        }

        private void Api_OnGetFidData(object sender, _DDBCommAgentEvents_OnGetFidDataEvent e)
        {
            OutLog($"OnGetFidData: nRequestId={e.nRequestId}, pBlock={e.pBlock}, nBlockLength={e.nBlockLength}");
        }

        private void Api_OnGetRealData(object sender, _DDBCommAgentEvents_OnGetRealDataEvent e)
        {
            OutLog($"OnGetRealData: strRealName={e.strRealName}, strRealKey={e.strRealKey}, pBlock={e.pBlock}, nBlockLength={e.nBlockLength}");
        }

        private void Api_OnGetTranData(object sender, _DDBCommAgentEvents_OnGetTranDataEvent e)
        {
            OutLog($"OnGetTranData: nRequestId={e.nRequestId}, pBlock={e.pBlock}, nBlockLength={e.nBlockLength}");
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
            _api.SetOffAgentMessageBox(1);

            int ret = _api.CommInit();
            OutLog($"returned CommInit: {ret}");
            ret = _api.CommLogin(UserId, Password, CertPass);
            OutLog($"returned CommLogin: {ret}");
        }

        [RelayCommand]
        void Req(string content)
        {
            if (_api.CommGetConnectState() != 1)
            {
                OutLog("Not connected");
                return;
            }

            if (content.Equals("모듈경로"))
            {
                OutLog($"모듈경로: {_api.GetApiAgentModulePath()}");
            }
        }
    }
}