using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataStructureTB.Handlers
{
    class DownloadHandler : IDownloadHandler
    {
        public void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            //设置保存路径
            string dirPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            downloadItem.SuggestedFileName = !string.IsNullOrWhiteSpace(downloadItem.SuggestedFileName) ? downloadItem.SuggestedFileName : "数据导出.xlsx";
            downloadItem.FullPath = Path.Combine(dirPath, downloadItem.SuggestedFileName);

            //true，弹出保存对话框
            callback.Continue(downloadItem.FullPath, true);
        }

        public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            if (downloadItem.ReceivedBytes >= downloadItem.TotalBytes || callback.IsDisposed)
            {
                return;
            }
            //未下在完成，继续
            callback.Resume();
        }
    }
}
