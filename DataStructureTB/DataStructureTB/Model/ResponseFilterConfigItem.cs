﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Model
{
    /// <summary>
    /// http资源响应内容的js过滤配置项
    /// </summary>
    internal class ResponseFilterConfigItem
    {
        internal ResponseFilterConfigItem()
        { }


        /// <summary>
        /// js注入的位置
        /// </summary>
        public string InjectionPos { get; set; }
        /// <summary>
        /// js注入在指定位置的左边还是右边
        /// </summary>
        public string InjectionOn { get; set; }
        /// <summary>
        /// 该脚本处理的请求地址
        /// </summary>
        public string HandleUrl { get; set; }
        /// <summary>
        /// 该脚本的服务器地址
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        /// 注入标签
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 该脚本的本地路径地址
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// js的直接内容
        /// </summary>
        public string ScriptContent { get; set; }
    }
}
