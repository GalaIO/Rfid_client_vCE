
/*
 * Author:  GalaIO
 * Data:    2016-2-28
 * Describe:    The Login page!
 * */
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;
using RfidHandle;
using ScreenHandle;

namespace Rfid_client_vWin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            //ScreenAutoSize.maxForm2Screen(this, 0.4);
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textUsername.Text) || string.IsNullOrEmpty(textPassword.Text))
            {
                MessageBox.Show("请输入用户名和密码！！");
                return;
            }
            //等待网络响应，关闭组件
            textUsername.Enabled = false;
            textPassword.Enabled = false; 
            loginButton.Enabled = false;
            //如果登陆失败直接返回
            if (false == RfidProxy.Instance.login(textUsername.Text, textPassword.Text))
            {
                textUsername.Enabled = true;
                textPassword.Enabled = true;
                loginButton.Enabled = true;
                return;
            }

            //打开硬件
            RfidProxy.Instance.asynOpen();
            //打开定时器，检查硬件开启情况
            checkOpenedTimerThread.Enabled = true;
            checkOpenedTimerThread.Interval = RfidProxy.rfid_opencheck_interval;
        }

        private void checkOpenedTimerThread_Tick(object sender, EventArgs e)
        {
            if (RfidProxy.Instance.checkOpened() == false)
            {
                checkOpenedTimerThread.Enabled = false;
                MessageBox.Show("请检查硬件！");
                return;
            }
            checkOpenedTimerThread.Enabled = false;

            //MessageBox.Show("登录成功");
            //返回对话框结果
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}