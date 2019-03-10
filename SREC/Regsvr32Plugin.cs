using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using SREC.Properties;

namespace SREC
{
    public class Regsvr32Plugin
    {
        public static Process cmdProcess = null;

        private static bool Regsvr32(string args)
        {
            bool isSuccess = false;

            if (cmdProcess == null) cmdProcess = new Process();

            cmdProcess.StartInfo.FileName = "regsvr32.exe";
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.RedirectStandardInput = true;
            cmdProcess.StartInfo.RedirectStandardOutput = false;
            cmdProcess.StartInfo.RedirectStandardError = false;
            cmdProcess.StartInfo.CreateNoWindow = false;
            cmdProcess.StartInfo.Arguments = args;
            cmdProcess.Start();

            if (cmdProcess.WaitForExit(3000)) { cmdProcess.Close(); isSuccess = true; }
            else { cmdProcess.Kill(); isSuccess = false; }

            cmdProcess = null;

            return isSuccess;
        }

        public static void DownloadPlugin(string address, string fileName)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(address, fileName);
            webClient.Dispose();
        }

        public static void ScreenCaptureRecorder()
        {
            //插件ScreenCaptureRecorder:https://srec-1251216093.cos.ap-shanghai.myqcloud.com/screen-capture-recorder.zip

            string targetPath;

            if (Environment.Is64BitOperatingSystem) targetPath = "C:/Program Files (x86)/screen-capture-recorder";
            else targetPath = "C:/Program Files/screen-capture-recorder";

            //卸载
            if (Settings.Default.inputDevice == "dshow")
            {
                bool audioUnRegSuccess = Regsvr32("/u /s \"" + targetPath + "/audio_sniffer.dll" + "\"");
                bool videoUnRegSuccess = Regsvr32("/u /s \"" + targetPath + "/screen-capture-recorder.dll" + "\"");

                if (audioUnRegSuccess && videoUnRegSuccess)
                {
                    MessageBox.Show("卸载成功！");

                    Settings.Default.inputDevice = "gdigrab";
                    Settings.Default.inputSource = "desktop";
                    Settings.Default.Save();
                }
                else MessageBox.Show("卸载失败！");

                if (Directory.Exists(targetPath)) Directory.Delete(targetPath, true);

                return;
            }

            string pluginPath = Application.StartupPath + "/plugin/screen-capture-recorder";

            //注册
            if (!File.Exists(pluginPath + ".zip")) DownloadPlugin("https://srec-1251216093.cos.ap-shanghai.myqcloud.com/screen-capture-recorder.zip", pluginPath + ".zip");

            Thread.Sleep(200);

            if (!Directory.Exists(pluginPath)) ZipFile.ExtractToDirectory(pluginPath + ".zip", Application.StartupPath + "/plugin");

            Thread.Sleep(200);

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);

                File.Copy(pluginPath + "/audio_sniffer.dll", targetPath + "/audio_sniffer.dll", true);
                File.Copy(pluginPath + "/screen-capture-recorder.dll", targetPath + "/screen-capture-recorder.dll", true);
            }

            bool audioRegSuccess = Regsvr32("/s \"" + targetPath + "/audio_sniffer.dll" + "\"");
            bool videoRegSuccess = Regsvr32("/s \"" + targetPath + "/screen-capture-recorder.dll" + "\"");

            if (audioRegSuccess && videoRegSuccess)
            {
                MessageBox.Show("注册成功！");

                Settings.Default.inputDevice = "dshow";
                Settings.Default.inputSource = "audio=\"virtual-audio-capturer\":video=\"screen-capture-recorder\"";
                Settings.Default.Save();
            }
            else MessageBox.Show("注册失败！");

            Directory.Delete(pluginPath, true);
        }
    }
}
