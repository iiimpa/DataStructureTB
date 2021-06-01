using System;
using DataStructureTB.Control;

namespace DataStructureTB.Model.EventArguments
{
    /// <summary>
    /// OrderListControl中的OrderItemButtonClick的事件参数
    /// </summary>
    public class OrderItemButtonClickArgs : EventArgs
    {
        public OrderItemButtonClickArgs()
        { }
        public OrderItemButtonClickArgs(OrderListControl.OrderItem item)
        {
            this.Order = item;
        }

        public OrderListControl.OrderItem Order { get; set; }
    }
}
