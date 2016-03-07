using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rfid_client_vCE
{
    public partial class taskList : Form
    {
        public taskList()
        {
            InitializeComponent();
        }

        private void taskList_Load(object sender, EventArgs e)
        {
            // 主数据表
            listView.Columns.Add("No", 40, HorizontalAlignment.Center);
            listView.Columns.Add("EPC", 260, HorizontalAlignment.Center);
            listView.Columns.Add("Count", 60, HorizontalAlignment.Center);
            listView.Columns.Add("AntNo", 60, HorizontalAlignment.Center);
            listView.Columns.Add("DevNo", 60, HorizontalAlignment.Center);
        }
    }
}