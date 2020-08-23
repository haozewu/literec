using System;
using System.Diagnostics;
using System.IO;

namespace SREC.FFmpeg
{
    public static class Record
    {
        public static string ffmpeg = Directory.GetCurrentDirectory() + "/ffmpeg/ffmpeg.exe";

        public static Process cmdProcess;

        private static void CmdRun(string fileName, string arguments)
        {
            if (cmdProcess == null) cmdProcess = new Process();

            cmdProcess.StartInfo.FileName = fileName;
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.RedirectStandardInput = true;
            cmdProcess.StartInfo.RedirectStandardOutput = true;
            cmdProcess.StartInfo.RedirectStandardError = false;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.StartInfo.Arguments = arguments;
            cmdProcess.Start();
        }

        public static void Start(string outputTaget)
        {
            Start(true, 0, 0, 0, 0, 30, "gdigrab", "desktop", "libx264", outputTaget);
        }

        public static void Start(bool fullScreen, int x, int y, int w, int h, int framerate, string inputDevice, string inputSource, string codec, string outputTarget)
        {
            if (outputTarget.Substring(0, 5) != "rtmp:")
                outputTarget = "\"" + outputTarget + DateTime.Now.ToString("yyyyMMddHHmmss") + ".mp4" + "\"";
            else
                outputTarget = "-f flv " + outputTarget;

            string arguments;

            if (fullScreen)
                arguments = "-f " + inputDevice + " -framerate " + framerate + " -i " + inputSource + " -c:v " + codec + " " + outputTarget;
            else
                arguments = "-f " + inputDevice + " -framerate " + framerate + " -offset_x " + x + " -offset_y " + y + " -video_size " + w + "x" + h + " -i " + inputSource + " -c:v " + codec + " " + outputTarget;

            CmdRun(ffmpeg, arguments);
        }

        public static void Quit()
        {
            cmdProcess.StandardInput.WriteLine((char)113);
            cmdProcess.StandardInput.Flush();

            if (cmdProcess.WaitForExit(3000)) cmdProcess.Close();
            else cmdProcess.Kill();

            cmdProcess = null;
        }

        public static void Compress(string fileName, int quality, string outputPath)
        {
            if (quality < 0) quality = 0;
            if (quality > 10) quality = 10;

            string arguments = " -i " + fileName + " -c:v libx264 -preset slow -crf " + (quality * 5) + " " + "\"" + outputPath + Path.GetFileNameWithoutExtension(fileName) + "_c.mp4" + "\"";

            CmdRun(ffmpeg, arguments);
            cmdProcess.WaitForExit();
        }
    }
}
