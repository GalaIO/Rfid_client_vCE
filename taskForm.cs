
/*
 * Author:  GalaIO
 * Data:    2016-2-28
 * Describe:    The TaskForm page!
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

namespace Rfid_client_vCE
{
    public partial class TaskForm : Form
    {
        #region 任务变量

        private JsonGen gen = new JsonGen(new char[3000], 3000);
        private string taskID = null;
        private bool isFinish = false;
        private Form parent;
        #endregion

        #region Form相关

        public TaskForm(Form parent)
        {
            InitializeComponent();
            //窗口最大化
            Util.maxForm2Screen(this);
            this.parent = parent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Uhf.RfidOpen() == 0)
            {
                Uhf.MessageBeep(SoundType.MB_ICONERROR);//发出声音
                //发出警告
                MessageBox.Show("打开设备失败!请检查硬件！");
                taskHide(false);
            }

            //初始化组件
            btnStop.Enabled = false;
            /*
            //获取功率与协议
            this.getPower();
            this.getProtocol();*/
        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            //保证 rfid关闭
            Uhf.RfidClose();
            Application.Exit();
        }
        #endregion

        #region 标签扫描

        private void btnContinue_Click(object sender, EventArgs e)
        {

            btnContinue.Enabled = false;
            btnStop.Enabled = true;
            listViewDetail.Items.Clear();//清空列表
            if (Uhf.RfidInventoryStart() == 0)
            {
                Uhf.MessageBeep(SoundType.MB_ICONWARNING);//发出声音
                MessageBox.Show("开始寻标签失败！");
                return;
            }
            cTimer.Interval = 1000;//设置时钟间隔时间，根据实际情况调整大小
            cTimer.Enabled = true;
        }

        private void cTimer_Tick(object sender, EventArgs e)
        {
            cTimer.Enabled = false;
            int count = Uhf.RfidGetTagIDCount();
            List<EPC> list = Uhf.RfidGetTagIDs(count);//count为能容纳EPC结构的最大个数
            if (list == null || list.Count == 0)
            {
                cTimer.Enabled = true;
                return;
            }
            foreach (EPC epc in list)
            {
                showList(epc, false);
            }
            //上传数据
            string reqTmp = genRfidsJson(gen, this.taskID, list);
            if (false == this.uploadRfidData(this.taskID, reqTmp))
            {
                MessageBox.Show("网络错误！");
                this.btnStop_Click(sender, e);
                return;
            }
            cTimer.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            if (Uhf.RfidInventoryStop() == 0)
            {
                Uhf.MessageBeep(SoundType.MB_ICONWARNING);//发出声音
                MessageBox.Show("停止连续寻标失败！");
            }
            cTimer.Enabled = false;
            btnContinue.Enabled = true;
            btnStop.Enabled = false;
        }
        #endregion

        #region 列表控制相关

        /// <summary>
        ///显示寻标信息
        /// </summary>
        /// <param name="pepc">标签结构体变量</param>
        /// <param name="isOnce">判断是否为单次寻标</param>
        private void showList(EPC pepc, bool isOnce)
        {
            string id = pepc.id;
            int count = pepc.count;
            if (id.Length > 4)
            {
                id = id.Substring(4, id.Length-4);//为了区分前4位，加入空格
            }

            ListViewItem item = getListViewItem(id);//查看该卡ID信息是否存在，不存在返回null
            if (item == null)//该id 不存在则新增
            {
                item = new ListViewItem(id);
                item.SubItems.Add(count.ToString());
                listViewDetail.Items.Add(item);
                Uhf.MessageBeep(SoundType.MB_OK);//发出声音
            }
            else
            {
                if (isOnce)
                {
                    int temp = Convert.ToInt32(item.SubItems[1].Text);
                    item.SubItems[1].Text = (temp + count).ToString();//单次寻卡，在之前的基础上累加
                    Uhf.MessageBeep(SoundType.MB_OK);//发出声音
                }
                else
                {
                    if (item.SubItems[1].Text != count.ToString())
                    {
                        item.SubItems[1].Text = count.ToString();
                        Uhf.MessageBeep(SoundType.MB_OK);//发出声音
                    }
                }
            }
            //更新列表第一列标题，统计获取到的总标签数
            listViewDetail.Columns[0].Text = string.Format("PC+EPC: {0}", listViewDetail.Items.Count);
        }
        //判断标签是否已存在列表中签id
        private ListViewItem getListViewItem(string id)
        {
            if (listViewDetail.Items.Count == 0)
            {
                return null;
            }

            foreach (ListViewItem item in listViewDetail.Items)
            {
                if (item.Text == id)
                {
                    return item;
                }
            }
            return null;
        }

        private void listViewDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region 工具集

        private void addLogText(string log)
        {
            //logView.Text = logView.Text + log + "\r\n";

        }
        //获取协议模式
        private int getProtocol()
        {
            int mode = 0;
            return Uhf.RfidGetMode(ref mode);
            
        } 
        //获取功率
        private int getPower()
        {
            int readPower=25;
            int writePower=25;
            //获取读和写的频率值
            if (Uhf.RfidGetPower(ref readPower, ref writePower) == 0)
            {
                return -1;
            }
            else
            {
                Uhf.MessageBeep(SoundType.MB_ICONWARNING);//发出声音
                return readPower;
            }
        }

        //上传某数据
        private bool uploadRfidData(string pk, string data)
        {
            bool tmp = true;
            HttpWebRequest req = null;
            try
            {
                req = (HttpWebRequest)WebRequest.Create(HttpConfig.Instance.Host + "/inventory/" + pk + "/scan");
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int senLen = buffer.Length-1;
                req.Method = "post";
                req.ContentType = "application/json";
                req.ContentLength = senLen;
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(buffer, 0, senLen);
                reqStream.Close();

                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                Stream rspStream = rsp.GetResponseStream();
                StreamReader reader = new StreamReader(rspStream, Encoding.Default);
                //响应消息直接抛弃
                string resultFromRemote = reader.ReadToEnd();
                //Console.WriteLine(resultFromRemote);
                rsp.Close();
                rspStream.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.GetType().ToString()+e.Message+e.StackTrace);
                tmp = false;
            }

            //关闭http请求
            req.Abort();

            return tmp;
        }
        //生成数据字段
        private string genRfidsJson(JsonGen gen, string taskId, List<EPC> rfids)
        {
            gen.resetJson();
            gen.startJson();

            foreach (EPC epc in rfids)
            {
                gen.addStringToArray(epc.id.Substring(4, epc.id.Length-4));
            }
            gen.endJson();
            char[] tt = gen.toJson().ToCharArray();
            tt[0] = '[';
            tt[tt.Length-2] = ']';
            return new string(tt);
        }

        #endregion

        private void taskFinish_Click(object sender, EventArgs e)
        {
            if (taskStop(this.taskID) != "success")
            {
                MessageBox.Show("网络错误!");
                return;
            }
            taskHide(true);
        }
        public void taskHide(bool isFinish)
        {
            this.Hide();
            //显示父窗口
            TaskList tl = (TaskList)this.parent;
            tl.returnFromTaskShow(isFinish);
        }
        public void taskShow(string taskID)
        {
            //隐藏父窗口
            this.parent.Hide();
            listViewDetail.Items.Clear();//清空列表
            this.taskID = taskID;
            this.Show();
        }

        private string taskStop(string pk)
        {
            string tmp = "";
            HttpWebRequest req = null;
            try
            {
                req = (HttpWebRequest)WebRequest.Create(HttpConfig.Instance.Host + "/inventory/" + pk + "/stop");

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