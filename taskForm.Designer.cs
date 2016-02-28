namespace uhf_test2
{
    partial class taskForm
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
            this.btnOnce = new System.Windows.Forms.Button();
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
            this.listViewDetail.Location = new System.Drawing.Point(13, 49);
            this.listViewDetail.Name = "listViewDetail";
            this.listViewDetail.Size = new System.Drawing.Size(229, 79);
            this.listViewDetail.TabIndex = 8;
            this.listViewDetail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PC+EPC";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Number";
            this.columnHeader2.Width = 50;
            // 
            // btnOnce
            // 
            this.btnOnce.Location = new System.Drawing.Point(13, 9);
            this.btnOnce.Name = "btnOnce";
            this.btnOnce.Size = new System.Drawing.Size(72, 20);
            this.btnOnce.TabIndex = 5;
            this.btnOnce.Text = "单次寻卡";
            this.btnOnce.Click += new System.EventHandler(this.btnOnce_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(91, 9);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(72, 20);
            this.btnContinue.TabIndex = 6;
            this.btnContinue.Text = "连续寻卡";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(170, 9);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(72, 20);
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
            this.taskFinish.Location = new System.Drawing.Point(81, 156);
            this.taskFinish.Name = "taskFinish";
            this.taskFinish.Size = new System.Drawing.Size(72, 20);
            this.taskFinish.TabIndex = 9;
            this.taskFinish.Text = "清点完成";
            // 
            // taskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(262, 208);
            this.Controls.Add(this.taskFinish);
            this.Controls.Add(this.listViewDetail);
            this.Controls.Add(this.btnOnce);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnStop);
            this.Name = "taskForm";
            this.Text = "盘点界面";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewDetail;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnOnce;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer cTimer;
        private System.Windows.Forms.Button taskFinish;

    }
}

