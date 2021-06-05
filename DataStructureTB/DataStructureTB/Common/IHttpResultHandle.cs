using System.Net.Http;
using System.Threading.Tasks;

namespace DataStructureTB.Common
{
    /// <summary>
    /// 能够对http响应消息进行处理并返回一个执行的结果
    /// </summary>
    /// <typeparam name="T">返回结果的类型</typeparam>
    internal interface IHttpResultHandle
    {
        public object GetResult(HttpResponseMessage rspMsg);
        public Task<object> GetResultAsync(Task<HttpResponseMessage> rspMsg);
    }
}
