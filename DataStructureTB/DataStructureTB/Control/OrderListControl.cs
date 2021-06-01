using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DataStructureTB.Control
{
    public partial class OrderListControl : UserControl
    {
        public OrderListControl()
        {
            InitializeComponent();

            this.items = new List<OrderItem[]>();
        }

        private List<OrderItem[]> items;



        private int GetRowCount()
        {
            return this.items.Count;
        }
        private int GetColCount()
        {
            return 2;
        }
        private void AppendOrderItem(OrderItem item)
        {
            int row = this.GetRowCount();
            int col = this.GetColCount();

            if (row == 0 || this.items[row - 1][col - 1] != null)
            {
                this.items.Add(new OrderItem[2] { item, null });
                return;
            }
            this.items[this.GetRowCount() - 1][this.GetColCount() - 1] = item;
        }

        private void AppendOrderItemControl(OrderItemControl itemCtrl)
        {
            FlowLayoutPanel left = this.flow_left;
            FlowLayoutPanel right = this.flow_right;
            
            if(left.Controls.Count >= right.Controls.Count)
            {
                right.Controls.Add(itemCtrl);
            }
            else
            {
                left.Controls.Add(itemCtrl);
            }
        }
        private OrderItemControl CreateOrderItemControl(OrderItem order)
        {
            if (order == null)
                throw new Exception($"参数不能为null：{nameof(order)}");

            OrderItemControl item = new OrderItemControl();
            item.Anchor = AnchorStyles.None;
            item.Tag = order.Tag;
            
            return item;
        }
        //向尾部追加新的订单项
        private void AppendItem(OrderItem item)
        {
            OrderItemControl orderCtrl = this.CreateOrderItemControl(item);
            this.AppendOrderItem(item);
            this.AppendOrderItemControl(orderCtrl);
        }


        public List<OrderItem> GetOrderItems()
        {
            return null;
        }
        public void AddOrderItem(OrderItem item)
        {
            this.AppendItem(item);
        }



        /// <summary>
        /// 传给OrderItemControl的 订单数据model
        /// </summary>
        public class OrderItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Mold { get; set; }
            public ulong Duedate { get; set; }
            /// <summary>
            /// 扩展数据
            /// </summary>
            public object Tag { get; set; }
        }
    }
}
