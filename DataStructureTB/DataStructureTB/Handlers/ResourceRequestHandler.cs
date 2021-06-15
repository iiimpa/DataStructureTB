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
            if (!(chromiumWebBrowser is IJavaScriptObject))
                return base.GetResourceResponseFilter(chromiumWebBrowser, browser, frame, request, response);

            ResponseContent rspCnt = new ResponseContent();
            rspCnt.Url = request.Url;
            rspCnt.Charset = response.Charset;
            rspCnt.MimeType = response.MimeType;
            rspCnt.Headers = new System.Collections.Specialized.NameValueCollection(response.Headers);
            rspCnt.ErrorCode = response.ErrorCode;
            rspCnt.StatusCode = response.StatusCode;
            rspCnt.StatusText = response.StatusText;

            IJavaScriptObject finger = chromiumWebBrowser as IJavaScriptObject;

            return new HtmlTextResponseHandle(finger, rspCnt);
        }
    }
}