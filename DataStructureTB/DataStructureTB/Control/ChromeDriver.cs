using System;
using CefSharp;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataStructureTB.Control
{
    public partial class ChromeDriver : CefSharp.WinForms.ChromiumWebBrowser
    {
        public ChromeDriver() : base()
        {
            InitializeComponent();
        }

        public ChromeDriver(string address, CefSharp.IRequestContext requestContext = null) : base(address, requestContext)
        {
            InitializeComponent();
        }

        public ChromeDriver(CefSharp.Web.HtmlString html, CefSharp.IRequestContext requestContext = null) : base(html, requestContext)
        {
            InitializeComponent();
        }

        public string Initfingerprint(Dictionary<string, string> values)
        {
            string js = ""; //从Resource读取的js
            if (values == null || values.Count == 0)
                return js;
            foreach (KeyValuePair<string, string> item in values)
            {
                js = js.Replace("data." + item.Key, item.Value);
            }
            return js;
        }
    }
}
