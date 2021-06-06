using System;
using DataStructureTB.Model;
using System.Collections.Generic;

namespace DataStructureTB.Common
{
    /// <summary>
    /// 缓存数据管理
    /// </summary>
    internal class AppDataCacheManager
    {
        internal AppDataCacheManager()
        {
            this._Notices = new SortedDictionary<int, NoticeModel>();
            this._Orders = new SortedDictionary<int, OrderItemModel>();
        }


        private SortedDictionary<int, NoticeModel> _Notices;        //订单数据
        private SortedDictionary<int, OrderItemModel> _Orders;      //公告数据


        internal void Clear()
        {
            this._Notices.Clear();
            this._Orders.Clear();
        }
        internal void Add(params OrderItemModel[] orders)
        {
            if (orders == null)
                return;

            foreach(OrderItemModel order in orders)
            {
                if (this._Notices.ContainsKey(order.Id))
                    throw new Exception($"OrderItemMode的key已存在：{order.Id}");

                this._Orders.Add(order.Id, order);
            }
        }
        internal void Add(params NoticeModel[] notices)
        {
            if (notices == null)
                return;

            foreach (NoticeModel notice in notices)
            {
                if (this._Notices.ContainsKey(notice.Id))
                    throw new Exception($"Notice的key已存在：{notice.Id}");

                this._Notices.Add(notice.Id, notice);
            }
        }
        internal NoticeModel GetNotice(int noticeId)
        {
            return this._Notices.ContainsKey(noticeId) ? this._Notices[noticeId] : null;
        }
        internal OrderItemModel GetOrderItem(int orderItemId)
        {
            return this._Orders.ContainsKey(orderItemId) ? this._Orders[orderItemId] : null;
        }
        internal IEnumerable<OrderItemModel> GetOrders() => this._Orders.Values;
        internal IEnumerable<NoticeModel> GetNotices() => this._Notices.Values;
        
    }
}
