﻿using CefSharp;
using System;
using System.Collections.Generic;

namespace DataStructureTB.Handlers
{
    internal class KeyboardHandler : CefSharp.Handler.KeyboardHandler
    {
        internal KeyboardHandler() { }

        protected override bool OnKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            if (windowsKeyCode == (int)System.Windows.Forms.Keys.F12)
            {
                chromiumWebBrowser.GetDevToolsClient();
            }
            return base.OnKeyEvent(chromiumWebBrowser, browser, type, windowsKeyCode, nativeKeyCode, modifiers, isSystemKey);
        }
        protected override bool OnPreKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            return base.OnPreKeyEvent(chromiumWebBrowser, browser, type, windowsKeyCode, nativeKeyCode, modifiers, isSystemKey, ref isKeyboardShortcut);
        }
    }
}
