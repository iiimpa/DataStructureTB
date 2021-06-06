using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection;

namespace DataStructureTB.Common
{
    /// <summary>
    /// http请求访问管理
    /// </summary>
    internal class HttpAccessManager
    {

        static HttpAccessManager()
        {
            HttpAccessManager.Inst = new HttpAccessManager();
        }

        private HttpAccessManager()
        {
            this.Requst = new HttpRequstManager();
            this.Response = new HttpResponseManager();
        }

        /// <summary>
        /// http请求管理
        /// </summary>
        internal HttpRequstManager Requst { get; private set; }
        /// <summary>
        /// http访问管理
        /// </summary>
        internal HttpResponseManager Response { get; private set; }

        internal static HttpAccessManager Inst { get; }


        internal HttpResult HttpAccess(HttpAccess access)
        {
            HttpResponseMessage rsp = this.Requst.SendHttpRequst(access);
            HttpResult result = this.Response.Receive(access, rsp);
            return result;
        }
        internal HttpResult HttpAccessAsync(HttpAccess access)
        {
            Task<HttpResponseMessage> rsp = this.Requst.SendHttpRequstAsync(access);
            HttpResult result = this.Response.Receive(access, rsp);
            return result;
        }

        internal HttpResult HttpAccess(string apiFieldName, params object[] args)
        {
            HttpAccess access = new HttpAccess();
            access.API = HttpApiManager.GetApiInfo(apiFieldName);
            access.UrlArgs = args;

            HttpResponseMessage rsp = this.Requst.SendHttpRequst(access);
            HttpResult result = this.Response.Receive(access, rsp);
            return result;
        }
        internal HttpResult HttpAccess(string apiFieldName, object content, params object[] args)
        {
            HttpAccess access = new HttpAccess();
            access.API = HttpApiManager.GetApiInfo(apiFieldName);
            access.UrlArgs = args;
            access.Content = content;

            HttpResponseMessage rsp = this.Requst.SendHttpRequst(access);
            HttpResult result = this.Response.Receive(access, rsp);
            return result;
        }

        internal HttpResult HttpAccessAsync(string apiFieldName, params object[] args)
        {
            HttpAccess access = new HttpAccess();
            access.API = HttpApiManager.GetApiInfo(apiFieldName);
            access.UrlArgs = args;

            Task<HttpResponseMessage> rsp = this.Requst.SendHttpRequstAsync(access);
            HttpResult result = this.Response.Receive(access, rsp);
            return result;
        }
        internal HttpResult HttpAccessAsync(string apiFieldName, object content, params object[] args)
        {
            HttpAccess access = new HttpAccess();
            access.API = HttpApiManager.GetApiInfo(apiFieldName);
            access.UrlArgs = args;
            access.Content = content;

            Task<HttpResponseMessage> rsp = this.Requst.SendHttpRequstAsync(access);
            HttpResult result = this.Response.Receive(access, rsp);
            return result;
        }

    }
}
