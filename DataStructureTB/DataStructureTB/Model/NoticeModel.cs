using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Model
{
    /// <summary>
    /// 表示一个公告信息
    /// </summary>
    internal class NoticeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Time { get; set; }
    }
}
