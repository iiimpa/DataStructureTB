using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DataStructureTB.Common;

namespace DataStructureTB.Common
{
    /// <summary>
    /// http 响应结果当作数据流处理
    /// </summary>
    internal class StreamHttpResultHandle : IHttpResultHandle
    {
        public object GetResult(HttpResponseMessage rspMsg)
        {
            return rspMsg.Content.ReadAsStreamAsync().Result;
        }

        public Task<object> GetResultAsync(Task<HttpResponseMessage> rspMsg)
        {
            return rspMsg.ContinueWith(tsk => this.GetResult(tsk.Result));
        }
    }
}
