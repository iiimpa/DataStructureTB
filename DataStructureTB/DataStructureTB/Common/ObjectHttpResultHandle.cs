using Jil;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataStructureTB.Common
{
    /// <summary>
    /// 将http api 的响应结果序列化为一个对象
    /// </summary>
    internal class ObjectHttpResultHandle<T> : IHttpResultHandle
    {
        public object GetResult(HttpResponseMessage rspMsg)
        {
            string str = rspMsg.Content.ReadAsStringAsync().Result;
            return JSON.Deserialize<T>(str);
        }

        public Task<object> GetResultAsync(Task<HttpResponseMessage> rspMsg)
        {
            return rspMsg.ContinueWith(rsp => this.GetResult(rsp.Result));
        }
    }
}
