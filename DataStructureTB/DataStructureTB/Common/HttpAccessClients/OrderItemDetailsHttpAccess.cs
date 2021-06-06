using System;
using System.IO;
using DataStructureTB.Model;

namespace DataStructureTB.Common.HttpAccessClients
{
    /// <summary>
    /// 订单项详情获取接口调用
    /// </summary>
    internal class OrderItemDetailsHttpAccess : ClientHttpAccessBase
    {
        internal OrderItemDetails GetOrderItemDetails(int order_id)
        {
            try
            {
                HttpResult result = HttpAccessManager.Inst.HttpAccess(nameof(HttpApiConfig.OrderDetails), new { order_id });
                return this.HttpProcess<OrderItemDetails>(result);
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }
            return null;
        }


        /// <summary>
        /// 下载local storage 文件
        /// </summary>
        internal Stream DownloadLocalStorageFile(string downloadUrl)
        {
            try
            {
                HttpAccess access = new HttpAccess()
                {
                    API = new UrlInfo
                    {
                         Url = downloadUrl,
                         IsPost = false
                    },
                    ResultHandle = new StreamHttpResultHandle(),
                };

                HttpResult result = HttpAccessManager.Inst.HttpAccess(access);
                return this.HttpProcess<Stream>(result);
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }
            return null;
        }

    }
}
