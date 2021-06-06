using System;
using System.Windows.Forms;
using DataStructureTB.Common;
using System.Collections.Generic;

namespace DataStructureTB.AppBusine
{
    //程序初始化
    internal static class AppStartup
    {
        static AppStartup()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        internal static void Startup()
        {
            new AppLifeTime().EnterAppLifeTime();
        }
    }
}
