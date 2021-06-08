
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
            this.split_LeftWithRight = new System.Windows.Forms.SplitContainer();
            this.split_OrderlstWithNotice = new System.Windows.Forms.SplitContainer();
            this.uc_orderlst = new DataStructureTB.Control.OrderListControl();
            this.panel_notice = new System.Windows.Forms.Panel();
            this.panel_controlPanel = new System.Windows.Forms.Panel();
            this.tabs = new DataStructureTB.Control.TabControlUC();
            this.tab_home = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.split_LeftWithRight)).BeginInit();
            this.split_LeftWithRight.Panel1.SuspendLayout();
            this.split_LeftWithRight.Panel2.SuspendLayout();
            this.split_LeftWithRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_OrderlstWithNotice)).BeginInit();
            this.split_OrderlstWithNotice.Panel1.SuspendLayout();
            this.split_OrderlstWithNotice.Panel2.SuspendLayout();
            this.split_OrderlstWithNotice.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tab_home.SuspendLayout();
            this.SuspendLayout();
            // 
            // split_LeftWithRight
            // 
            this.split_LeftWithRight.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.split_LeftWithRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_LeftWithRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.split_LeftWithRight.Location = new System.Drawing.Point(3, 3);
            this.split_LeftWithRight.Name = "split_LeftWithRight";
            // 
            // split_LeftWithRight.Panel1
            // 
            this.split_LeftWithRight.Panel1.Controls.Add(this.split_OrderlstWithNotice);
            // 
            // split_LeftWithRight.Panel2
            // 
            this.split_LeftWithRight.Panel2.Controls.Add(this.panel_controlPanel);
            this.split_LeftWithRight.Size = new System.Drawing.Size(766, 441);
            this.split_LeftWithRight.SplitterDistance = 485;
            this.split_LeftWithRight.SplitterIncrement = 2;
            this.split_LeftWithRight.TabIndex = 2;
            // 
            // split_OrderlstWithNotice
            // 
            this.split_OrderlstWithNotice.Cursor = System.Windows.Forms.Cursors.HSplit;
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
            this.split_OrderlstWithNotice.Size = new System.Drawing.Size(485, 441);
            this.split_OrderlstWithNotice.SplitterDistance = 220;
            this.split_OrderlstWithNotice.TabIndex = 1;
            // 
            // uc_orderlst
            // 
            this.uc_orderlst.AutoScroll = true;
            this.uc_orderlst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc_orderlst.Cursor = System.Windows.Forms.Cursors.Default;
            this.uc_orderlst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_orderlst.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.uc_orderlst.Location = new System.Drawing.Point(0, 0);
            this.uc_orderlst.Margin = new System.Windows.Forms.Padding(2);
            this.uc_orderlst.Name = "uc_orderlst";
            this.uc_orderlst.Padding = new System.Windows.Forms.Padding(5);
            this.uc_orderlst.Size = new System.Drawing.Size(485, 220);
            this.uc_orderlst.TabIndex = 0;
            // 
            // panel_notice
            // 
            this.panel_notice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_notice.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel_notice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_notice.Location = new System.Drawing.Point(0, 0);
            this.panel_notice.Name = "panel_notice";
            this.panel_notice.Size = new System.Drawing.Size(485, 217);
            this.panel_notice.TabIndex = 0;
            // 
            // panel_controlPanel
            // 
            this.panel_controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_controlPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel_controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_controlPanel.Location = new System.Drawing.Point(0, 0);
            this.panel_controlPanel.Name = "panel_controlPanel";
            this.panel_controlPanel.Size = new System.Drawing.Size(277, 441);
            this.panel_controlPanel.TabIndex = 0;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tab_home);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabs.ItemSize = new System.Drawing.Size(100, 26);
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(780, 481);
            this.tabs.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tab_home.Controls.Add(this.split_LeftWithRight);
            this.tab_home.Location = new System.Drawing.Point(4, 30);
            this.tab_home.Name = "tabPage1";
            this.tab_home.Padding = new System.Windows.Forms.Padding(3);
            this.tab_home.Size = new System.Drawing.Size(772, 447);
            this.tab_home.TabIndex = 0;
            this.tab_home.Text = "首页";
            this.tab_home.UseVisualStyleBackColor = true;
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
            this.split_LeftWithRight.Panel1.ResumeLayout(false);
            this.split_LeftWithRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_LeftWithRight)).EndInit();
            this.split_LeftWithRight.ResumeLayout(false);
            this.split_OrderlstWithNotice.Panel1.ResumeLayout(false);
            this.split_OrderlstWithNotice.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_OrderlstWithNotice)).EndInit();
            this.split_OrderlstWithNotice.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tab_home.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Control.OrderListControl uc_orderlst;
        private System.Windows.Forms.SplitContainer split_LeftWithRight;
        private System.Windows.Forms.SplitContainer split_OrderlstWithNotice;
        private System.Windows.Forms.Panel panel_notice;
        private System.Windows.Forms.Panel panel_controlPanel;
        private Control.TabControlUC tabs;
        private System.Windows.Forms.TabPage tab_home;
    }
}

