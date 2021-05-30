namespace DataStructureTB.Control
{
    partial class Order
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
            this.btn_use = new System.Windows.Forms.Button();
            this.lb_title = new System.Windows.Forms.Label();
            this.lb_duedate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_use
            // 
            this.btn_use.Location = new System.Drawing.Point(224, 57);
            this.btn_use.Name = "btn_use";
            this.btn_use.Size = new System.Drawing.Size(105, 28);
            this.btn_use.TabIndex = 0;
            this.btn_use.Text = "立即使用";
            this.btn_use.UseVisualStyleBackColor = true;
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_title.Location = new System.Drawing.Point(16, 15);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(197, 25);
            this.lb_title.TabIndex = 1;
            this.lb_title.Text = "女装/女士精品(标准版)";
            // 
            // lb_duedate
            // 
            this.lb_duedate.AutoSize = true;
            this.lb_duedate.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_duedate.Location = new System.Drawing.Point(16, 66);
            this.lb_duedate.Name = "lb_duedate";
            this.lb_duedate.Size = new System.Drawing.Size(144, 19);
            this.lb_duedate.TabIndex = 2;
            this.lb_duedate.Text = "有效期至: 2021-05-29";
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lb_duedate);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.btn_use);
            this.Name = "Order";
            this.Size = new System.Drawing.Size(346, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_use;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.Label lb_duedate;
    }
}
