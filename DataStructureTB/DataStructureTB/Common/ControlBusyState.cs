using System;

namespace DataStructureTB.Common
{
    /// <summary>
    /// 鼠标在控件上的忙碌状态
    /// </summary>
    internal class ControlBusyState : IDisposable
    {
        internal ControlBusyState(System.Windows.Forms.Control host)
        {
            if (host == null)
                throw new ArgumentNullException($"参数不能为null：{nameof(host)}");
            
            this._host = host;
            this._curn = host.Cursor;
            this._host.Cursor = System.Windows.Forms.Cursors.WaitCursor;
        }

        private System.Windows.Forms.Cursor _curn;
        private System.Windows.Forms.Control _host;


        public void Dispose()
        {
            if (this._host.InvokeRequired)
            {
                this._host.BeginInvoke((Action)this.Dispose);
                return;
            }
            this._host.Cursor = this._curn;
        }
    }
}
