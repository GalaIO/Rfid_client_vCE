namespace Rfid_client_vCE
{
    partial class taskList
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.taskListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // taskListView
            // 
            this.taskListView.Location = new System.Drawing.Point(13, 10);
            this.taskListView.Name = "taskListView";
            this.taskListView.Size = new System.Drawing.Size(185, 144);
            this.taskListView.TabIndex = 0;
            // 
            // taskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(217, 157);
            this.Controls.Add(this.taskListView);
            this.Menu = this.mainMenu1;
            this.Name = "taskList";
            this.Text = "任务列表";
            this.Load += new System.EventHandler(this.taskList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView taskListView;
    }
}