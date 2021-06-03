using CefSharp;
using DataStructureTB.Model;
using System.Collections.Generic;

namespace DataStructureTB.Handlers
{
    /// <summary>
    /// 响应资源的处理
    /// </summary>
    class ResourceRequestHandler : CefSharp.Handler.ResourceRequestHandler
    {
        protected override IResponseFilter GetResourceResponseFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            //return base.GetResourceResponseFilter(chromiumWebBrowser, browser, frame, request, response);
            //return new ResponseFilter(request.Url, chromiumWebBrowser, "");
            ResponseContent rspCnt = new ResponseContent();
            rspCnt.Charset = response.Charset;
            rspCnt.MimeType = response.MimeType;
            rspCnt.Headers = new System.Collections.Specialized.NameValueCollection(response.Headers);
            rspCnt.ErrorCode = response.ErrorCode;
            rspCnt.StatusCode = response.StatusCode;
            rspCnt.StatusText = response.StatusText;

            return new HtmlTextResponseHandle(rspCnt);
        }
    }
}
