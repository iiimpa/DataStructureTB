using System;
using DataStructureTB.Model;
using DataStructureTB.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataStructureTB.AppBusine
{
    /// <summary>
    /// 程序运行周期
    /// </summary>
    internal class AppLifeTime
    {
        internal AppLifeTime() 
        {
            LoginOperatorSvr.InitLoginServer();

            this.loginServer = new LoginOperatorSvr();
            this.mainLifeTimeSvr = new AppMainOperatorSvr();
            this.appDataMgr = new AppDataCacheManager();
        }


        private LoginOperatorSvr loginServer;       //登录操作
        private AppMainOperatorSvr mainLifeTimeSvr; //主界面
        private AppDataCacheManager appDataMgr;     //数据缓存


        private void InitializerAppData(IEnumerable<OrderItemModel> orders, IEnumerable<NoticeModel> notices)
        {
            if(orders != null)
            {
                foreach (OrderItemModel order in orders)
                    this.appDataMgr.Add(order);
            }
            
            if(notices != null)
            {
                foreach (NoticeModel notice in notices)
                    this.appDataMgr.Add(notice);
            }
        }



        internal void EnterAppLifeTime()
        {
            //登录验证
            this.loginServer.GoLogin();
#if DEBUG
            if (/*this.loginServer.IsLoginSuccess*/true)
            {
                IEnumerable<NoticeModel> notices = this.loginServer.GetNotices();
                IEnumerable<OrderItemModel> orders = this.loginServer.GetOrderItems();

                orders = new OrderItemModel[] {
                    new OrderItemModel{
                        Id = 137,
                        Name = "文具电教/文化用品/商务用品",
                        Mold = "标准版",
                        Duedate = 1629264049
                    }
                };

                //初始化数据缓存，供程序期间使用
                Task.Factory.StartNew(() => this.InitializerAppData(orders, notices));

                this.mainLifeTimeSvr.SetNotices(notices);   //设置界面所需的公告
                this.mainLifeTimeSvr.SetOrderItems(orders); //设置界面所需的订单
                this.mainLifeTimeSvr.EnterMainLifeTime();   //进入主程序
            }
#else
            if (this.loginServer.IsLoginSuccess)
            {
                IEnumerable<NoticeModel> notices = this.loginServer.GetNotices();
                IEnumerable<OrderItemModel> orders = this.loginServer.GetOrderItems();

                //初始化数据缓存，供程序期间使用
                Task.Factory.StartNew(()=>this.InitializerAppData(orders, notices));

                this.mainLifeTimeSvr.SetNotices(notices);   //设置界面所需的公告
                this.mainLifeTimeSvr.SetOrderItems(orders); //设置界面所需的订单
                this.mainLifeTimeSvr.EnterMainLifeTime();   //进入主程序
            }
#endif
        }
    }
}
