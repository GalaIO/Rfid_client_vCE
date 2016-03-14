
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
using RFID.UHF;
using proxy;
using Rfid_client_vCE;

namespace uhf_test2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            //窗口最大化
            Util.maxForm2Screen(this);
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textUsername.Text) || string.IsNullOrEmpty(textPassword.Text))
            {
                MessageBox.Show("请输入用户名和密码！！");
                return;
            }
            //存储 员工信息
            Employee.username = textUsername.Text;
            Employee.userpasswd = textPassword.Text;
            string result = uploadLoginData(textUsername.Text, textPassword.Text);
            if (result == "ERROR:1")
            {
                MessageBox.Show("网络错误，尝试重新登录！");
                return;
            }
            string taskListInfo = JsonParser.findNextArray(result, null, 0);
            if (taskListInfo == null)
            {
                MessageBox.Show(result);
                return;
            }
            MessageBox.Show("登录成功");
            int off = 0;
            for (string tmp = JsonParser.findNextObj(taskListInfo, null, off); tmp != null; )
            {
                off += tmp.Length;
                Employee.taskList.Add(tmp);
                tmp = JsonParser.findNextObj(taskListInfo, null, off);
            }
            //返回对话框结果
            DialogResult = DialogResult.OK;
            this.Close();
        }
        //上传某数据
        private string uploadLoginData(string username, string password)
        {
            string tmp = "";
            HttpWebRequest req = null;
            try
            {
                string data = string.Format("username={0}&password={1}", username, password);
                req = (HttpWebRequest)WebRequest.Create(HttpConfig.Instance.UrlLogin+"?"+data);

                req.Method = "get";
                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                Stream rspStream = rsp.GetResponseStream();
                StreamReader reader = new StreamReader(rspStream, Encoding.GetEncoding("utf-8"));
                tmp = reader.ReadToEnd();
                rspStream.Close();
                rsp.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message+e.StackTrace);
                tmp = "ERROR:1";
            }

            //关闭http请求
            req.Abort();

            return tmp;
        }


    }
}