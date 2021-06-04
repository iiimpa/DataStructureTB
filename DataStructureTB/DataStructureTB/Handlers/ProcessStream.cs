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
        internal ProcessStream()
        { }
        internal ProcessStream(Func<byte[], byte[]> process, OutputStream output) 
        {
            this.process = process;
            this.output = output;
        }
        internal ProcessStream(Func<byte[], byte[]> process, ProcessStream midProcess) 
        { }


        private OutputStream output;
        private Func<byte[], byte[]> process;


        internal void SetOutput(OutputStream output)
        {
            this.output = output;
        }
        internal void SetProcess(Func<byte[], byte[]> process)
        {
            this.process = process;
        }
        internal uint Receive(byte[] input)
        {
            byte[] ans = this.process(input);
            output.Receive(ans);
            return (uint)input.Length;
        }
    }
}
