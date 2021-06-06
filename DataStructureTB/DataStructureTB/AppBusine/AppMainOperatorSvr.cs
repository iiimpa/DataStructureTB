using System;
using DataStructureTB;
using DataStructureTB.Forms;
using DataStructureTB.Model;
using DataStructureTB.Common;
using System.Collections.Generic;
using DataStructureTB.Common.HttpAccessClients;

namespace DataStructureTB.AppBusine
{
    /// <summary>
    /// 程序主业务流程
    /// </summary>
    internal class AppMainOperatorSvr
    {
        internal AppMainOperatorSvr() 
        {
            this.mForm = new MainForm();
            this.mForm.GetOrderItem = this.GetOrderItem;               //获取订单
            this.mForm.GetOrderItemDetails = this.GetOrderItemDetails; //获取订单详情接口
            this.mForm.LoadOrderLocalStorage = this.GetOrderItemLocalStoragePath;//订单web的缓存路径获取

            
            this._Orders = new SortedDictionary<int, OrderItemModel>();         //订单
            this._Notices = new SortedDictionary<int, NoticeModel>();           //公告
            this._OrderDetails = new SortedDictionary<int, OrderItemDetails>(); //订单详情
            this._OrderItemLocalStorage = new SortedDictionary<int, string>();  //订单的 Local Storage 路径
            
        }

        private MainForm mForm;


        private SortedDictionary<int, NoticeModel> _Notices;            //公告
        private SortedDictionary<int, OrderItemModel> _Orders;          //订单        key: orderId
        private SortedDictionary<int, OrderItemDetails> _OrderDetails;  //订单详情    key: orderId
        private SortedDictionary<int, string> _OrderItemLocalStorage;   //订单的local storag路劲    key: orderId
        

        private OrderItemModel GetOrderItem(int orderId)
        {
            return this._Orders != null && this._Orders.ContainsKey(orderId) ? this._Orders[orderId] : null;
        }
        private OrderItemDetails GetOrderItemDetails(int orderId)
        {
            if (this._OrderDetails.ContainsKey(orderId))
                return this._OrderDetails[orderId];

            //获取订单详情
            OrderItemDetailsHttpAccess client = new OrderItemDetailsHttpAccess();
            OrderItemDetails orderDetails = client.GetOrderItemDetails(orderId);
            if (orderDetails != null && orderDetails.code == 200)
                this._OrderDetails.Add(orderId, orderDetails);

            return orderDetails;
        }
        private string GetOrderItemLocalStoragePath(int orderId)
        {
            if (this._OrderItemLocalStorage.ContainsKey(orderId))
            {
                return this._OrderItemLocalStorage[orderId];
            }

            OrderItemDetails orderItem = null;
            if (!this._OrderDetails.TryGetValue(orderId, out orderItem))
                return null;

            //保存路径
            string localStorageDir = !string.IsNullOrWhiteSpace(AppConfigManager.Inst.AppConfig.LocalStoragesDirPath) ?
                                        AppConfigManager.Inst.AppConfig.LocalStoragesDirPath : ".\\Users Data";
            localStorageDir = System.IO.Path.GetFullPath(localStorageDir);
            localStorageDir = System.IO.Path.Combine(localStorageDir, $"{Guid.NewGuid()}_{orderId}");

            //文件下载
            StoreLocalStorageFiles downloadFiles = new StoreLocalStorageFiles();
            downloadFiles.DownloadWithStore(localStorageDir, orderItem.order_file);

            this._OrderItemLocalStorage.Add(orderId, localStorageDir);
            return localStorageDir;
        }



        /// <summary>
        /// 设置主界面需要加载的公告
        /// </summary>
        internal void SetNotices(IEnumerable<NoticeModel> notices)
        {
            if (notices != null)
            {
                foreach (NoticeModel notice in notices)
                    this._Notices.Add(notice.Id, notice);

                this.mForm.LoadNotices(notices);
            }
        }
        /// <summary>
        /// 设置主界面需要加载的订单
        /// </summary>
        internal void SetOrderItems(IEnumerable<OrderItemModel> orders)
        {
            if (orders != null)
            {
                foreach (OrderItemModel order in orders)
                    this._Orders.Add(order.Id, order);

                this.mForm.LoadOrderItems(orders);
            }
        }

        internal void EnterMainLifeTime()
        {
            System.Windows.Forms.Application.Run(this.mForm);
        }
    }
}
