using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.IO;
using proxy;
using System.Windows.Forms;
using uhf_test2;

namespace Rfid_client_vCE
{
    public partial class TaskList : Form
    {
        private TaskForm taskForm = null;
        private int currentListIndex = 0;
        public TaskList()
        {
            InitializeComponent();
            //窗口最大化
            Util.maxForm2Screen(this);
        }

        private void taskList_Load(object sender, EventArgs e)
        {
            taskListViewReload();
            //启动新的任务
            taskForm = new TaskForm(this);
            //并隐藏
            taskForm.Hide();
        }
         private int iOld = -1;
        private void taskListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (taskListView.SelectedIndices.Count > 0) //若有选中项 
            {
                if (iOld == -1)
                {
                    taskListView.Items[taskListView.SelectedIndices[0]].BackColor = Color.FromArgb(49, 106, 197); //设置选中项的背景颜色 
                    iOld = taskListView.SelectedIndices[0]; //设置当前选中项索引 
                }
                else
                {
                    if (taskListView.SelectedIndices[0] != iOld)
                    {
                        taskListView.Items[taskListView.SelectedIndices[0]].BackColor = Color.FromArgb(49, 106, 197); //设置选中项的背景颜色 
                        taskListView.Items[iOld].BackColor = Color.FromArgb(255, 255, 255); //恢复默认背景色 
                        iOld = taskListView.SelectedIndices[0]; //设置当前选中项索引 
                    }
                }
                string pk = JsonParser.find(Employee.taskList[iOld], "pk", 0);
                if (taskStart(pk) != "success")
                {
                    MessageBox.Show("网络错误!");
                    return;
                }
                taskForm.taskShow(pk);
                currentListIndex = iOld;
            }
            else //若无选中项 
            {
                iOld = -1; //设置当前处于无选中项状态 
            } 
        }

        private void taskListViewReload()
        {
            taskListView.Clear();
            // 主数据表
            taskListView.Columns.Add("任务ID", 60, HorizontalAlignment.Center);
            taskListView.Columns.Add("柜号", 200, HorizontalAlignment.Center);
            taskListView.Columns.Add("类型", 100, HorizontalAlignment.Center);
            taskListView.Columns.Add("状态", 100, HorizontalAlignment.Center);
            for (int i = 0; i < Employee.taskList.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = JsonParser.find(Employee.taskList[i], "pk", 0);
                item.SubItems.Add(JsonParser.find(Employee.taskList[i], "shelves", 0));
                item.SubItems.Add(JsonParser.find(Employee.taskList[i], "task_type", 0));
                item.SubItems.Add(JsonParser.find(Employee.taskList[i], "status", 0));
                taskListView.Items.Add(item);
            }
            taskListView.Focus();
        }
        private string taskStart(string pk)
        {
            string tmp = "";
            HttpWebRequest req = null;
            try
            {
                req = (HttpWebRequest)WebRequest.Create(HttpConfig.Instance.Host + "/inventory/" + pk + "/start");

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

        public void returnFromTaskShow(bool isFinish)
        {
            if (isFinish)
            {
                //剔除选中的元素
                Employee.taskList.Remove(Employee.taskList[currentListIndex]);
                taskListViewReload();
            }
            this.Show();
        }
    }
}