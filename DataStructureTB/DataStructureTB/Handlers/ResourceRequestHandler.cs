using CefSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Handlers
{
    class ResourceRequestHandler : CefSharp.Handler.ResourceRequestHandler
    {
        protected override IResponseFilter GetResourceResponseFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            return base.GetResourceResponseFilter(chromiumWebBrowser, browser, frame, request, response);
        }
    }
}
