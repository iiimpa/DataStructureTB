
namespace DataStructureTB.Control
{
    partial class WebBrowserUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebBrowserUC));
            this.tlsp_chormeTool = new System.Windows.Forms.ToolStrip();
            this.tls_back = new System.Windows.Forms.ToolStripButton();
            this.tls_forward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tls_refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tls_lbl_href = new System.Windows.Forms.ToolStripLabel();
            this.panel_browerContainer = new System.Windows.Forms.Panel();
            this.txt_href = new System.Windows.Forms.TextBox();
            this.tlsp_chormeTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsp_chormeTool
            // 
            this.tlsp_chormeTool.CanOverflow = false;
            this.tlsp_chormeTool.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlsp_chormeTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tls_back,
            this.tls_forward,
            this.toolStripSeparator1,
            this.tls_refresh,
            this.toolStripSeparator2,
            this.tls_lbl_href});
            this.tlsp_chormeTool.Location = new System.Drawing.Point(0, 0);
            this.tlsp_chormeTool.Name = "tlsp_chormeTool";
            this.tlsp_chormeTool.ShowItemToolTips = false;
            this.tlsp_chormeTool.Size = new System.Drawing.Size(733, 27);
            this.tlsp_chormeTool.TabIndex = 1;
            this.tlsp_chormeTool.Text = "toolStrip1";
            // 
            // tls_back
            // 
            this.tls_back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tls_back.Image = ((System.Drawing.Image)(resources.GetObject("tls_back.Image")));
            this.tls_back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_back.Name = "tls_back";
            this.tls_back.Size = new System.Drawing.Size(43, 24);
            this.tls_back.Text = "后退";
            this.tls_back.Click += new System.EventHandler(this.tls_back_Click1);
            // 
            // tls_forward
            // 
            this.tls_forward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tls_forward.Image = ((System.Drawing.Image)(resources.GetObject("tls_forward.Image")));
            this.tls_forward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_forward.Name = "tls_forward";
            this.tls_forward.Size = new System.Drawing.Size(43, 24);
            this.tls_forward.Text = "前进";
            this.tls_forward.Click += new System.EventHandler(this.tls_forward_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tls_refresh
            // 
            this.tls_refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tls_refresh.Image = ((System.Drawing.Image)(resources.GetObject("tls_refresh.Image")));
            this.tls_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_refresh.Name = "tls_refresh";
            this.tls_refresh.Size = new System.Drawing.Size(43, 24);
            this.tls_refresh.Text = "刷新";
            this.tls_refresh.Click += new System.EventHandler(this.tls_refresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tls_lbl_href
            // 
            this.tls_lbl_href.Name = "tls_lbl_href";
            this.tls_lbl_href.Size = new System.Drawing.Size(54, 24);
            this.tls_lbl_href.Text = "地址：";
            // 
            // panel_browerContainer
            // 
            this.panel_browerContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_browerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_browerContainer.Location = new System.Drawing.Point(0, 27);
            this.panel_browerContainer.Margin = new System.Windows.Forms.Padding(4);
            this.panel_browerContainer.Name = "panel_browerContainer";
            this.panel_browerContainer.Size = new System.Drawing.Size(733, 295);
            this.panel_browerContainer.TabIndex = 2;
            // 
            // txt_href
            // 
            this.txt_href.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_href.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_href.Location = new System.Drawing.Point(215, 4);
            this.txt_href.Margin = new System.Windows.Forms.Padding(4);
            this.txt_href.Name = "txt_href";
            this.txt_href.Size = new System.Drawing.Size(513, 20);
            this.txt_href.TabIndex = 3;
            this.txt_href.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_href_KeyPress);
            // 
            // WebBrowserUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_href);
            this.Controls.Add(this.panel_browerContainer);
            this.Controls.Add(this.tlsp_chormeTool);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WebBrowserUC";
            this.Size = new System.Drawing.Size(733, 322);
            this.tlsp_chormeTool.ResumeLayout(false);
            this.tlsp_chormeTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsp_chormeTool;
        private System.Windows.Forms.ToolStripButton tls_back;
        private System.Windows.Forms.ToolStripButton tls_forward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tls_refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tls_lbl_href;
        private System.Windows.Forms.Panel panel_browerContainer;
        private System.Windows.Forms.TextBox txt_href;
    }
}
