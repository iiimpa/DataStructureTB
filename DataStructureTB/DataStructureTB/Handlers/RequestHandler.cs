using CefSharp;
using DataStructureTB.Common;
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
            var JavaScriptObject = chromiumWebBrowser as IJavaScriptObject;
            var requestParamsCapture = new RequestParamsCapture(JavaScriptObject.RequestParams, request);
            requestParamsCapture.SetInjectionItem(AppConfigManager.Inst.GetRequestParamsCaptureConfigItem());
            requestParamsCapture.GetAndAddParams();
            if (requestParamsCapture.IsTargetSite())
                chromiumWebBrowser.ExecuteScriptAsync(requestParamsCapture.GetInjectJavaScriptObject());

            return new ResourceRequestHandler();
        }

    }
}
