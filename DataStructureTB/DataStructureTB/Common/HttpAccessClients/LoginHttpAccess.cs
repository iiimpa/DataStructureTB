using System;
using DataStructureTB.Model;

namespace DataStructureTB.Common.HttpAccessClients
{
    /// <summary>
    /// 用于访问登录接口
    /// </summary>
    internal class LoginHttpAccess : ClientHttpAccessBase
    {
        internal LoginApiModel LoginUser(string user_name, string user_pass)
        {
            try
            {
                HttpResult result = HttpAccessManager.Inst.HttpAccess(nameof(HttpApiConfig.Login), new
                {
                    user_name,
                    user_pass
                });

                return this.HttpProcess<LoginApiModel>(result);
            }
            catch (Exception ex) 
            {
#if DEBUG   
                throw ex;
#endif
            }

            return null;
        }
    }
}
