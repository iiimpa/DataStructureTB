using Jil;
using System;
using CefSharp;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace DataStructureTB.Handlers 
{
    /// <summary>
    /// 通用请求响应的过滤处理
    /// </summary>
    internal class GenericResponseHandle : IResponseFilter
    {
        public bool InitFilter()
        {
            return true;
        }

        public FilterStatus Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {
            dataInRead = dataOutWritten = 0;
            //插入script标签


            //dataIn.CopyTo(dataOut, (int)Math.Min(dataOut.Length, dataIn.Length));
            //dataInRead = dataIn.Length;
            //dataOutWritten = dataOut.Length;
            //dataIn.Seek(0, SeekOrigin.Begin);
            //using (StreamReader read = new StreamReader(dataIn, Encoding.UTF8))
            //{
            //    Console.WriteLine(read.ReadToEnd());
            //}


            //dataInRead = dataOutWritten = 0;
            return FilterStatus.Done;
        }

        public void Dispose()
        { }
    }
}
