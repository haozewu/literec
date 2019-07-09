using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using SREC.Properties;
using FFmpegApi;
using GlobalHotKey;

namespace SREC
{
    public partial class SRECForm : Form
    {
        string[] args = null;

        bool isStarting = false;
        bool isRestartOrQuit = false;

        string outputTarget = Application.StartupPath + "/output/";

        public SRECForm()
        {
            InitializeComponent();
        }

        // 以管理员身份启动
        public SRECForm(string[] args)
        {
            this.args = args;

            if (args[0] == "-r32Plugin" && IsAdministrator())
            {
                Regsvr32Plugin.ScreenCaptureRecorder(); // 注册插件
                InitializeComponent();
            }
            else
            {
                isRestartOrQuit = true;
                Application.Exit();
            }
        }

        List<HotKey> hotKeyList = new List<HotKey>(); // 热键列表

        private void SRECForm_Load(object sender, EventArgs e)
        {
            initFFmpeg(); // 初始化FFmpeg

            // 注册热键
            HotKeyManager.Init(Handle);
            hotKeyList.Add(HotKeyManager.Register(Keys.F11, Modifiers.Control, RecStart));
            hotKeyList.Add(HotKeyManager.Register(Keys.F12, Modifiers.Control, RecStop));

            // 初始化菜单选项状态

            CPUToolStripMenuItem.Checked = false;
            QSVToolStripMenuItem.Checked = false;
            NVENCToolStripMenuItem.Checked = false;

            switch (Settings.Default.Codec)
            {
                case "libx264": CPUToolStripMenuItem.Checked = true; break;
                case "h264_qsv": QSVToolStripMenuItem.Checked = true; break;
                case "h264_nvenc": NVENCToolStripMenuItem.Checked = true; break;
                default: break;
            }

            ScreenCaptureRecorderToolStripMenuItem.Checked = (Settings.Default.inputDevice == "dshow");
        }


        WebClient webClient = new WebClient();

        // 初始化FFmpeg
        private void initFFmpeg()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "/ffmpeg/ffmpeg.exe"))
            {
                // 下载FFmpeg
                webClient.DownloadProgressChanged += DownloadProgressCallback;
                webClient.DownloadFileCompleted += DownloadCompletedCallback;
                webClient.DownloadFileAsync(new Uri("https://srec-1251216093.file.myqcloud.com/ffmpeg.zip"), Application.StartupPath + "/ffmpeg.zip");
            }
            else
            {
                infolabel.Text = "准备就绪";
                Application.DoEvents();
            }
        }

        private void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            infolabel.Text = "正在下载FFmpeg组件(" + e.ProgressPercentage + "%)...";
            Application.DoEvents();
        }

        private void DownloadCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            infolabel.Text = "正在解压FFmpeg组件...";
            Application.DoEvents();

            Thread.Sleep(200);
            ZipFile.ExtractToDirectory(Application.StartupPath + "/ffmpeg.zip", Application.StartupPath);
            Thread.Sleep(200);
            File.Delete(Application.StartupPath + "/ffmpeg.zip");

            infolabel.Text = "准备就绪";
            Application.DoEvents();
        }


        // 开始录制
        private void RecStart()
        {
            if (!isStarting)
            {
                Visible = false;
                WindowState = FormWindowState.Minimized;
                Thread.Sleep(500);

                if (!Directory.Exists(Application.StartupPath + "/output")) Directory.CreateDirectory(Application.StartupPath + "/output");

                Record.Start(true, 0, 0, 0, 0, 30, Settings.Default.inputDevice, Settings.Default.inputSource, Settings.Default.Codec, outputTarget);
                isStarting = true;

                infolabel.Text = "正在录制...";
                Application.DoEvents();
            }
        }

        // 停止录制
        private void RecStop()
        {
            if (isStarting)
            {
                Record.Quit();
                isStarting = false;

                Visible = true;
                WindowState = FormWindowState.Normal;
                Activate();

                infolabel.Text = "准备就绪";
                Application.DoEvents();

                if (LiveToolStripMenuItem.Checked) MessageBox.Show("直播已停止！");
                else MessageBox.Show("录制完成！");
            }
        }


        private void SRECForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) Visible = false;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = true;
                WindowState = FormWindowState.Normal;
                Activate();
            }
        }


        private void CPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPUToolStripMenuItem.Checked = true;
            QSVToolStripMenuItem.Checked = false;
            NVENCToolStripMenuItem.Checked = false;
        }

        private void QSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPUToolStripMenuItem.Checked = false;
            QSVToolStripMenuItem.Checked = true;
            NVENCToolStripMenuItem.Checked = false;
        }

        private void NVENCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPUToolStripMenuItem.Checked = false;
            QSVToolStripMenuItem.Checked = false;
            NVENCToolStripMenuItem.Checked = true;
        }

        private void CPUToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (CPUToolStripMenuItem.Checked) Settings.Default.Codec = "libx264";
        }

        private void QSVToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (QSVToolStripMenuItem.Checked) Settings.Default.Codec = "h264_qsv";
        }

        private void NVENCToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (NVENCToolStripMenuItem.Checked) Settings.Default.Codec = "h264_nvenc";
        }


        private void LiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiveToolStripMenuItem.Checked = !LiveToolStripMenuItem.Checked;
        }

        private void LiveToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (LiveToolStripMenuItem.Checked)
            {
                if (LiveAddrToolStripTextBox.Text.Substring(0, 5) == "rtmp:") { outputTarget = LiveAddrToolStripTextBox.Text; }
                else { LiveToolStripMenuItem.Checked = false; MessageBox.Show("请填写正确的推流地址！"); }
            }
            else
            {
                outputTarget = Application.StartupPath + "/output/";
            }
        }


        // 获取管理员权限
        private bool IsAdministrator()
        {
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }


        private void ScreenCaptureRecorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsAdministrator() == false)
            {
                ProcessStartInfo restartApplication = new ProcessStartInfo(Application.ExecutablePath);
                restartApplication.Arguments = "-r32Plugin";
                restartApplication.Verb = "runas";

                try { Process.Start(restartApplication); isRestartOrQuit = true; Application.Exit(); } catch { }
            }
            else
            {
                // 注册ScreenCaptureRecorder插件
                Regsvr32Plugin.ScreenCaptureRecorder();
                ScreenCaptureRecorderToolStripMenuItem.Checked = (Settings.Default.inputDevice == "dshow");
            }
        }


        private bool Exit()
        {
            bool isExit = false;

            if (isRestartOrQuit) isExit = true;
            else isExit = (MessageBox.Show("确认要退出程序吗？", "退出", MessageBoxButtons.OKCancel) == DialogResult.OK);

            if (isExit)
            {
                if (isStarting) Record.Quit();

                Settings.Default.Save();

                try { foreach (var hotKey in hotKeyList) HotKeyManager.Unregister(hotKey); } catch { }
            }

            return isExit;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Exit()) { webClient.Dispose(); Dispose(); Close(); }
        }

        private void SRECForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Exit()) { webClient.Dispose(); Dispose(); Close(); } else e.Cancel = true;
        }

        private void SRECForm_FormClosed(object sender, FormClosedEventArgs e) { }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m); HotKeyManager.ProcessHotKey(ref m);
        }
    }
}
