using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Model
{
    /// <summary>
    /// 订单项详情
    /// </summary>
    internal class OrderItemDetails
    {
        public OrderItemDetails() { }

        public int code { get; set; }
        public string msg { get; set; }
        //淘宝登录账号
        public string order_tao_user { get; set; }
        //淘宝登录密码
        public string order_tao_pass { get; set; }
        public string order_ip_ip { get; set; }
        public string order_ip_port { get; set; }
        public string order_ip_pass { get; set; }
        /// <summary>
        /// 立即使用 的跳转地址
        /// </summary>
        public string order_url_url { get; set; }
        /// <summary>
        /// 淘宝cookie id
        /// </summary>
        public int order_cookie_id { get; set; }
        /// <summary>
        /// 指纹
        /// </summary>
        public string order_fingerprint { get; set; }
        /// <summary>
        /// cookie
        /// </summary>
        public string order_cookie { get; set; }
        /// <summary>
        /// local storag
        /// </summary>
        public IEnumerable<OrderFile> order_file { get; set; }

        /// <summary>
        /// local storags 文件
        /// </summary>
        internal class OrderFile
        {
            public int id { get; set; }
            public int oid { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public long r_time { get; set; }
            public long l_time { get; set; }
        }
    }
}
