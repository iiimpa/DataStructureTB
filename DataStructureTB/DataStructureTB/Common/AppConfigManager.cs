﻿using Jil;
using System;
using System.IO;
using DataStructureTB.Model;
using System.Collections.Generic;

namespace DataStructureTB.Common
{
    /// <summary>
    /// 程序配置管理类
    /// </summary>
    internal class AppConfigManager
    {
        static AppConfigManager()
        {
            AppConfigManager.Inst = new AppConfigManager();
        }

        private AppConfigManager()
        {
            string appConfigContent = File.ReadAllText("./Resource/AppConfig.json");
            this.AppConfig = string.IsNullOrWhiteSpace(appConfigContent) ?
                new AppConfigModel() :
                JSON.Deserialize<AppConfigModel>(appConfigContent);
        }

        internal static AppConfigManager Inst { get; }

        /// <summary>
        /// 程序配置
        /// </summary>
        internal AppConfigModel AppConfig { get; private set; }


        /// <summary>
        /// 返回过滤脚本js的配置集合
        /// </summary>
        internal IEnumerable<ResponseFilterConfigItem> GetResponseFilterConfigItems()
        {
            if (this.AppConfig?.JavaScripts == null)
                yield break;

            foreach (JavaScriptMode js in this.AppConfig.JavaScripts)
            {
                yield return new ResponseFilterConfigItem()
                {
                    InjectionPos = js.InjectionPos,
                    InjectionOn = js.InjectionOn,
                    HandleUrl = js.HandleUrl,
                    Src = js.Src,
                    Path = js.Path,
                    Tag = js.Tag,
                    ScriptContent = js.ScriptContent
                };
            }
        }

        /// <summary>
        /// 返回请求头部信息配置集合
        /// </summary>
        /// <returns></returns>
        internal IEnumerable<RequestParamsCaptureConfigItem> GetRequestParamsCaptureConfigItem()
        {
            if (this.AppConfig?.RequestParamsCaptures == null)
                yield break;
            foreach (RequestParamsCaptureConfigItem configItem in this.AppConfig.RequestParamsCaptures)
            {
                yield return configItem;
            }
        }
    }
}
