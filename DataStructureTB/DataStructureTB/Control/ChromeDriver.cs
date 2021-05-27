using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
