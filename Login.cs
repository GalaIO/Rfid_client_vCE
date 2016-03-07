
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
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textUsername.Text) || string.IsNullOrEmpty(textPassword.Text))
            {
                MessageBox.Show("用户名和密码不正确！！");
                return;
            }
            /*string result = uploadLoginData(textUsername.Text, textPassword.Text);
            if (result == "ERROR:1")
            {
                MessageBox.Show("网络错误，尝试重新登录！");
                return;
            }
            //MessageBox.Show(result);
            string infoLogin = JsonParser.find(result, "message");
            MessageBox.Show(infoLogin);
            if (int.Parse(JsonParser.find(result, "err_code")) == 0)
            {
                MessageBox.Show("登录成功");
                //返回对话框结果
                DialogResult = DialogResult.OK;
                //string list = JsonParser.find(result, "");
                //返回
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败请重新登录");
            }*/
            if (textPassword.Text == "123")
            {
                MessageBox.Show("登录成功");
                //返回对话框结果
                DialogResult = DialogResult.OK;
                string str = "123,456,789,12,45,32,121212,121,21,21";
                Program.taskList = str.Split(str);
                //返回
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败");
            }
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