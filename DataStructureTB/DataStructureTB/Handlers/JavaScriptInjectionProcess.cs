using System;
using System.Text;
using DataStructureTB.Common;
using DataStructureTB.Model;
using DataStructureTB.Handlers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataStructureTB.Handlers
{
    /// <summary>
    /// js代码注入处理
    /// </summary>
    internal class JavaScriptInjectionProcess : ProcessStream
    {
        internal JavaScriptInjectionProcess()
        {
            this.jsDirectror = new ScriptTabDirectror();
            this.htmlBuild = new HtmlTagBuilder();

            this.SetProcess(this.Injection);
        }


        private ResponseContent injectEnvir;                    //注入的条件环境，用于验证的当前是否需要注入js
        private HtmlTagBuilder htmlBuild;                       //html标签生成
        private ScriptTabDirectror jsDirectror;                 //组装script标签
        private IEnumerable<ResponseFilterConfigItem> jsCfgs;   //js内容配置

        //js内容注入
        private byte[] Injection(byte[] html)
        {
            if (jsCfgs == null || this.injectEnvir == null)
                return html;

            string script = null;
            string result = Encoding.UTF8.GetString(html);
            foreach (ResponseFilterConfigItem jsCfg in this.jsCfgs)
            {
                //根据url过滤是否需要注入js
                if (jsCfg.HandleUrl == null)
                    continue;
                if (jsCfg.HandleUrl != "*" && !Regex.Match(this.injectEnvir.Url, jsCfg.HandleUrl).Success)
                    continue;

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

        //设置当前注入js的环境
        internal void SetEnviroment(ResponseContent rps)
        {
            this.injectEnvir = rps;
        }

        internal void SetInjectionItem(IEnumerable<ResponseFilterConfigItem> jsConfigs)
        {
            this.jsCfgs = jsConfigs;
        }
    }
}
