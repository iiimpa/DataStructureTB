using System;
using System.IO;
using System.Collections.Generic;

namespace DataStructureTB.Handlers
{
    /// <summary>
    /// 数据输入端
    /// </summary>
    internal class InputStream
    {
        internal InputStream()
        { }

        internal uint SendCount { get; private set; }
        internal ProcessStream Process { get; set; }

        internal uint Input(Stream input)
        {
            if (input == null || !input.CanRead)
                return 0;

            byte[] bs = new byte[input.Length];
            int count = input.Read(bs, 0, bs.Length);
            this.Process.Receive(bs);
            this.SendCount += (uint)count;

            return (uint)count;
        }
        internal uint Input(byte[] input)
        {
            if (input == null)
                return 0;

            this.Process.Receive(input);
            this.SendCount += (uint)input.Length;
            return (uint)input.Length;
        }
    }
}
