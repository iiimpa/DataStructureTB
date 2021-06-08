using System;
using CefSharp;
using System.Windows.Forms;
using DataStructureTB.Handlers;
using System.Collections.Generic;

namespace DataStructureTB.Control
{
    /// <summary>
    /// 浏览器控件
    /// </summary>
    public partial class ChromeDriver : CefSharp.WinForms.ChromiumWebBrowser, IFingerInfo
    {
        public ChromeDriver() :base()
        {

        }
        public ChromeDriver(string address, CefSharp.IRequestContext requestContext = null) : base(address, requestContext)
        {
            InitializeComponent();
        }
        public ChromeDriver(CefSharp.Web.HtmlString html, CefSharp.IRequestContext requestContext = null) : base(html, requestContext)
        {
            InitializeComponent();
        }



        public int CookieId { get; set; }
        public string Cookie { get; set; }
        public string Fingerprint { get; set; }
        public string TaoUser { get; set; }
        public string TaoPass { get; set; }

        internal void SetBindInfo(int cookieId, string cookie, string fingerprint)
        {
            this.CookieId = cookieId;
            this.Cookie = cookie;
            this.Fingerprint = fingerprint;
        }

    }
}
