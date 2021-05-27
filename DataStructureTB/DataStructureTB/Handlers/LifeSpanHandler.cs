using CefSharp;
using DataStructureTB.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Handlers
{
    class LifeSpanHandler : CefSharp.Handler.LifeSpanHandler
    {
        protected override bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            browserControl.Load(targetUrl);
            return true;
        }
    }
}
