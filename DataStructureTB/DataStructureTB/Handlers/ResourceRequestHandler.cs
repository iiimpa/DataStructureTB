using CefSharp;
using System;
using System.Collections.Generic;
using System.Text;

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
            return new GenericResponseHandle();
        }
    }
}
