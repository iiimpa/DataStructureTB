using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureTB.Common
{
    /// <summary>
    /// 提供一个默认的http api 响应结果的处理
    /// </summary>
    internal class DefaultHttpResultHandle : IHttpResultHandle
    {
        public object GetResult(HttpResponseMessage rspMsg)
        {
            return true;
        }
        
        public Task<object> GetResultAsync(Task<HttpResponseMessage> rspMsg)
        {
            return Task.FromResult((object)true);
        }
    }
}
