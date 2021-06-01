
namespace DataStructureTB.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabp_home = new System.Windows.Forms.TabPage();
            this.split_LeftWithRight = new System.Windows.Forms.SplitContainer();
            this.split_OrderlstWithNotice = new System.Windows.Forms.SplitContainer();
            this.uc_orderlst = new DataStructureTB.Control.OrderListControl();
            this.panel_notice = new System.Windows.Forms.Panel();
            this.panel_controlPanel = new System.Windows.Forms.Panel();
            this.tabp_web = new System.Windows.Forms.TabPage();
            this.tabs.SuspendLayout();
            this.tabp_home.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_LeftWithRight)).BeginInit();
            this.split_LeftWithRight.Panel1.SuspendLayout();
            this.split_LeftWithRight.Panel2.SuspendLayout();
            this.split_LeftWithRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_OrderlstWithNotice)).BeginInit();
            this.split_OrderlstWithNotice.Panel1.SuspendLayout();
            this.split_OrderlstWithNotice.Panel2.SuspendLayout();
            this.split_OrderlstWithNotice.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabp_home);
            this.tabs.Controls.Add(this.tabp_web);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Margin = new System.Windows.Forms.Padding(4);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(780, 481);
            this.tabs.TabIndex = 0;
            // 
            // tabp_home
            // 
            this.tabp_home.Controls.Add(this.split_LeftWithRight);
            this.tabp_home.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabp_home.Location = new System.Drawing.Point(4, 26);
            this.tabp_home.Margin = new System.Windows.Forms.Padding(4);
            this.tabp_home.Name = "tabp_home";
            this.tabp_home.Padding = new System.Windows.Forms.Padding(4);
            this.tabp_home.Size = new System.Drawing.Size(772, 451);
            this.tabp_home.TabIndex = 0;
            this.tabp_home.Text = "首页";
            this.tabp_home.UseVisualStyleBackColor = true;
            // 
            // split_LeftWithRight
            // 
            this.split_LeftWithRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.split_LeftWithRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_LeftWithRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.split_LeftWithRight.Location = new System.Drawing.Point(4, 4);
            this.split_LeftWithRight.Name = "split_LeftWithRight";
            // 
            // split_LeftWithRight.Panel1
            // 
            this.split_LeftWithRight.Panel1.Controls.Add(this.split_OrderlstWithNotice);
            // 
            // split_LeftWithRight.Panel2
            // 
            this.split_LeftWithRight.Panel2.Controls.Add(this.panel_controlPanel);
            this.split_LeftWithRight.Size = new System.Drawing.Size(764, 443);
            this.split_LeftWithRight.SplitterDistance = 400;
            this.split_LeftWithRight.SplitterIncrement = 2;
            this.split_LeftWithRight.TabIndex = 2;
            // 
            // split_OrderlstWithNotice
            // 
            this.split_OrderlstWithNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_OrderlstWithNotice.Location = new System.Drawing.Point(0, 0);
            this.split_OrderlstWithNotice.Name = "split_OrderlstWithNotice";
            this.split_OrderlstWithNotice.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_OrderlstWithNotice.Panel1
            // 
            this.split_OrderlstWithNotice.Panel1.Controls.Add(this.uc_orderlst);
            // 
            // split_OrderlstWithNotice.Panel2
            // 
            this.split_OrderlstWithNotice.Panel2.Controls.Add(this.panel_notice);
            this.split_OrderlstWithNotice.Size = new System.Drawing.Size(400, 443);
            this.split_OrderlstWithNotice.SplitterDistance = 221;
            this.split_OrderlstWithNotice.TabIndex = 1;
            // 
            // uc_orderlst
            // 
            this.uc_orderlst.AutoScroll = true;
            this.uc_orderlst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc_orderlst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_orderlst.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.uc_orderlst.Location = new System.Drawing.Point(0, 0);
            this.uc_orderlst.Margin = new System.Windows.Forms.Padding(2);
            this.uc_orderlst.Name = "uc_orderlst";
            this.uc_orderlst.Padding = new System.Windows.Forms.Padding(5);
            this.uc_orderlst.Size = new System.Drawing.Size(400, 221);
            this.uc_orderlst.TabIndex = 0;
            // 
            // panel_notice
            // 
            this.panel_notice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_notice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_notice.Location = new System.Drawing.Point(0, 0);
            this.panel_notice.Name = "panel_notice";
            this.panel_notice.Size = new System.Drawing.Size(400, 218);
            this.panel_notice.TabIndex = 0;
            // 
            // panel_controlPanel
            // 
            this.panel_controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_controlPanel.Location = new System.Drawing.Point(0, 0);
            this.panel_controlPanel.Name = "panel_controlPanel";
            this.panel_controlPanel.Size = new System.Drawing.Size(360, 443);
            this.panel_controlPanel.TabIndex = 0;
            // 
            // tabp_web
            // 
            this.tabp_web.Location = new System.Drawing.Point(4, 26);
            this.tabp_web.Name = "tabp_web";
            this.tabp_web.Padding = new System.Windows.Forms.Padding(3);
            this.tabp_web.Size = new System.Drawing.Size(772, 451);
            this.tabp_web.TabIndex = 1;
            this.tabp_web.Text = "web";
            this.tabp_web.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 481);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "淘宝小工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BrowserForm_Load);
            this.tabs.ResumeLayout(false);
            this.tabp_home.ResumeLayout(false);
            this.split_LeftWithRight.Panel1.ResumeLayout(false);
            this.split_LeftWithRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_LeftWithRight)).EndInit();
            this.split_LeftWithRight.ResumeLayout(false);
            this.split_OrderlstWithNotice.Panel1.ResumeLayout(false);
            this.split_OrderlstWithNotice.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_OrderlstWithNotice)).EndInit();
            this.split_OrderlstWithNotice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabp_home;
        private Control.OrderListControl uc_orderlst;
        private System.Windows.Forms.TabPage tabp_web;
        private System.Windows.Forms.SplitContainer split_LeftWithRight;
        private System.Windows.Forms.SplitContainer split_OrderlstWithNotice;
        private System.Windows.Forms.Panel panel_notice;
        private System.Windows.Forms.Panel panel_controlPanel;
    }
}

