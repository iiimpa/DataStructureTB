using Jil;
using System;
using CefSharp;
using System.IO;
using System.Text;
using DataStructureTB.Model;
using CefSharp.ResponseFilter;
using System.Collections.Generic;

namespace DataStructureTB.Handlers 
{
    /// <summary>
    /// 通用请求响应的过滤处理
    /// </summary>
    internal class GenericResponseHandle : IResponseFilter
    {
        public GenericResponseHandle(ResponseContent rsp)
        {
            this.rsqContent = rsp;
        }


        //响应上下文
        private ResponseContent rsqContent;
        //通用的过滤器
        private IResponseFilter rspGeneric;


        //当前请求的响应是否能够处理
        private bool CanHandle()
        {
            return "text/html".Equals(this.rsqContent.MimeType, StringComparison.CurrentCultureIgnoreCase);
        }


        public bool InitFilter()
        {
            this.rspGeneric = new StreamResponseFilter(new MemoryStream(1024 * 64));
            return this.rspGeneric.InitFilter();
        }

        public FilterStatus Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {
            bool a = this.CanHandle();
            return this.rspGeneric.Filter(dataIn, out dataInRead, dataOut, out dataOutWritten);
        }
        public void Dispose()
        {
            this.rspGeneric.Dispose();
        }
    }
}
