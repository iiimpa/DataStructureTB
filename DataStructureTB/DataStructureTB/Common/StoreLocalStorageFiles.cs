using System;
using System.IO;
using DataStructureTB.Model;
using DataStructureTB.Common;
using System.Collections.Generic;
using DataStructureTB.Common.HttpAccessClients;


namespace DataStructureTB.Common
{
    /// <summary>
    /// 下载并存储 订单的local Storage 文件
    /// </summary>
    internal class StoreLocalStorageFiles
    {
        /// <summary>
        /// 返回Local storage 的文件的存储路径
        /// </summary>
        private string GetFullSavePath(string savePath)
        {
            string fullPath = Path.Combine(Path.GetFullPath(savePath), AppConfigManager.Inst.AppConfig.LocalStoragePathEx);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            //返回
            return fullPath;
        }

        internal void DownloadWithStore(string savePath, IEnumerable<OrderItemDetails.OrderFile> apiFiles)
        {
            if (apiFiles == null)
                return;

            OrderItemDetailsHttpAccess download = new OrderItemDetailsHttpAccess();
            Stream downloadStream = null;
            FileStream saveStream = null;

            savePath = this.GetFullSavePath(savePath);
            foreach(OrderItemDetails.OrderFile file in apiFiles)
            {
                //下载
                downloadStream = download.DownloadLocalStorageFile(file.url);

                saveStream = new FileStream(Path.Combine(savePath, file.name), FileMode.Create);

                //保存
                downloadStream.CopyTo(saveStream);
                saveStream.Flush();
                saveStream.Dispose();
                downloadStream.Dispose();
            }
        }
    }
}
