using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Common
{
    /// <summary>
    /// 表示一个url接口的基本信息
    /// </summary>
    internal class UrlInfo
    {
        /// <summary>
        /// 对应的api配置的字段名(HttpApiConfig class filed)
        /// </summary>
        internal string FiledName { get; set; }
        /// <summary>
        /// Url(api)
        /// </summary>
        internal string Url { get; set; }
        /// <summary>
        /// 是否为post请求
        /// </summary>
        internal bool IsPost { get; set; }
    }
}
