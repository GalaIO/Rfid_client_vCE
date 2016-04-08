
using RfidHandle;
namespace Rfid_client_vWin
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
            //关闭非托管资源
            RfidProxy.Instance.close();
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
            this.listViewDetail = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.scanTimerThread = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.spCount = new System.Windows.Forms.Label();
            this.uploadTimerThread = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listViewDetail
            // 
            this.listViewDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewDetail.Font = new System.Drawing.Font("Tahoma", 8F);
            this.listViewDetail.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewDetail.Location = new System.Drawing.Point(7, 49);
            this.listViewDetail.Name = "listViewDetail";
            this.listViewDetail.Size = new System.Drawing.Size(229, 148);
            this.listViewDetail.TabIndex = 8;
            this.listViewDetail.UseCompatibleStateImageBehavior = false;
            this.listViewDetail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "RFID";
            this.columnHeader1.Width = 179;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(7, 9);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(99, 34);
            this.btnContinue.TabIndex = 6;
            this.btnContinue.Text = "开始监控";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(130, 9);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(103, 34);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "停止";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // scanTimerThread
            // 
            this.scanTimerThread.Tick += new System.EventHandler(this.cTimer_Tick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "标签数量：";
            // 
            // spCount
            // 
            this.spCount.Location = new System.Drawing.Point(85, 204);
            this.spCount.Name = "spCount";
            this.spCount.Size = new System.Drawing.Size(46, 20);
            this.spCount.TabIndex = 0;
            this.spCount.Text = "0";
            // 
            // uploadTimerThread
            // 
            this.uploadTimerThread.Tick += new System.EventHandler(this.uploadTimerThread_Tick);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(245, 234);
            this.Controls.Add(this.spCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewDetail);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnStop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskForm";
            this.Text = "监控界面";
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewDetail;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer scanTimerThread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label spCount;
        private System.Windows.Forms.Timer uploadTimerThread;

    }
}

