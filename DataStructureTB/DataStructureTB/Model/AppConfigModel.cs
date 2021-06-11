using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Model
{
    /// <summary>
    /// 程序配置模型
    /// </summary>
    internal class AppConfigModel
    {
        public AppConfigModel()
        { }

        public string Discription { get; set; }
        public string Version { get; set; }

        /// <summary>
        /// 注入的js对象变量名
        /// </summary>

        public string InjectObj { get; set; }
        /// <summary>
        /// 注入对象的Finger属性
        /// </summary>
        public string InjectFinger { get; set; }
        public string InjectTaoUser { get; set; }
        public string InjectTaoPass { get; set; }
        public string InjectRequestParams { get; set; }


        /// <summary>
        ///  Local Storage 的存储路径
        /// </summary>
        public string LocalStoragesDirPath { get; set; }
        /// <summary>
        /// Local Storage 的存储路径的扩展
        /// </summary>
        public string LocalStoragePathEx { get; set; }

        /// <summary>
        /// javascript配置
        /// </summary>
        public IEnumerable<JavaScriptMode> JavaScripts { get; set; }

        public IEnumerable<RequestParamsCaptureConfigItem> RequestParamsCaptures { get; set; }
    }


    /// <summary>
    /// javascript信息配置
    /// </summary>
    internal class JavaScriptMode
    {
        public JavaScriptMode()
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
        /// 该脚本的本地路径地址
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// js的直接内容
        /// </summary>
        public string ScriptContent { get; set; }
    }
}
