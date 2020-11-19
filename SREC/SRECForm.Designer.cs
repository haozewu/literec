namespace SREC
{
    partial class SRECForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SRECForm));
            this.InfoLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoText = new System.Windows.Forms.Label();
            this.EncGroup = new System.Windows.Forms.GroupBox();
            this.SelectEncText = new System.Windows.Forms.Label();
            this.EncList = new System.Windows.Forms.ComboBox();
            this.RecGroup = new System.Windows.Forms.GroupBox();
            this.RecButton = new System.Windows.Forms.Button();
            this.InstallPluginButton = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.EncGroup.SuspendLayout();
            this.RecGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InfoLabel.Location = new System.Drawing.Point(78, 120);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(59, 12);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.Text = "初始化...";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "SREC";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(101, 26);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // InfoText
            // 
            this.InfoText.AutoSize = true;
            this.InfoText.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InfoText.Location = new System.Drawing.Point(12, 120);
            this.InfoText.Name = "InfoText";
            this.InfoText.Size = new System.Drawing.Size(65, 12);
            this.InfoText.TabIndex = 2;
            this.InfoText.Text = "当前状态：";
            // 
            // EncGroup
            // 
            this.EncGroup.Controls.Add(this.EncList);
            this.EncGroup.Controls.Add(this.SelectEncText);
            this.EncGroup.Location = new System.Drawing.Point(11, 12);
            this.EncGroup.Name = "EncGroup";
            this.EncGroup.Size = new System.Drawing.Size(250, 45);
            this.EncGroup.TabIndex = 3;
            this.EncGroup.TabStop = false;
            this.EncGroup.Text = "编码器";
            // 
            // SelectEncText
            // 
            this.SelectEncText.AutoSize = true;
            this.SelectEncText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectEncText.Location = new System.Drawing.Point(6, 19);
            this.SelectEncText.Name = "SelectEncText";
            this.SelectEncText.Size = new System.Drawing.Size(80, 17);
            this.SelectEncText.TabIndex = 0;
            this.SelectEncText.Text = "选择编码器：";
            // 
            // EncList
            // 
            this.EncList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncList.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EncList.FormattingEnabled = true;
            this.EncList.ItemHeight = 12;
            this.EncList.Location = new System.Drawing.Point(86, 16);
            this.EncList.Name = "EncList";
            this.EncList.Size = new System.Drawing.Size(157, 20);
            this.EncList.TabIndex = 1;
            this.EncList.SelectedIndexChanged += new System.EventHandler(this.EncList_SelectedIndexChanged);
            // 
            // RecGroup
            // 
            this.RecGroup.Controls.Add(this.InstallPluginButton);
            this.RecGroup.Controls.Add(this.RecButton);
            this.RecGroup.Location = new System.Drawing.Point(11, 60);
            this.RecGroup.Name = "RecGroup";
            this.RecGroup.Size = new System.Drawing.Size(250, 50);
            this.RecGroup.TabIndex = 4;
            this.RecGroup.TabStop = false;
            // 
            // RecButton
            // 
            this.RecButton.Location = new System.Drawing.Point(6, 16);
            this.RecButton.Name = "RecButton";
            this.RecButton.Size = new System.Drawing.Size(147, 23);
            this.RecButton.TabIndex = 0;
            this.RecButton.Text = "录制";
            this.RecButton.UseVisualStyleBackColor = true;
            this.RecButton.Click += new System.EventHandler(this.RecButton_Click);
            // 
            // InstallPluginButton
            // 
            this.InstallPluginButton.Location = new System.Drawing.Point(159, 16);
            this.InstallPluginButton.Name = "InstallPluginButton";
            this.InstallPluginButton.Size = new System.Drawing.Size(85, 23);
            this.InstallPluginButton.TabIndex = 1;
            this.InstallPluginButton.Text = "安装插件";
            this.InstallPluginButton.UseVisualStyleBackColor = true;
            this.InstallPluginButton.Click += new System.EventHandler(this.InstallPluginButton_Click);
            // 
            // SRECForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(272, 141);
            this.Controls.Add(this.RecGroup);
            this.Controls.Add(this.EncGroup);
            this.Controls.Add(this.InfoText);
            this.Controls.Add(this.InfoLabel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "SRECForm";
            this.ShowInTaskbar = false;
            this.Text = "SREC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SRECForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SRECForm_FormClosed);
            this.Load += new System.EventHandler(this.SRECForm_Load);
            this.SizeChanged += new System.EventHandler(this.SRECForm_SizeChanged);
            this.contextMenuStrip.ResumeLayout(false);
            this.EncGroup.ResumeLayout(false);
            this.EncGroup.PerformLayout();
            this.RecGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.Label InfoText;
        private System.Windows.Forms.GroupBox EncGroup;
        private System.Windows.Forms.ComboBox EncList;
        private System.Windows.Forms.Label SelectEncText;
        private System.Windows.Forms.GroupBox RecGroup;
        private System.Windows.Forms.Button InstallPluginButton;
        private System.Windows.Forms.Button RecButton;
    }
}

