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
            AppStartup.AppInitializer();
        }

        private static void AppInitializer()
        {
            LoginOperatorSvr.InitLoginServer();
        }

        internal static void Startup()
        {
            AppMainOperatorSvr appLifeTimeSvr = new AppMainOperatorSvr();
            LoginOperatorSvr loginServer = new LoginOperatorSvr();

            //登录验证
            loginServer.GoLogin();
            if(loginServer.IsLoginSuccess)
            {
                appLifeTimeSvr.EnterMainLifeTime();//进入主程序
            }
        }
    }
}
