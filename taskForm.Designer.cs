namespace Rfid_client_vCE
{
    partial class TaskForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem();
            this.listViewDetail = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.cTimer = new System.Windows.Forms.Timer();
            this.taskFinish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewDetail
            // 
            this.listViewDetail.Columns.Add(this.columnHeader1);
            this.listViewDetail.Columns.Add(this.columnHeader2);
            this.listViewDetail.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            listViewItem1.Text = "";
            this.listViewDetail.Items.Add(listViewItem1);
            this.listViewDetail.Location = new System.Drawing.Point(7, 49);
            this.listViewDetail.Name = "listViewDetail";
            this.listViewDetail.Size = new System.Drawing.Size(229, 148);
            this.listViewDetail.TabIndex = 8;
            this.listViewDetail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PC+EPC";
            this.columnHeader1.Width = 179;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Number";
            this.columnHeader2.Width = 50;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(7, 9);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(72, 34);
            this.btnContinue.TabIndex = 6;
            this.btnContinue.Text = "开始盘点";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(85, 9);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(72, 34);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "停止";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // cTimer
            // 
            this.cTimer.Tick += new System.EventHandler(this.cTimer_Tick);
            // 
            // taskFinish
            // 
            this.taskFinish.Location = new System.Drawing.Point(164, 9);
            this.taskFinish.Name = "taskFinish";
            this.taskFinish.Size = new System.Drawing.Size(72, 34);
            this.taskFinish.TabIndex = 9;
            this.taskFinish.Text = "清点完成";
            this.taskFinish.Click += new System.EventHandler(this.taskFinish_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(245, 201);
            this.Controls.Add(this.taskFinish);
            this.Controls.Add(this.listViewDetail);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnStop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskForm";
            this.Text = "盘点界面";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewDetail;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer cTimer;
        private System.Windows.Forms.Button taskFinish;

    }
}

