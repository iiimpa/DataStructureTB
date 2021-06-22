using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Handlers
{
    interface IProxy
    {
        bool isSetProxy { get; set; }

        string proxyAddress { get; set; }

        bool SetPorxy(ChromiumWebBrowser chromium, string address, out string error);
    }
}
