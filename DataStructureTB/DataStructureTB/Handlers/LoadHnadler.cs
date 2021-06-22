using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Handlers
{
    class LoadHnadler : ILoadHandler
    {
        public void OnFrameLoadEnd(IWebBrowser chromiumWebBrowser, FrameLoadEndEventArgs frameLoadEndArgs)
        {

        }

        public void OnFrameLoadStart(IWebBrowser chromiumWebBrowser, FrameLoadStartEventArgs frameLoadStartArgs)
        {
            var proxy = chromiumWebBrowser as IProxy;
            if (!proxy.isSetProxy)
            {
                string error;
                bool success = proxy.SetPorxy(chromiumWebBrowser as ChromiumWebBrowser, proxy.proxyAddress, out error);
                if (success)
                    proxy.isSetProxy = true;
            }
        }

        public void OnLoadError(IWebBrowser chromiumWebBrowser, LoadErrorEventArgs loadErrorArgs)
        {

        }

        public void OnLoadingStateChange(IWebBrowser chromiumWebBrowser, LoadingStateChangedEventArgs loadingStateChangedArgs)
        {

        }
    }
}
