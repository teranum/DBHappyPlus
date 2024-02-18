namespace WinFormsApp_DBOpenApiW
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox_userId = new TextBox();
            textBox_password = new TextBox();
            textBox_certPwd = new TextBox();
            button_login = new Button();
            listBox_logs = new ListBox();
            button_clear = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox_userId
            // 
            textBox_userId.Location = new Point(57, 6);
            textBox_userId.Name = "textBox_userId";
            textBox_userId.Size = new Size(100, 23);
            textBox_userId.TabIndex = 7;
            // 
            // textBox_password
            // 
            textBox_password.Location = new Point(208, 6);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(100, 23);
            textBox_password.TabIndex = 8;
            // 
            // textBox_certPwd
            // 
            textBox_certPwd.Location = new Point(367, 6);
            textBox_certPwd.Name = "textBox_certPwd";
            textBox_certPwd.Size = new Size(100, 23);
            textBox_certPwd.TabIndex = 9;
            // 
            // button_login
            // 
            button_login.Location = new Point(12, 35);
            button_login.Name = "button_login";
            button_login.Size = new Size(75, 23);
            button_login.TabIndex = 11;
            button_login.Text = "로그인";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // listBox_logs
            // 
            listBox_logs.FormattingEnabled = true;
            listBox_logs.ItemHeight = 15;
            listBox_logs.Location = new Point(12, 64);
            listBox_logs.Name = "listBox_logs";
            listBox_logs.Size = new Size(460, 289);
            listBox_logs.TabIndex = 15;
            // 
            // button_clear
            // 
            button_clear.Location = new Point(392, 35);
            button_clear.Name = "button_clear";
            button_clear.Size = new Size(75, 23);
            button_clear.TabIndex = 12;
            button_clear.Text = "지우기";
            button_clear.UseVisualStyleBackColor = true;
            button_clear.Click += button_clear_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 9);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 4;
            label3.Text = "CertPwd";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(163, 9);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 5;
            label2.Text = "Pwd";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 6;
            label1.Text = "UserID";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(textBox_userId);
            Controls.Add(textBox_password);
            Controls.Add(textBox_certPwd);
            Controls.Add(button_login);
            Controls.Add(listBox_logs);
            Controls.Add(button_clear);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DBOpenApiW Sample";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_userId;
        private TextBox textBox_password;
        private TextBox textBox_certPwd;
        private Button button_login;
        private ListBox listBox_logs;
        private Button button_clear;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
