using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;

namespace SREC.FFmpeg
{
    public static class FFmpegFile
    {
        internal delegate void OnProgressCallback(int value);
        internal delegate void OnCompletedCallback();

        private static WebClient webClient = new WebClient();

        private static string basePath = "";
        private static OnProgressCallback onProgressCallback;
        private static OnCompletedCallback onCompletedCallback;

        public static bool Exists()
        {
            return File.Exists(Directory.GetCurrentDirectory() + "/ffmpeg/ffmpeg.exe");
        }

        internal static void Download(string path, OnProgressCallback onProgress, OnCompletedCallback onCompleted)
        {
            basePath = path;

            onProgressCallback = onProgress;
            onCompletedCallback = onCompleted;

            webClient.DownloadProgressChanged += DownloadProgressCallback;
            webClient.DownloadFileCompleted += DownloadCompletedCallback;
            // 这应该是个编码器解码器，但是链接坏掉了，通过跟踪这玩意后续干了啥，然后确定zip里是什么
            //webClient.DownloadFileAsync(new Uri("https://srec-1251216093.file.myqcloud.com/ffmpeg.zip"), basePath + "/ffmpeg.zip");
        }

        private static void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            onProgressCallback(e.ProgressPercentage);
        }

        private static void DownloadCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            Thread.Sleep(300);
            // 直接不用解这个包，反正也没有。
            //ZipFile.ExtractToDirectory(basePath + "/ffmpeg.zip", basePath);
            //Thread.Sleep(300);
            //File.Delete(basePath + "/ffmpeg.zip");

            onCompletedCallback();
        }
    }
}
