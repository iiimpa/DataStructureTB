using System;
using CefSharp;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace DataStructureTB.Model
{
    /// <summary>
    /// 响应上下文
    /// </summary>
    internal class ResponseContent
    {
        internal string Charset { get; set; }
        internal string MimeType { get; set; }
        internal NameValueCollection Headers { get; set; }
        internal bool IsReadOnly { get; }
        internal CefErrorCode ErrorCode { get; set; }
        internal int StatusCode { get; set; }
        internal string StatusText { get; set; }

    }
}
