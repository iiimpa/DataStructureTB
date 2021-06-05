using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureTB.Common
{
    /// <summary>
    /// 将http api 的响应结果作为字符串并返回
    /// </summary>
    internal class StringHttpResultHandle : IHttpResultHandle
    {
        public object GetResult(HttpResponseMessage rspMsg)
        {
            return rspMsg.Content.ReadAsStringAsync().Result;
        }
        public Task<object> GetResultAsync(Task<HttpResponseMessage> rspMsg)
        {
            return rspMsg.ContinueWith(rsp => this.GetResult(rsp.Result));
        }
    }
}
