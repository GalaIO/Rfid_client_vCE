using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using uhf_test2;

namespace Rfid_client_vCE
{
    public partial class TaskList : Form
    {
        private TaskForm taskForm = null;
        public TaskList()
        {
            InitializeComponent();
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
                //MessageBox.Show(taskListView.SelectedIndices.Count.ToString());
                //MessageBox.Show(taskListView.SelectedIndices[0].ToString());
                //MessageBox.Show(Employee.taskList[iOld]);
                taskForm.taskShow(Employee.taskList[iOld]);
                //剔除选中的元素
                Employee.taskList.Remove(Employee.taskList[iOld]);
                taskListViewReload();
                //关闭当前窗口
                //this.Close();
            }
            else //若无选中项 
            {
                /*
                if(iOld >= 0)
                    taskListView.Items[iOld].BackColor = Color.FromArgb(255, 255, 255); //恢复默认背景色 */
                iOld = -1; //设置当前处于无选中项状态 
            } 
        }

        private void taskListView_ItemActivate(object sender, EventArgs e)
        {
            //MessageBox.Show(taskListView.SelectedIndices.Count.ToString());
        }
        private void taskListViewReload()
        {
            taskListView.Clear();
            // 主数据表
            taskListView.Columns.Add("编号", 40, HorizontalAlignment.Center);
            taskListView.Columns.Add("员工", 40, HorizontalAlignment.Center);
            taskListView.Columns.Add("任务ID", 40, HorizontalAlignment.Center);
            for (int i = 0; i < Employee.taskList.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();
                item.SubItems.Add(Employee.username);
                item.SubItems.Add(Employee.taskList[i]);
                taskListView.Items.Add(item);
            }
            taskListView.Focus();
        }
    }
}