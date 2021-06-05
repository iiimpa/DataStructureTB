using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataStructureTB.Common
{
    /// <summary>
    /// http请求管理
    /// </summary>
    internal class HttpRequstManager
    {
        internal HttpRequstManager()
        { }

        /// <summary>
        /// http请求响应发送之后
        /// </summary>
        public event EventHandler Requst;

        internal HttpResponseMessage SendHttpRequst(HttpAccess access)
        {
            return this.SendHttpRequstAsync(access).Result;
        }
        internal Task<HttpResponseMessage> SendHttpRequstAsync(HttpAccess access)
        {
            if (access.UrlArgs != null || access.UrlArgs.Length <= 0)
                access.API.Url = string.Format(access.API.Url, access.UrlArgs);

            if (access.API.IsPost)
            {
                return HttpHelper.HttpPostAsync(access.API.Url, access.Content);
            }
            else
            {
                return HttpHelper.HttpGetAsync(access.API.Url);
            }
        }
    }
}
