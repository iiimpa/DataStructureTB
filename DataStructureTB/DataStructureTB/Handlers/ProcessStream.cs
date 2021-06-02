using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Handlers
{
    /// <summary>
    /// 数据中间处理
    /// </summary>
    internal class ProcessStream
    {
        internal ProcessStream(Func<byte[], byte[]> process, ProcessStream midProcess) 
        { }
        internal ProcessStream(Func<byte[], byte[]> process, OutputStream output) 
        {
            this.process = process;
            this.output = output;
        }


        private Func<byte[], byte[]> process;
        private OutputStream output;


        internal uint Receive(byte[] input)
        {
            byte[] ans = this.process(input);
            output.Receive(ans);
            return (uint)input.Length;
        }
    }
}
