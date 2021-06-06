using System;
using System.Collections.Generic;

namespace DataStructureTB.Common
{
    /// <summary>
    /// 表示一个http访问资源
    /// </summary>
    internal class HttpAccess
    {
        /// <summary>
        /// url上的查询参数
        /// </summary>
        internal Object[] UrlArgs { get; set; }
        /// <summary>
        /// 请求体内容(post请求)
        /// </summary>
        internal Object Content { get; set; }
        /// <summary>
        /// 接口信息
        /// </summary>
        internal UrlInfo API { get; set; }
        /// <summary>
        /// http 响应结果的处理
        /// </summary>
        internal IHttpResultHandle ResultHandle { get; set; }
    }
}
