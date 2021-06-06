using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Model
{
    /// <summary>
    /// 表示一个订单项
    /// </summary>
    internal class OrderItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mold { get; set; }
        public long Duedate { get; set; }
    }
}
