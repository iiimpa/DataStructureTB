using CefSharp;
using DataStructureTB.Handlers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataStructureTB.Control
{
    /// <summary>
    /// 带工具栏的浏览器控件
    /// </summary>
    public partial class WebBrowserUC : UserControl
    {
        public WebBrowserUC()
        {
            InitializeComponent();
        }
        public WebBrowserUC(string address, CefSharp.IRequestContext requestContext = null) : this()
        {
            this.Chrome = new Browser(address, requestContext);
            this.Chrome.AddressChanged += this.chorme_AddressChanged;
            this.panel_browerContainer.Controls.Add(this.Chrome);

        }
        public WebBrowserUC(CefSharp.Web.HtmlString html, CefSharp.IRequestContext requestContext = null) : this()
        {
            this.Chrome = new Browser(html, requestContext);
            this.panel_browerContainer.Controls.Add(this.Chrome);
        }

        public Browser Chrome { get; private set; }


        private void chorme_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.txt_href.BeginInvoke((Action)(() =>
            {
                this.txt_href.Text = this.Chrome.Address;
            }));
        }


        private void tls_back_Click1(object sender, EventArgs e)
        {
            if (this.Chrome.CanGoBack)
            {
                this.Chrome.GetBrowser().GoBack();
            }
        }
        private void tls_forward_Click(object sender, EventArgs e)
        {
            if (this.Chrome.CanGoForward)
            {
                this.Chrome.GetBrowser().GoForward();
            }
        }
        private void tls_refresh_Click(object sender, EventArgs e)
        {
            if (this.Chrome.IsDisposed || !this.Chrome.IsLoading || this.Chrome.GetBrowser().IsDisposed)
            {
                this.Chrome.GetBrowser().Reload();
            }
        }

        private void txt_href_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                this.Chrome.Load(this.txt_href.Text);
        }
    }
}
