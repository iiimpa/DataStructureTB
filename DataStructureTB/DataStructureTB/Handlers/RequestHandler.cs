using CefSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Handlers
{
    /// <summary>
    /// http资源请求的处理
    /// </summary>
    class RequestHandler : CefSharp.Handler.RequestHandler
    {
        protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            //return base.GetResourceRequestHandler(chromiumWebBrowser, browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
            return new ResourceRequestHandler();
        }
    }
}
