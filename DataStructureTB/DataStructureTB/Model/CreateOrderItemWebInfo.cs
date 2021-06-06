using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Model
{
    /// <summary>
    /// 创建订单web页面需要的信息
    /// </summary>
    internal class CreateOrderItemWebInfo
    {
        /// <summary>
        /// 订单id
        /// </summary>
        internal int OrderId { get; set; }
        /// <summary>
        /// 订单
        /// </summary>
        internal OrderItemModel Order { get; set; }
        /// <summary>
        /// 订单详情
        /// </summary>
        internal OrderItemDetails OrderDetails { get; set; }
        /// <summary>
        /// local storage 所在的文件夹路径
        /// </summary>
        internal string LocalStoragPath { get; set; }
    }
}
