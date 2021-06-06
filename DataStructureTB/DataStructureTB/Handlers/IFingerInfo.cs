﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Handlers
{
    /// <summary>
    /// 一些指纹信息
    /// </summary>
    internal interface IFingerInfo
    {
        int CookieId { get; set; }
        string Cookie { get; set; }
        string Fingerprint { get; set; }

        //淘宝账户
        string TaoUser { get; set; }
        string TaoPass { get; set; }
    }
}
