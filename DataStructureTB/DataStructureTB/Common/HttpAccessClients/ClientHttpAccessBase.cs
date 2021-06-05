using System;

namespace DataStructureTB.Common.HttpAccessClients
{
    internal class ClientHttpAccessBase
    {
        protected T HttpProcess<T>(HttpResult httpResult)
        {
            try
            {

                return httpResult.GetResult<T>();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }
            return default(T);
        }

    }
}
