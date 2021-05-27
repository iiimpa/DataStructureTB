using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using DataStructureTB.Control;

namespace DataStructureTB
{
    public partial class BrowserForm : Form
    {
        public BrowserForm()
        {
            InitializeComponent();
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            var chrome = new ChromeDriver("https://login.taobao.com/member/login.jhtml");
            chrome.Dock = DockStyle.Fill;
            this.Controls.Add(chrome);
        }
    }
}
