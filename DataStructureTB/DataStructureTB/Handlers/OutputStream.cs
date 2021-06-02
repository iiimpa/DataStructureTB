using System;
using System.IO;
using System.Collections.Generic;

namespace DataStructureTB.Handlers
{
    /// <summary>
    /// 数据输出端
    /// </summary>
    internal class OutputStream
    {
        internal OutputStream()
        {
            this.outCached = new LinkedList<byte>();
        }


        private LinkedList<byte> outCached;
        private LinkedListNode<byte> outPos;


        /// <summary>
        /// 接收数据的总量
        /// </summary>
        internal uint ReceiveCount { get; private set; }
        /// <summary>
        /// 输出数据的总量
        /// </summary>
        internal uint OutputCount { get; private set; }
        internal uint OutputLastly => (uint)this.outCached.Count;

        private bool OutputNext()
        {
            if (this.outCached.First == null)
                return false;

            this.outPos = this.outCached.First;
            this.outCached.RemoveFirst();
            return true;
        }
        private byte Current()
        {
            return this.outPos.Value;
        }


        internal uint Receive(byte[] input)
        {
            if(input != null)
            {
                foreach (byte b in input)
                    this.outCached.AddLast(b);

                this.ReceiveCount += (uint)input.Length;
                return (uint)input.Length;
            }
            return 0;
        }

        internal uint Output(Stream output)
        {
            long totalLength = Math.Min(output.Length, this.OutputLastly);

            byte[] bs = new byte[1024];
            int writed = 0;
            int i = 0;
            while (writed < totalLength)
            {
                for (i = 0; i < bs.Length && writed <= totalLength && this.OutputNext(); ++i, ++writed)
                {
                    bs[i] = this.Current();
                }
                output.Write(bs, 0, i);
            }

            this.OutputCount += (uint)totalLength;
            return (uint)totalLength;
        }
    }
}
