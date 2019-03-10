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
            this.infolabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CodecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CPUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NVENCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LiveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LiveAddrToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.PluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScreenCaptureRecorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // infolabel
            // 
            this.infolabel.AutoSize = true;
            this.infolabel.Location = new System.Drawing.Point(13, 13);
            this.infolabel.Name = "infolabel";
            this.infolabel.Size = new System.Drawing.Size(53, 17);
            this.infolabel.TabIndex = 1;
            this.infolabel.Text = "初始化...";
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
            this.LiveToolStripMenuItem,
            this.PluginToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 114);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CodecToolStripMenuItem,
            this.LiveSettingsToolStripMenuItem});
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SettingsToolStripMenuItem.Text = "设置";
            // 
            // CodecToolStripMenuItem
            // 
            this.CodecToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CPUToolStripMenuItem,
            this.QSVToolStripMenuItem,
            this.NVENCToolStripMenuItem});
            this.CodecToolStripMenuItem.Name = "CodecToolStripMenuItem";
            this.CodecToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CodecToolStripMenuItem.Text = "编码器";
            // 
            // CPUToolStripMenuItem
            // 
            this.CPUToolStripMenuItem.Name = "CPUToolStripMenuItem";
            this.CPUToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CPUToolStripMenuItem.Text = "CPU";
            this.CPUToolStripMenuItem.CheckedChanged += new System.EventHandler(this.CPUToolStripMenuItem_CheckedChanged);
            this.CPUToolStripMenuItem.Click += new System.EventHandler(this.CPUToolStripMenuItem_Click);
            // 
            // QSVToolStripMenuItem
            // 
            this.QSVToolStripMenuItem.Image = global::SREC.Properties.Resources.intellogo_20px;
            this.QSVToolStripMenuItem.Name = "QSVToolStripMenuItem";
            this.QSVToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.QSVToolStripMenuItem.Text = "QSV";
            this.QSVToolStripMenuItem.CheckedChanged += new System.EventHandler(this.QSVToolStripMenuItem_CheckedChanged);
            this.QSVToolStripMenuItem.Click += new System.EventHandler(this.QSVToolStripMenuItem_Click);
            // 
            // NVENCToolStripMenuItem
            // 
            this.NVENCToolStripMenuItem.Image = global::SREC.Properties.Resources.nvidialogo_20px;
            this.NVENCToolStripMenuItem.Name = "NVENCToolStripMenuItem";
            this.NVENCToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.NVENCToolStripMenuItem.Text = "NVENC";
            this.NVENCToolStripMenuItem.CheckedChanged += new System.EventHandler(this.NVENCToolStripMenuItem_CheckedChanged);
            this.NVENCToolStripMenuItem.Click += new System.EventHandler(this.NVENCToolStripMenuItem_Click);
            // 
            // LiveToolStripMenuItem
            // 
            this.LiveToolStripMenuItem.Name = "LiveToolStripMenuItem";
            this.LiveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.LiveToolStripMenuItem.Text = "直播";
            this.LiveToolStripMenuItem.CheckedChanged += new System.EventHandler(this.LiveToolStripMenuItem_CheckedChanged);
            this.LiveToolStripMenuItem.Click += new System.EventHandler(this.LiveToolStripMenuItem_Click);
            // 
            // LiveSettingsToolStripMenuItem
            // 
            this.LiveSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LiveAddrToolStripTextBox});
            this.LiveSettingsToolStripMenuItem.Name = "LiveSettingsToolStripMenuItem";
            this.LiveSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.LiveSettingsToolStripMenuItem.Text = "直播设置";
            // 
            // LiveAddrToolStripTextBox
            // 
            this.LiveAddrToolStripTextBox.Name = "LiveAddrToolStripTextBox";
            this.LiveAddrToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.LiveAddrToolStripTextBox.Text = "RTMP地址";
            // 
            // PluginToolStripMenuItem
            // 
            this.PluginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScreenCaptureRecorderToolStripMenuItem});
            this.PluginToolStripMenuItem.Name = "PluginToolStripMenuItem";
            this.PluginToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.PluginToolStripMenuItem.Text = "插件";
            // 
            // ScreenCaptureRecorderToolStripMenuItem
            // 
            this.ScreenCaptureRecorderToolStripMenuItem.Name = "ScreenCaptureRecorderToolStripMenuItem";
            this.ScreenCaptureRecorderToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.ScreenCaptureRecorderToolStripMenuItem.Text = "ScreenCaptureRecorder";
            this.ScreenCaptureRecorderToolStripMenuItem.Click += new System.EventHandler(this.ScreenCaptureRecorderToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // SRECForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 41);
            this.Controls.Add(this.infolabel);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infolabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CodecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CPUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NVENCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LiveSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox LiveAddrToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem PluginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScreenCaptureRecorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
    }
}

