using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Common
{
    /// <summary>
    /// http响应结果的处理方式标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    internal class UrlResultHandleAttribute : Attribute
    {
        internal UrlResultHandleAttribute()
        {
        }
        internal UrlResultHandleAttribute(Type handlType)
        {
            if (handlType == null || !typeof(IHttpResultHandle).IsAssignableFrom(handlType))
                throw new ArgumentException($"该类型不是{nameof(IHttpResultHandle)}接口的实现者");

            this.ResultHandleType = handlType;
        }

        /// <summary>
        /// 能够对http响应结果进行处理的类型
        /// </summary>
        internal Type ResultHandleType { get; set; }
    }
}
