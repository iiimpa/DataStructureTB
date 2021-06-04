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
        private byte OutPutCurrent()
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
            //当前总共能够输出的数据大小
            long totalLength = Math.Min(output.Length, this.OutputLastly);

            byte[] block = new byte[1024];     //数据输出块
            int dataWrited = 0;
            int blockPos = 0;
            while (dataWrited < totalLength)
            {
                //将数据填充至块
                for (blockPos = 0; blockPos < block.Length && dataWrited <= totalLength && this.OutputNext(); ++blockPos, ++dataWrited)
                {
                    block[blockPos] = this.OutPutCurrent();
                }
                //将数据块输出
                output.Write(block, 0, blockPos);
            }

            //记录输出量的总数
            this.OutputCount += (uint)totalLength;
            return (uint)totalLength;
        }
    }
}
