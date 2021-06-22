using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DataStructureTB.Control
{
    /// <summary>
    /// 封装一个可以关闭tab页的选项卡控件
    /// </summary>
    public partial class TabControlUC : TabControl
    {
        public TabControlUC()
        {
            InitializeComponent();

            this._TabPageMouseState = new SortedDictionary<int, bool>();
            this._TabPageClsRcts = new SortedDictionary<int, Rectangle>();

            this.drawTimer = new Timer();
            this.drawTimer.Interval = 50;
            this.drawTimer.Tick += this.timer_Tick;
            this.drawTimer.Enabled = true;
            this.drawTimer.Start();

            this.ItemSize = new Size(100, 26);
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            this.DrawItem += this.tabs_DrawItem;
            this.MouseClick += this.tabs_MouseClick;
        }

        private SortedDictionary<int, Rectangle> _TabPageClsRcts;   //tabpage的关闭按钮的大小
        private SortedDictionary<int, bool> _TabPageMouseState;
        private Timer drawTimer;

        //绘制选项卡的关闭按钮
        private void tabs_DrawItem(object sender, DrawItemEventArgs e)
        {
            //首页选项卡不绘制
            int itemHeight = this.ItemSize.Height;
            string text = this.TabPages[e.Index].Text;

            Point pMouse = MousePosition;
            pMouse = this.PointToClient(pMouse);

            Rectangle clsRect = new Rectangle(new Point(e.Bounds.X + e.Bounds.Width - 20, (itemHeight - 16) / 2), new Size(16, 16));//关闭按钮绘制位置
            Color itemBgColor = e.BackColor;                                        //背景色
            Color itemFrColor = e.ForeColor;                                        //前景色
            Color clsBgColor = clsRect.Contains(pMouse) ? Color.Red : Color.Gray;   //关闭按钮背景色
            Color clsFrColor = Color.White;                                         //关闭按钮前景色

            using (SolidBrush itemBg = new SolidBrush(itemBgColor))
            using (SolidBrush itemFr = new SolidBrush(itemFrColor))
            using (SolidBrush clsBg = new SolidBrush(clsBgColor))
            using (Pen clsFr = new Pen(clsFrColor, 2))
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                Rectangle rct = e.Bounds;
                rct.Inflate(10, 10);
                //e.Bounds.Inflate(10, 10);
                //背景和标题
                e.Graphics.FillRectangle(itemBg, e.Bounds);
                e.Graphics.DrawString(text, e.Font, itemFr, rct, format);

                //不处理首页
                if (e.Index == 0)
                    return;

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //选项卡关闭按钮
                e.Graphics.FillEllipse(clsBg, clsRect);

                Rectangle flag = clsRect;
                flag.Inflate(-5, -5);
                e.Graphics.DrawLine(clsFr, new Point(flag.X, flag.Y), new Point(flag.X + flag.Width, flag.Y + flag.Height));
                e.Graphics.DrawLine(clsFr, new Point(flag.X + flag.Width, flag.Y), new Point(flag.X, flag.Y + flag.Height));

                //记录该关闭按钮的位置
                this._TabPageClsRcts[e.Index] = clsRect;
                this._TabPageMouseState[e.Index] = clsRect.Contains(pMouse);
            }
        }
        private void tabs_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (KeyValuePair<int, Rectangle> kv in this._TabPageClsRcts)
            {
                if (kv.Value.Contains(e.Location) && this.TabCount > kv.Key)
                {
                    //删除被点击的按钮
                    this._TabPageClsRcts.Remove(kv.Key);
                    this.TabPages.RemoveAt(kv.Key);
                    return;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            if (!IsHandleCreated)
                return;
            Point pMouse = MousePosition;
            pMouse = this.PointToClient(pMouse);

            //不处理首页
            for (int i = this.TabCount - 1; i > 0; --i)
            {
                Rectangle r = this._TabPageClsRcts[i];
                bool mState = this._TabPageMouseState[i];
                if (r.Contains(pMouse) != mState)
                {
                    this._TabPageMouseState[i] = !mState;
                    this.Invalidate(r, false);
                }
            }
        }
    }
}
