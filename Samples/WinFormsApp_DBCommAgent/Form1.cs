using DBCommAgent.NET;

namespace WinFormsApp_DBCommAgent
{
    public partial class Form1 : Form
    {
        private readonly AxDBCommAgent api;
        public Form1()
        {
            InitializeComponent();

            api = new(Handle);
            if (!api.Created)
            {
                OutLog("OpenApi �̼�ġ");
                return;
            }

            OutLog("api Created");
            api.OnAgentEventHandler += Api_OnAgentEventHandler;
        }

        void OutLog(string message) => listBox_logs.Items.Add(message);

        private void button_clear_Click(object sender, EventArgs e)
        {
            listBox_logs.Items.Clear();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (!api.Created)
            {
                OutLog("OpenApi �̼�ġ");
                return;
            }

            if (api.GetLoginState() == 1)
            {
                OutLog("�̹� �α��� �Ǿ� �ֽ��ϴ�.");
                return;
            }

            int ret = api.CommInit();
            OutLog($"returned CommInit: {ret}");
            ret = api.CommLogin(textBox_userId.Text, textBox_password.Text, textBox_certPwd.Text);
            OutLog($"returned CommLogin: {ret}");
        }

        private void Api_OnAgentEventHandler(object sender, _DDBCommAgentEvents_OnAgentEventHandlerEvent e)
        {
            OutLog($"OnAgentEventHandler: nEventType={e.nEventType}, nParam={e.nParam}, strParam={e.strParam}");
        }
    }
}
