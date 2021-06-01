using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DataStructureTB.Control
{
    public partial class OrderItemControl : UserControl
    {
        public OrderItemControl()
        {
            InitializeComponent();
        }

        //外部注册的点击事件处理程序
        private EventHandler useBtnClickHandle;

        
        //立即使用按钮点击事件
        private void btn_use_Click(object sender, EventArgs e)
        {
            //调用外部注册的处理程序
            this.useBtnClickHandle?.Invoke(this, e);
        }



        //向外抛出的事件处理注册接口
        public void SetClickHandle(EventHandler handle)
        {
            this.useBtnClickHandle += handle;
        }
    }
}
