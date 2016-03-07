namespace uhf_test2
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(22, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.Text = "密  码";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.Text = "用户名";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(53, 122);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(109, 23);
            this.loginButton.TabIndex = 7;
            this.loginButton.Text = "登录";
            this.loginButton.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(81, 78);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(99, 23);
            this.textPassword.TabIndex = 5;
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(81, 34);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(99, 23);
            this.textUsername.TabIndex = 3;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(212, 193);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUsername);
            this.Name = "Login";
            this.Text = "登录窗口";
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textUsername;
    }
}