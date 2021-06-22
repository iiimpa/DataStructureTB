using System;
using System.Windows.Forms;
using System.Collections.Generic;
using DataStructureTB.Model.EventArguments;

namespace DataStructureTB.Control
{
    public partial class OrderListControl : UserControl
    {
        public OrderListControl()
        {
            InitializeComponent();

            this.items = new LinkedList<OrderItem>();
        }

        //private List<OrderItem[]> items;
        private LinkedList<OrderItem> items;

        /// <summary>
        /// 订单项的按钮的事件
        /// </summary>
        public EventHandler<OrderItemButtonClickArgs> OrderItemButtonClick;


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
            this.items.AddLast(item);
        }
        private void AppendOrderItemControl(OrderItemControl itemCtrl)
        {
            FlowLayoutPanel left = this.flow_left;
            left.Controls.Add(itemCtrl);
        }
        private OrderItemControl CreateOrderItemControl(OrderItem order)
        {
            if (order == null)
                throw new Exception($"参数不能为null：{nameof(order)}");

            OrderItemControl item = new OrderItemControl();
            item.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            item.Tag = order;
            item.SetTitle($"{order.Name}({order.Mold})");
            item.SetDueDate(order.Duedate);
            item.SetClickHandle(this.OrderItemButton_Click);

            return item;
        }


        //向尾部追加新的订单项
        private void AppendItem(OrderItem item)
        {
            OrderItemControl orderCtrl = this.CreateOrderItemControl(item);
            this.AppendOrderItem(item);
            this.AppendOrderItemControl(orderCtrl);
        }
        private void OnOrderItemButtonClick(OrderItemButtonClickArgs e)
        {
            this.OrderItemButtonClick?.Invoke(this, e);
        }


        private void OrderItemButton_Click(object sender, EventArgs e)
        {
            OrderItemControl origin = sender as OrderItemControl;
            OrderItemButtonClickArgs args = new OrderItemButtonClickArgs(origin?.Tag as OrderItem);
            this.OnOrderItemButtonClick(args);
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
            public long Duedate { get; set; }
            /// <summary>
            /// 扩展数据
            /// </summary>
            public object Tag { get; set; }
        }
    }
}
