using CefSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Handlers
{
    class RequestHandler : CefSharp.Handler.RequestHandler
    {
        protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            return base.GetResourceRequestHandler(chromiumWebBrowser, browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
        }
    }
}
