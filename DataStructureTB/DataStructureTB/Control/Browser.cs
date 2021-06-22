using System;
using CefSharp;
using System.Windows.Forms;
using DataStructureTB.Handlers;
using System.Collections.Generic;
using CefSharp.WinForms;

namespace DataStructureTB.Control
{
    /// <summary>
    /// 浏览器控件
    /// </summary>
    public partial class Browser : CefSharp.WinForms.ChromiumWebBrowser, IJavaScriptObject, IProxy
    {
        public Browser() : base()
        {

        }
        public Browser(string address, CefSharp.IRequestContext requestContext = null) : base(address, requestContext)
        {
            base.RequestHandler = new RequestHandler();
            base.LifeSpanHandler = new LifeSpanHandler();
            base.KeyboardHandler = new KeyboardHandler();
            base.DownloadHandler = new DownloadHandler();
            base.LoadHandler = new LoadHnadler();
            InitializeComponent();
        }
        public Browser(CefSharp.Web.HtmlString html, CefSharp.IRequestContext requestContext = null) : base(html, requestContext)
        {
            InitializeComponent();
        }



        public int CookieId { get; set; }
        public string Cookie { get; set; }
        public string Fingerprint { get; set; }
        public string TaoUser { get; set; }
        public string TaoPass { get; set; }
        public List<Model.RequestParamsCaptureModel> RequestParams { get; set; }

        public string proxyAddress { get; set; }

        public bool isSetProxy { get; set; }

        public bool SetPorxy(ChromiumWebBrowser chromium, string proxyAddress, out string error)
        {
            var result = Cef.UIThreadTaskFactory.StartNew(() =>
            {
                var requestContext = chromium.GetBrowser().GetHost().RequestContext;
                var @params = new Dictionary<string, string>();
                @params["mode"] = "fixed_servers";
                @params["server"] = proxyAddress;
                string error;
                bool success = requestContext.SetPreference("proxy", @params, out error);
                return new { error, success };
            }).Result;
            error = result.error;
            return result.success;
        }

        internal void SetBindInfo(int cookieId, string cookie, string fingerprint, string proxyAddress, List<Model.RequestParamsCaptureModel> requestParams = null)
        {
            this.proxyAddress = proxyAddress;
            this.CookieId = cookieId;
            this.Cookie = cookie;
            this.Fingerprint = fingerprint;
            this.RequestParams = requestParams == null ? new List<Model.RequestParamsCaptureModel>() : requestParams;
        }

    }
}
