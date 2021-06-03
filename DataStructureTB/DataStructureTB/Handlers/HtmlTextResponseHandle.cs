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
            this.rsqContent = rsp;
            this.jsDirectror = new ScriptTabDirectror();
            this.htmlBuild = new HtmlTagBuilder();
        }


        private ResponseContent rsqContent; //响应上下文
        private IResponseFilter rspGeneric; //通用的过滤器
        private InputStream dataInput;      //过滤数据输入端
        private ProcessStream dataProcess;  //过滤数据处理
        private OutputStream dataOutput;    //过滤数据输出端
        private ScriptTabDirectror jsDirectror; //组装script标签
        private HtmlTagBuilder htmlBuild;   //html标签生成

        //当前请求的响应是否能够处理
        private bool IsHtmlResposne()
        {
            return "text/html".Equals(this.rsqContent.MimeType, StringComparison.CurrentCultureIgnoreCase);
        }

        
        //注入js脚本操作
        private byte[] InjectionJS(byte[] html)
        {
            string result = Encoding.UTF8.GetString(html);
            string script = null;
            foreach (ResponseFilterConfigItem jsCfg in AppConfigManager.Inst.GetResponseFilterConfigItems())
            {
                int injectionPos = result.IndexOf(jsCfg.InjectionPos);
                if (injectionPos < 0)
                    continue;

                if (jsCfg.InjectionOn == "right")
                    injectionPos += jsCfg.InjectionPos.Length;

                jsDirectror.Construct(jsCfg, htmlBuild);
                script = htmlBuild.Build();
                result = result.Insert(injectionPos, script);
            }

            return Encoding.UTF8.GetBytes(result);
        }



        public bool InitFilter()
        {
            this.rspGeneric = new StreamResponseFilter(new MemoryStream(1024 * 64));

            this.dataInput = new InputStream();
            this.dataOutput = new OutputStream();
            this.dataProcess = new ProcessStream(this.InjectionJS, this.dataOutput);
            this.dataInput.Process = this.dataProcess;

            return this.rspGeneric.InitFilter();
        }
        public FilterStatus Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {
            if (this.IsHtmlResposne())
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
