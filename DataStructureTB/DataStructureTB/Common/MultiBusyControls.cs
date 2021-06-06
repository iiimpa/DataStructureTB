using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DataStructureTB.Common
{
    /// <summary>
    /// 多控件忙碌状态
    /// </summary>
    internal class MultiBusyControls : IDisposable
    {
        internal MultiBusyControls(params System.Windows.Forms.Control[] ctrlBusys)
        {
            if(ctrlBusys == null)
            {
                throw new ArgumentNullException($"参数不能为null：{nameof(ctrlBusys)}");
            }

            this.mBusys = ctrlBusys.Select(c => new ControlBusyState(c)).ToList();
        }

        private IEnumerable<ControlBusyState> mBusys;


        public void Dispose()
        {
            foreach (ControlBusyState busy in this.mBusys)
                busy.Dispose();
        }
    }
}
