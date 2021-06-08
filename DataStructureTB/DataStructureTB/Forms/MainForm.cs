using System;
using CefSharp;
using System.Windows.Forms;
using DataStructureTB.Model;
using DataStructureTB.Common;
using System.Threading.Tasks;
using DataStructureTB.Control;
using System.Collections.Generic;
using DataStructureTB.Model.EventArguments;

namespace DataStructureTB.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.InitializerSef();

            this._OrderIds = new HashSet<int>();
        }


        private readonly object ReadWriteOrderIdLock = new object();

        private HashSet<int> _OrderIds;                             //表示当前正在处理的订单项
        internal Func<int, OrderItemModel> GetOrderItem;            //获取订单
        internal Func<int, string> LoadOrderLocalStorage;           //加载订单的文件缓存
        internal Func<int, OrderItemDetails> GetOrderItemDetails;   //获取订单详情信息，入参：订单id


        private void InitializerSef()
        {
            this.uc_orderlst.OrderItemButtonClick += this.uc_orderlst_Click;
        }
        private bool CanPushOrder(int orderId)
        {
            return !this._OrderIds.Contains(orderId);
        }
        private void PushOrder(int orderId)
        {
            lock (ReadWriteOrderIdLock)
            {
                this._OrderIds.Add(orderId);
            }
        }
        private void PopOrder(int orderId)
        {
            lock (ReadWriteOrderIdLock)
            {
                this._OrderIds.Remove(orderId);
            }
        }
        private void SelectTabpage(TabPage tab)
        {
            this.tabs.SelectedTab = tab;
        }
        private TabPage FindTabpage(string name)
        {
            foreach(TabPage page in this.tabs.TabPages)
            {
                if (page.Name == name)
                    return page;
            }
            return null;
        }

        //获取订单详情
        private CreateOrderItemWebInfo GetCreateOrderItemWebInfo(int orderId)
        {
            CreateOrderItemWebInfo createInfo = new CreateOrderItemWebInfo();
            createInfo.OrderId = orderId;
            createInfo.Order = this?.GetOrderItem(orderId);
            createInfo.OrderDetails = this?.GetOrderItemDetails(orderId);        //订单详情
            createInfo.LocalStoragPath = this?.LoadOrderLocalStorage(orderId);   //订单的缓存路径
            return createInfo;
        }
        //创建订单web控件
        private void CreateOrderItemWebPage(CreateOrderItemWebInfo createInfo, bool selected)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((Action<CreateOrderItemWebInfo, bool>)this.CreateOrderItemWebPage, createInfo, selected);
                return;
            }

            RequestContextSettings rspContextSettings = new RequestContextSettings();
            rspContextSettings.CachePath = createInfo.LocalStoragPath;

            WebBrowserUC chrome = new WebBrowserUC(createInfo.OrderDetails.order_url_url, new RequestContext(rspContextSettings));
            //控件绑定指纹等信息
            chrome.Chrome.SetBindInfo(createInfo.OrderDetails.order_cookie_id, createInfo.OrderDetails.order_cookie, createInfo.OrderDetails.order_fingerprint);
            chrome.Chrome.CookieId = createInfo.OrderDetails.order_cookie_id;
            chrome.Chrome.Cookie = createInfo.OrderDetails.order_cookie;
            chrome.Chrome.Cookie = createInfo.OrderDetails.order_fingerprint;
            chrome.Chrome.TaoUser = createInfo.OrderDetails.order_tao_user;
            chrome.Chrome.TaoPass = createInfo.OrderDetails.order_tao_pass;
            chrome.Dock = DockStyle.Fill;

            TabPage webPage = new TabPage();
            webPage.Name = createInfo.OrderId.ToString();
            webPage.Text = createInfo.Order.Name;
            webPage.Controls.Add(chrome);
            this.tabs.TabPages.Add(webPage);

            //选中当前页面
            this.tabs.BeginInvoke((Action<TabPage>)this.SelectTabpage, webPage);
        }

        

        //获取订单详情之后，创建订单的web控件
        private void OnAfterGetOrderItem(CreateOrderItemWebInfo createInfo)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke((Action<CreateOrderItemWebInfo>)this.OnAfterGetOrderItem, createInfo);
                return;
            }

            if (createInfo?.OrderDetails == null || createInfo.OrderDetails.code != 200)
            {
                MessageTools.ShowMessage(createInfo?.OrderDetails?.msg ?? "资源加载加载失败，请稍后再试！");
                return;
            }

            //创建订单项的浏览器
            this.CreateOrderItemWebPage(createInfo, true);
        }



        //当订单被点击时
        private void uc_orderlst_Click(object sender, OrderItemButtonClickArgs e)
        {
            if (e.Order == null || this.GetOrderItemDetails == null)
            {
                return;
            }

            TabPage exists = this.FindTabpage(e.Order.Id.ToString());
            if(exists != null)
            {
                this.SelectTabpage(exists);
                return;
            }

            //当前订单是否正在加载
            if (!this.CanPushOrder(e.Order.Id))
                return;

            //记录当前正在处理的订单
            this.PushOrder(e.Order.Id);

            //忙碌状态设置
            MultiBusyControls mBusys = null;
            if (sender is System.Windows.Forms.Control)
                mBusys = new MultiBusyControls(sender as System.Windows.Forms.Control);

            int orderId = e.Order.Id;
            Task.Factory.StartNew(() => this.GetCreateOrderItemWebInfo(orderId))        //获取订单
                        .ContinueWith(tsk => this.OnAfterGetOrderItem(tsk.Result))      //创建订单页面
                        .ContinueWith(tsk => mBusys.Dispose())                          //解除忙碌状态
                        .ContinueWith(tsk => this.PopOrder(orderId))                    //取消当前的正在处理的订单
                        .ConfigureAwait(false);
        }       



        internal void LoadNotices(IEnumerable<NoticeModel> notices)
        {

        }
        internal void LoadOrderItems(IEnumerable<OrderItemModel> orders)
        {
            if (orders != null)
            {
                foreach (OrderItemModel order in orders)
                {
                    this.uc_orderlst.AddOrderItem(new OrderListControl.OrderItem()
                    {
                        Id = order.Id,
                        Name = order.Name,
                        Mold = order.Mold,
                        Duedate = order.Duedate
                    });
                }
            }
        }
    }
}
