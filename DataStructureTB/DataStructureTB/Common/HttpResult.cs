using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataStructureTB.Common
{
    /// <summary>
    /// http访问得到的结果
    /// </summary>
    internal abstract class  HttpResult
    {
        internal abstract bool IsComplete { get;}
        internal HttpStatusCode Code { get; set; }
        internal bool IsCallSuccess { get; set; }

        internal abstract T GetResult<T>();
    }
}
