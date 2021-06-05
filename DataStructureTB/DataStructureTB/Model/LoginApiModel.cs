using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Model
{
    /// <summary>
    /// 登录结果返回的实体
    /// </summary>
    internal class LoginApiModel
    {
        public LoginApiModel() { }


        //订单
        public IEnumerable<OrderModel> order { get; set; }
        //公告
        public IEnumerable<NoticeModel> notice { get; set; }
        public string msg { get; set; }
        public int code { get; set; }
        public int user_id { get; set; }
        //续费跳转
        public string renew_url { get; set; }
        //代理跳转
        public string agent_url { get; set; }
        //客户系统跳转
        public string chat_url { get; set; }




        /// <summary>
        /// 登录结果返回的订单实体
        /// </summary>

        internal class OrderModel
        { 
            public OrderModel() { }

            
            public int id { get; set; }
            public string name { get; set; }
            public string mold { get; set; }
            //过期时间
            public long duedate { get; set; }
        }

        /// <summary>
        /// 登陆结果返回的公告
        /// </summary>
        internal class NoticeModel
        {
            public NoticeModel() { }
            public int id { get; set; }
            public string name { get; set; }
            public long time { get; set; }
        }
    }
}
