using System;
using System.Net.Http;
using System.Reflection;

namespace DataStructureTB.Common
{
    /// <summary>
    /// http接口管理类
    /// </summary>
    internal class HttpApiManager
    {
        static HttpApiManager()
        {
            HttpApiManager.Inst = new HttpApiManager();
        }

        private HttpApiManager()
        {
            this.APIConfig = new HttpApiConfig();
        }

        internal HttpApiConfig APIConfig;
        internal static HttpApiManager Inst { get; }



        internal static UrlInfo GetApiInfo(string apiFieldName)
        {
            Type tCng = typeof(HttpApiConfig);
            FieldInfo field = tCng.GetField(apiFieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (field == null)
                throw new ArgumentException($"未存在此url的配置名：{apiFieldName}");

            UrlInfo info = new UrlInfo();
            info.FiledName = apiFieldName;
            info.Url = field.GetValue(HttpApiManager.Inst.APIConfig) as string;
            info.IsPost = field.IsDefined(typeof(HttpApiConfig.HttpPostAttribute), false);
            return info;
        }
        /// <summary>
        /// 获取用于处理url响应的类型
        /// </summary>
        /// <param name="apiFieldName">httpConfig的字段名</param>
        /// <returns>UrlResultHandleAttribute特性中配置的类型</returns>
        internal static Type GetApiResultHandleType(string apiFieldName)
        {
            Type tCng = typeof(HttpApiConfig);
            FieldInfo field = tCng.GetField(apiFieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (field == null)
                throw new ArgumentException($"未存在此url的配置名：{apiFieldName}");

            object[] attrs = field.GetCustomAttributes(typeof(UrlResultHandleAttribute), false);
            if (attrs == null || attrs.Length == 0 || !(attrs[0] is UrlResultHandleAttribute))
                return null;
            return (attrs[0] as UrlResultHandleAttribute).ResultHandleType;
        }
        internal static bool IsPost(string apiFieldName)
        {
            Type tCng = typeof(HttpApiConfig);
            FieldInfo field = tCng.GetField(apiFieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (field == null)
                throw new ArgumentException($"未存在此url的配置名：{apiFieldName}");

            return field.IsDefined(typeof(HttpApiConfig.HttpPostAttribute), false);
        }
        internal static bool IsGet(string apiFieldName)
        {
            Type tCng = typeof(HttpApiConfig);
            FieldInfo field = tCng.GetField(apiFieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (field == null)
                throw new ArgumentException($"未存在此url的配置名：{apiFieldName}");

            return field.IsDefined(typeof(HttpApiConfig.HttpGetAttribute), false);
        }
    }
}
