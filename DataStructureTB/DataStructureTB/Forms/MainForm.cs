using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using DataStructureTB.Control;

namespace DataStructureTB.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.InitializerSef();
        }


        private ChromeDriver webCtrl;


        private void InitializerSef()
        {
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });
            this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem() { });


            this.webCtrl = new ChromeDriver("");
            this.webCtrl.Dock = DockStyle.Fill;
            this.tabp_web.Controls.Add(this.webCtrl);
        }


        private void BrowserForm_Load(object sender, EventArgs e)
        {
            //var chrome = new ChromeDriver("https://login.taobao.com/member/login.jhtml");
            //chrome.Dock = DockStyle.Fill;
            //this.Controls.Add(chrome);

            this.webCtrl.Load("https://login.taobao.com/member/login.jhtml");
        }
    }
}
