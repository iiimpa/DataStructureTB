using Jil;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataStructureTB.Common
{
    /// <summary>
    /// http访问助手
    /// </summary>
    internal static class HttpHelper
    {
        internal static HttpResponseMessage HttpGet(string url)
        {
            return HttpHelper.HttpGetAsync(url).Result;
        }
        internal async static Task<HttpResponseMessage> HttpGetAsync(string url)
        {
            //note:由于winform是单线程程序，必须要配置ConfigureAwait，否则容易造成死锁
            return await new HttpClient().GetAsync(url).ConfigureAwait(false);
        }
        internal static HttpResponseMessage HttpPost(string url, object content)
        {
            return HttpHelper.HttpPostAsync(url, content).Result;
        }
        internal async static Task<HttpResponseMessage> HttpPostAsync(string url, object content)
        {
            //note:由于winform是单线程程序，必须要配置ConfigureAwait，否则容易造成死锁
            string str_content = string.Empty;
            if (content != null)
                str_content = JSON.Serialize(content);

            StringContent rspCnt = new StringContent(str_content, System.Text.Encoding.UTF8, "application/json");
            return await new HttpClient().PostAsync(url, rspCnt).ConfigureAwait(false);
        }
    }
}
