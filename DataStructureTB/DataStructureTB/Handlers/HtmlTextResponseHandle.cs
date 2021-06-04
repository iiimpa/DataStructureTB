using Jil;
using System;
using CefSharp;
using System.IO;
using System.Text;
using DataStructureTB.Model;
using DataStructureTB.Common;
using CefSharp.ResponseFilter;
using System.Collections.Generic;

namespace DataStructureTB.Handlers 
{
    /// <summary>
    /// 通用请求响应的过滤处理
    /// </summary>
    internal class HtmlTextResponseHandle : IResponseFilter
    {
        public HtmlTextResponseHandle(ResponseContent rsp)
        {
            this.rspContent = rsp;
        }


        private ResponseContent rspContent; //响应上下文
        private IResponseFilter rspGeneric; //通用的过滤器
        private InputStream dataInput;      //过滤数据输入端
        private ProcessStream jsInjectProcess;  //过滤数据处理
        private OutputStream dataOutput;    //过滤数据输出端

        //当前请求的响应是否为 'text/html'
        private bool IsHtmlMimeRespone()
        {
            string htmlMime = "text/html";
            return htmlMime.Equals(this.rspContent.MimeType, StringComparison.CurrentCultureIgnoreCase);
        }


        public bool InitFilter()
        {
            this.rspGeneric = new StreamResponseFilter(new MemoryStream(1024 * 64));

            this.dataInput = new InputStream();
            this.dataOutput = new OutputStream();
            this.jsInjectProcess = new JavaScriptInjectionProcess();

            this.dataInput.Process = this.jsInjectProcess;
            this.jsInjectProcess.SetOutput(this.dataOutput);
            (this.jsInjectProcess as JavaScriptInjectionProcess).SetEnviroment(this.rspContent);
            (this.jsInjectProcess as JavaScriptInjectionProcess).SetInjectionItem(AppConfigManager.Inst.GetResponseFilterConfigItems());

            return this.rspGeneric.InitFilter();
        }
        public FilterStatus Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {
            if (this.IsHtmlMimeRespone())
            {
                //输入数据处理
                dataInRead = this.dataInput.Input(dataIn);
                //输出处理的数据
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
