using System;
using System.ComponentModel;
using DataStructureTB.Model;

namespace DataStructureTB.Common
{
    /// <summary>
    /// http接口管理
    /// </summary>
    internal class HttpApiConfig
    {
        //标记请求为get
        [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
        internal class HttpGetAttribute : DescriptionAttribute
        { }

        //标记接口请求为post
        [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
        internal class HttpPostAttribute : DescriptionAttribute 
        { }




        [HttpPost, UrlResultHandle(typeof(ObjectHttpResultHandle<LoginApiModel>)), Description("登录接口")]
        internal const string Login = "http://apiyebushui.com/index/index/login.html";

        [HttpPost, UrlResultHandle((typeof(StringHttpResultHandle))), Description("订单详情接口")]
        internal const string OrderDetails = "http://api.yebushui.com/index/index/order_info.html";
    }
}
