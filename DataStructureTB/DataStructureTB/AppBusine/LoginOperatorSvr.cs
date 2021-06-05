using System;
using DataStructureTB.Forms;

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

        /// <summary>
        /// 表示登录操作是否登录成功
        /// </summary>
        internal bool IsLoginSuccess { get; private set; }

        private void ShowLogin()
        {
            LoginDialog lognFrm = LoginOperatorSvr.LOGIN_FRM;
            if (lognFrm.Visible)
                return;

            lognFrm.ShowDialog();
        }
        private void SetAuthSuccessFlag()
        {
            this.IsLoginSuccess = true;
        }
        private void SetAuthFailedFlag()
        {
            this.IsLoginSuccess = false;
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
            this.SetAuthFailedFlag();       
        }
    }
}
