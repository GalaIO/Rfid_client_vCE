
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
using System.Windows.Forms;
using Setting;
using HTTProxy;
using Json;
using ScreenHandle;
using RfidHandle;

namespace Rfid_client_vWin
{
    public partial class TaskForm : Form
    {
        #region 任务变量

        private bool isFinish = false;

        #endregion

        #region Form相关

        public TaskForm()
        {
            InitializeComponent();
            //ScreenAutoSize.maxForm2Screen(this, 0.4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //初始化组件
            loadControl();

            listViewDetail.Columns[0].Width = listViewDetail.Width;
        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            //保证 rfid关闭
            RfidProxy.Instance.close();
            Application.Exit();
        }
        #endregion

        #region 标签扫描

        private void btnContinue_Click(object sender, EventArgs e)
        {

            if (false == RfidProxy.Instance.scanRfid())
            {
                return;
            }
            btnContinue.Enabled = false;
            btnStop.Enabled = true;
            listViewDetail.Items.Clear();//清空列表
            spCount.Text = "0";
            scanTimerThread.Interval = RfidProxy.rfid_scan_interval;//设置时钟间隔时间，根据实际情况调整大小
            scanTimerThread.Enabled = true;
            uploadTimerThread.Interval = RfidProxy.rfid_report_interval;
            uploadTimerThread.Enabled = true;
        }

        private void cTimer_Tick(object sender, EventArgs e)
        {
            scanTimerThread.Enabled = false;
            //同步线程
            lock (RfidProxy.rfidUpdataMutex)
            {
                if (RfidProxy.rfids == null || RfidProxy.rfids.Count == 0)
                {
                    scanTimerThread.Enabled = true;
                    return;
                }
                /*//更新listview
                for (int i = 0, j = listViewDetail.Items.Count; i < RfidProxy.rfids.Count - listViewDetail.Items.Count; i++, j++)
                {
                    ListViewItem item = new ListViewItem(RfidProxy.rfids[j].epc);
                    listViewDetail.Items.Add(item);
                }
                //更新个数
                spCount.Text = listViewDetail.Items.Count.ToString();*/
                //添加新扫描项
                for (int i = 0; i < RfidProxy.rfids.Count; i++)
                {
                    int j;
                    for (j = 0; j < listViewDetail.Items.Count; j++)
                    {
                        if (listViewDetail.Items[j].Text == RfidProxy.rfids[i].epc)
                        {
                            break;
                        }
                    }
                    if (j >= listViewDetail.Items.Count)
                    {
                        ListViewItem item = new ListViewItem(RfidProxy.rfids[i].epc);
                        listViewDetail.Items.Add(item);
                    }
                }
                //删除超时项
                for (int i = 0; i < listViewDetail.Items.Count; i++)
                {
                    int j;
                    for (j = 0; j < RfidProxy.rfids.Count; j++)
                    {
                        if (RfidProxy.rfids[j].epc == listViewDetail.Items[i].Text)
                        {
                            break;
                        }
                    }
                    if (j >= RfidProxy.rfids.Count)
                    {
                        listViewDetail.Items.Remove(listViewDetail.Items[i]);
                    }
                }
                //更新个数
                spCount.Text = listViewDetail.Items.Count.ToString();
            }
            scanTimerThread.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //停止扫描
            RfidProxy.Instance.stopScanRfid();
            scanTimerThread.Enabled = false;
            uploadTimerThread.Enabled = false;
            btnContinue.Enabled = true;
            btnStop.Enabled = false;
        }
        #endregion

        public void loadControl()
        {
            btnContinue.Enabled = true;
            listViewDetail.Enabled = true;
            btnStop.Enabled = false;
            spCount.Text = "0";


        }

        private void uploadTimerThread_Tick(object sender, EventArgs e)
        {
            uploadTimerThread.Enabled = false;
            if (false == RfidProxy.Instance.uploadRfidData())
            {
                btnStop_Click(sender, e);
            }
            uploadTimerThread.Enabled = true;
        }


    }
}