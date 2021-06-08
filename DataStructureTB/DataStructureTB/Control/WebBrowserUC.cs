using CefSharp;
using System;
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
            this.Chrome = new ChromeDriver(address, requestContext);
            this.Chrome.AddressChanged += this.chorme_AddressChanged;
            this.panel_browerContainer.Controls.Add(this.Chrome);

        }
        public WebBrowserUC(CefSharp.Web.HtmlString html, CefSharp.IRequestContext requestContext = null) : this()
        {
            this.Chrome = new ChromeDriver(html, requestContext);
            this.panel_browerContainer.Controls.Add(this.Chrome);
        }

        public ChromeDriver Chrome { get; private set; }


        private void chorme_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.txt_href.Text = this.Chrome.Address;
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
            if(this.Chrome.IsDisposed || !this.Chrome.IsLoading || this.Chrome.GetBrowser().IsDisposed)
            {
                this.Chrome.GetBrowser().Reload();
            }
        }

    }
}
