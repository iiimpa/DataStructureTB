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


        private ResponseContent rsqContent; //响应上下文
        private IResponseFilter rspGeneric; //通用的过滤器
        private InputStream dataInput;      //过滤数据输入端
        private ProcessStream dataProcess;  //过滤数据处理
        private OutputStream dataOutput;    //过滤数据输出端


        //当前请求的响应是否能够处理
        private bool CanHandle()
        {
            return "text/html".Equals(this.rsqContent.MimeType, StringComparison.CurrentCultureIgnoreCase);
        }


        public bool InitFilter()
        {
            this.rspGeneric = new StreamResponseFilter(new MemoryStream(1024 * 64));

            this.dataInput = new InputStream();
            this.dataOutput = new OutputStream();
            this.dataProcess = new ProcessStream(bs => bs, this.dataOutput);
            this.dataInput.Process = this.dataProcess;

            return this.rspGeneric.InitFilter();
        }
        public FilterStatus Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {
            if (this.CanHandle())
            {
                dataInRead = this.dataInput.Input(dataIn);
                dataOutWritten = this.dataOutput.Output(dataOut);

                //如果数据没有全部输出，则还需要处理
                return this.dataOutput.ReceiveCount != this.dataOutput.OutputCount ? FilterStatus.NeedMoreData : FilterStatus.Done;
            }
            else
            {
                return this.rspGeneric.Filter(dataIn, out dataInRead, dataOut, out dataOutWritten);
            }
        }
        public void Dispose()
        {
            this.rspGeneric.Dispose();
        }
    }
}
