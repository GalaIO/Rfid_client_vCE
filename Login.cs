
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
//using LitJson;

namespace uhf_test2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            List<string> l = new List<string>();
            l.Add("aaa");
            l.Add("aaa");
            l.Add("aaa");
            //MessageBox.Show(JsonMapper.ToJson(l));
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textUsername.Text) || string.IsNullOrEmpty(textPassword.Text))
            {
                MessageBox.Show("用户名和密码不正确！！");
                return;
            }
            string result = uploadLoginData(textUsername.Text, textPassword.Text);
            if (result == "ERROR:1")
            {
                MessageBox.Show("网络错误，尝试重新登录！");
                return;
            }
            MessageBox.Show(result);
            //返回对话框结果
            DialogResult = DialogResult.OK;
            //返回
            this.Close();
        }
        //上传某数据
        private string uploadLoginData(string username, string password)
        {
            string tmp = "";
            HttpWebRequest req = null;
            try
            {
                req = (HttpWebRequest)WebRequest.Create(HttpConfig.Instance.UrlLogin);
                string data = string.Format("username={0}&password={1}&shop_key={2}", username, password, 4);
                byte[] buffer = Encoding.UTF8.GetBytes(data);

                req.Method = "post";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = buffer.Length;
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();

                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                Stream rspStream = rsp.GetResponseStream();
                StreamReader reader = new StreamReader(rspStream, Encoding.Default);
                tmp = reader.ReadToEnd();
                rspStream.Close();
                rsp.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+e.StackTrace);
                tmp = "ERROR:1";
            }

            //关闭http请求
            req.Abort();

            return tmp;
        }


    }
}