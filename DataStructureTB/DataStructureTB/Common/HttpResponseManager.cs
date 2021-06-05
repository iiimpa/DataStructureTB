using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace DataStructureTB.Common
{
    /// <summary>
    /// http响应管理
    /// </summary>
    internal class HttpResponseManager
    {
        /// <summary>
        /// http请求响应之后
        /// </summary>
        public event EventHandler Response;


        private IHttpResultHandle GetResultHandle(HttpAccess access)
        {
            Type handleType = HttpApiManager.GetApiResultHandleType(access.API.FiledName);
            return Activator.CreateInstance(handleType, true) as IHttpResultHandle;
        }
        private HttpResponseMessage ResponseInvoekOnComplete(Task<HttpResponseMessage> taskRspMsg)
        {
            HttpResponseMessage rsp;

            try
            {
                rsp = taskRspMsg.Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                this.Response?.Invoke(rsp, EventArgs.Empty);
                return rsp;
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }
        }



        internal HttpResult GetResult(HttpAccess access, HttpResponseMessage rspMsg)
        {
            IHttpResultHandle resultHandle = this.GetResultHandle(access);
            HttpResult result = new HttpResultHandler(resultHandle, rspMsg);
            return result;
        }
        internal HttpResult GetResult(HttpAccess access, Task<HttpResponseMessage> rspMsg)
        {
            IHttpResultHandle resultHandle = this.GetResultHandle(access);
            HttpResult result = new HttpResultHandler(resultHandle, rspMsg);
            return result;
        }


        /// <summary>
        /// 表明接收到一个响应，会触发Response事件
        /// </summary>
        internal HttpResult Receive(HttpAccess access, HttpResponseMessage rspMsg)
        {
            HttpResult result = this.GetResult(access, rspMsg);
            this.Response?.Invoke(rspMsg, EventArgs.Empty);
            return result;
        }
        internal HttpResult Receive(HttpAccess access, Task<HttpResponseMessage> taskRspMsg)
        {
            taskRspMsg = taskRspMsg.ContinueWith(this.ResponseInvoekOnComplete);

            return this.GetResult(access, taskRspMsg);
        }



        /// <summary>
        /// 对一个请求的响应做一个获取结果的封装
        /// </summary>
        private class HttpResultHandler : HttpResult
        {
            internal HttpResultHandler(IHttpResultHandle result, HttpResponseMessage rsp) : this(result, Task.FromResult(rsp))
            {
                this.rspComplete = rsp;
                this.Code = rsp.StatusCode;
            }
            internal HttpResultHandler(IHttpResultHandle result, Task<HttpResponseMessage> tskRsp)
            {
                this.resultHandle = result;
                this.tskRsp = tskRsp.ContinueWith(this.TaskComplete);
            }


            private string message;
            private bool badResult;
            private HttpResponseMessage rspComplete;
            private Task<HttpResponseMessage> tskRsp;
            private IHttpResultHandle resultHandle;
            

            internal override bool IsComplete => tskRsp.IsCompleted;


            private HttpResponseMessage TaskComplete(Task<HttpResponseMessage> tsk)
            {
                if (tsk.IsCompleted)
                {
                    this.Code = tsk.Result.StatusCode;
                    this.rspComplete = tsk.Result;
                    return tsk.Result;
                }
                try
                {
                    this.Code = System.Net.HttpStatusCode.BadRequest;
                    this.badResult = true;

                    rspComplete = tsk.Result;//如果task存在异常，那么在这里他会直接抛出
                    //记录异常
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return null;
            }


            internal override T GetResult<T>()
            {
                if(!this.IsComplete)
                    return (T)this.resultHandle.GetResult(this.tskRsp.Result);

                return (T)this.resultHandle.GetResult(this.rspComplete);
            }
        }
    }
}
