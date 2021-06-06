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
        {
            this.process = process;
            this.midProcess = midProcess;
        }


        private OutputStream output;
        private ProcessStream midProcess;
        private Func<byte[], byte[]> process;


        internal void SetOutput(OutputStream output)
        {
            this.output = output;
        }
        internal void SetStreamProcess(ProcessStream midProcess)
        {
            this.midProcess = midProcess;
        }
        internal void SetProcess(Func<byte[], byte[]> process)
        {
            this.process = process;
        }
        internal uint Receive(byte[] input)
        {
            byte[] ans = this?.process(input);

            this.output?.Receive(ans);
            this.midProcess?.Receive(ans);

            return (uint)input.Length;
        }
    }
}
