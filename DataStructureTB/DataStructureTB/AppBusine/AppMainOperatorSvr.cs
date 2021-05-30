using System;
using DataStructureTB;
using DataStructureTB.Forms;

namespace DataStructureTB.AppBusine
{
    /// <summary>
    /// 程序主业务流程
    /// </summary>
    internal class AppMainOperatorSvr
    {
        internal AppMainOperatorSvr() 
        {
            this.mForm = new MainForm();
        }

        private MainForm mForm;

        internal void EnterMainLifeTime()
        {
            System.Windows.Forms.Application.Run(this.mForm);
        }
    }
}
