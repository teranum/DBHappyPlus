using DBOpenApiW.NET;

namespace WinFormsApp_DBOpenApiW
{
    public partial class Form1 : Form
    {
        private readonly AxDBOpenApiW api;
        public Form1()
        {
            InitializeComponent();

            api = new(Handle);
            if (!api.Created)
            {
                OutLog("OpenApi 미설치");
                return;
            }

            OutLog("api Created");
            api.OnDBOAEventConnect += Api_OnDBOAEventConnect;
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
                OutLog("OpenApi 미설치");
                return;
            }

            int ret = api.DBOACommLogin(textBox_userId.Text, textBox_password.Text, textBox_certPwd.Text, 0);
            OutLog($"returned CommLogin: {ret}");
        }

        private void Api_OnDBOAEventConnect(object sender, _DDBOpenApiWEvents_OnDBOAEventConnectEvent e)
        {
            OutLog($"OnDBOAEventConnect: {e.sUserID}, {e.nErrCode}");
        }
    }
}
