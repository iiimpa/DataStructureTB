
namespace DataStructureTB.Control
{
    partial class OrderListControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.flow_left = new System.Windows.Forms.FlowLayoutPanel();
            this.flow_right = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flow_left
            // 
            this.flow_left.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flow_left.AutoSize = true;
            this.flow_left.Location = new System.Drawing.Point(6, 5);
            this.flow_left.MaximumSize = new System.Drawing.Size(281, 0);
            this.flow_left.MinimumSize = new System.Drawing.Size(281, 100);
            this.flow_left.Name = "flow_left";
            this.flow_left.Size = new System.Drawing.Size(281, 100);
            this.flow_left.TabIndex = 0;
            // 
            // flow_right
            // 
            this.flow_right.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flow_right.AutoSize = true;
            this.flow_right.Location = new System.Drawing.Point(290, 5);
            this.flow_right.MaximumSize = new System.Drawing.Size(281, 0);
            this.flow_right.MinimumSize = new System.Drawing.Size(281, 100);
            this.flow_right.Name = "flow_right";
            this.flow_right.Size = new System.Drawing.Size(281, 100);
            this.flow_right.TabIndex = 1;
            // 
            // OrderListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.flow_left);
            this.Controls.Add(this.flow_right);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OrderListControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(576, 117);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flow_left;
        private System.Windows.Forms.FlowLayoutPanel flow_right;
    }
}
