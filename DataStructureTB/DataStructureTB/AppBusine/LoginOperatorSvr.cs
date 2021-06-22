using System;
using System.Linq;
using DataStructureTB.Model;
using DataStructureTB.Forms;
using System.Collections.Generic;

namespace DataStructureTB.AppBusine
{
    /// <summary>
    /// 提供登录验证操作
    /// </summary>
    internal class LoginOperatorSvr
    {
        internal LoginOperatorSvr()
        { }


        /// <summary>
        /// 设置为静态，便于重用
        /// </summary>
        private static LoginDialog LOGIN_FRM;
        private IEnumerable<NoticeModel> notices;
        private IEnumerable<OrderItemModel> orders;
        private int user_id;
        

        /// <summary>
        /// 表示登录操作是否登录成功
        /// </summary>
        internal bool IsLoginSuccess { get; private set; }

        private void ShowLogin()
        {
            LoginDialog lognFrm = LoginOperatorSvr.LOGIN_FRM;
            if (lognFrm.Visible)
                return;

            //登录成功之后
            lognFrm.AfterLogin += this.OnLogin;
            lognFrm.ShowDialog();
            lognFrm.AfterLogin -= this.OnLogin;
        }
        private void CloseLogin()
        {
            LoginDialog lognFrm = LoginOperatorSvr.LOGIN_FRM;
            lognFrm.Close();
        }
        private void SetAuthSuccessFlag()
        {
            this.IsLoginSuccess = true;
        }
        private void SetAuthFailedFlag()
        {
            this.IsLoginSuccess = false;
        }


        //登录事件
        private void OnLogin(object sender, LoginApiModel e)
        {
            if (e == null || e.code != 200)
            {
                this.SetAuthFailedFlag(); 
                return;
            }

            this.user_id = e.user_id;

            //记录订单项
            this.orders = e.order?.Select(o => new OrderItemModel()
            {
                Id = o.id,
                Name = o.name,
                Mold = o.mold,
                Duedate = o.duedate
            }) ?? new OrderItemModel[0];

            //公告信息
            this.notices = e.notice?.Select(n => new NoticeModel { 
                Id = n.id,
                Name =n.name,
                Time = n.time
            }) ?? new NoticeModel[0];

            this.SetAuthSuccessFlag();
            this.CloseLogin();//登录成功，退出登录界面
        }


        internal static void InitLoginServer()
        {
            LoginOperatorSvr.LOGIN_FRM = new LoginDialog();
            LoginOperatorSvr.LOGIN_FRM.WindowState = System.Windows.Forms.FormWindowState.Normal;
            LoginOperatorSvr.LOGIN_FRM.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            LoginOperatorSvr.LOGIN_FRM.TopMost = true;
        }


        /// <summary>
        /// 进行登录
        /// </summary>
        internal void GoLogin()
        {
            this.ShowLogin();               //登录窗体交互  
        }
        internal void Cancel()
        {
            this.CloseLogin();
        }
        internal IEnumerable<NoticeModel> GetNotices()
        {
            return this.notices;
        }
        internal IEnumerable<OrderItemModel> GetOrderItems()
        {
            return this.orders;
        }
    }
}
