using DataStructureTB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Common.HttpAccessClients
{
    internal class LogoutHttpAccess: ClientHttpAccessBase
    {
        internal LoginApiModel LogoutUser(string user_id)
        {
            try
            {
                HttpResult result = HttpAccessManager.Inst.HttpAccess(nameof(HttpApiConfig.Logout), new
                {
                    user_id,
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
