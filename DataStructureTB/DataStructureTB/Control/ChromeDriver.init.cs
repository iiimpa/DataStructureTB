using CefSharp.Core;
using DataStructureTB.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Control
{
    partial class ChromeDriver
    {
        private void InitializeComponent()
        {
            //Settings
            base.RequestContext = new RequestContext(new RequestContextSettings()
            {
                CachePath = Environment.CurrentDirectory + "\\Users Data\\Default"
            });

            //Handlers
            base.LifeSpanHandler = new LifeSpanHandler();
            base.RequestHandler = new RequestHandler();
        }
    }
}
