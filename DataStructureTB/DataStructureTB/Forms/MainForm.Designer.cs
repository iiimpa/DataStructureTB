
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
            this.uc_orderlst = new DataStructureTB.Control.OrderListControl();
            this.tabp_web = new System.Windows.Forms.TabPage();
            this.tabs.SuspendLayout();
            this.tabp_home.SuspendLayout();
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
            this.tabs.Size = new System.Drawing.Size(1051, 582);
            this.tabs.TabIndex = 0;
            // 
            // tabp_home
            // 
            this.tabp_home.Controls.Add(this.uc_orderlst);
            this.tabp_home.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabp_home.Location = new System.Drawing.Point(4, 26);
            this.tabp_home.Margin = new System.Windows.Forms.Padding(4);
            this.tabp_home.Name = "tabp_home";
            this.tabp_home.Padding = new System.Windows.Forms.Padding(4);
            this.tabp_home.Size = new System.Drawing.Size(1043, 552);
            this.tabp_home.TabIndex = 0;
            this.tabp_home.Text = "首页";
            this.tabp_home.UseVisualStyleBackColor = true;
            // 
            // uc_orderlst
            // 
            this.uc_orderlst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_orderlst.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.uc_orderlst.Location = new System.Drawing.Point(4, 4);
            this.uc_orderlst.Margin = new System.Windows.Forms.Padding(2);
            this.uc_orderlst.Name = "uc_orderlst";
            this.uc_orderlst.Padding = new System.Windows.Forms.Padding(5);
            this.uc_orderlst.Size = new System.Drawing.Size(1035, 544);
            this.uc_orderlst.TabIndex = 0;
            // 
            // tabp_web
            // 
            this.tabp_web.Location = new System.Drawing.Point(4, 26);
            this.tabp_web.Name = "tabp_web";
            this.tabp_web.Padding = new System.Windows.Forms.Padding(3);
            this.tabp_web.Size = new System.Drawing.Size(1043, 552);
            this.tabp_web.TabIndex = 1;
            this.tabp_web.Text = "web";
            this.tabp_web.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 582);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "淘宝小工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BrowserForm_Load);
            this.tabs.ResumeLayout(false);
            this.tabp_home.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabp_home;
        private Control.OrderListControl uc_orderlst;
        private System.Windows.Forms.TabPage tabp_web;
    }
}

