using System;
using System.Windows.Forms;
using DataStructureTB.Model;
using DataStructureTB.Common;
using System.Threading.Tasks;
using DataStructureTB.Common.HttpAccessClients;

namespace DataStructureTB.Forms
{
    /// <summary>
    /// 登录对话框
    /// </summary>
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
        }


        // 登录成功之后

        internal event EventHandler<LoginApiModel> AfterLogin;



        private void OnAfterLogin(LoginApiModel result)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((Action<LoginApiModel>)this.OnAfterLogin, result);
                return;
            }

            if (result == null || result.code != 200)
            {
                this.SetTipMessage(result?.msg ?? "未登录成功！");
                return;
            }

            //触发登录成功事件
            this.AfterLogin?.Invoke(this, result);
            this.SetTipMessage("");
        }



        internal string GetUserName()
        {
            return this.txt_name.Text.Trim();
        }
        internal string GetUserPawd()
        {
            return this.txt_pwd.Text.Trim();
        }
        internal void SetTipMessage(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg))
                this.lbl_msg.Text = "";
            else
                this.lbl_msg.Text = "消息：" + msg;
        }
        internal void SetLoginBtnEnable(bool enable)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((Action<bool>)this.SetLoginBtnEnable, enable);
                return;
            }
            this.btn_logn.Enabled = enable;
        }

        //登录
        private void btn_logn_Click(object sender, EventArgs e)
        {
            this.SetLoginBtnEnable(false);//禁止再次点击按钮

            string user_name = this.GetUserName();
            string user_pass = this.GetUserPawd();

            MultiBusyControls mBusys = new MultiBusyControls(this, this.txt_name, this.txt_pwd);

            Task.Factory.StartNew(() => new LoginHttpAccess().LoginUser(user_name, user_pass))
                        .ContinueWith(tsk => {
                            try
                            {
                                LoginApiModel ans = tsk.Result;
                                this.OnAfterLogin(ans);
                            }catch (Exception ex)
                            {
#if DEBUG
                                throw ex;
#endif
                            }
                            finally
                            {
                                mBusys.Dispose();
                                this.SetLoginBtnEnable(true);
                            }
                        });
        }
    }
}
