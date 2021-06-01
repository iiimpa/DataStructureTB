using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataStructureTB.Control;
using DataStructureTB.Model.EventArguments;

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
            this.uc_orderlst.OrderItemButtonClick += this.uc_orderlst_Click;


            this.webCtrl = new ChromeDriver("");
            this.webCtrl.Dock = DockStyle.Fill;
            this.tabp_web.Controls.Add(this.webCtrl);
        }


        private void BrowserForm_Load(object sender, EventArgs e)
        {
            //var chrome = new ChromeDriver("https://login.taobao.com/member/login.jhtml");
            //chrome.Dock = DockStyle.Fill;
            //this.Controls.Add(chrome);
        }

        //当订单被点击时
        private void uc_orderlst_Click(object sender, OrderItemButtonClickArgs e)
        {
            this.tabs.SelectedTab = this.tabp_web;
            this.webCtrl.Load("https://login.taobao.com/member/login.jhtml");
        }
    }
}
