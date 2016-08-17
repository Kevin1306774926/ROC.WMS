using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROC.Modles;
using System.Runtime.Remoting.Messaging;

namespace ROC.DAL
{
    public class DbSessionFactory:IDbSessionFactory
    {

        public IDbSession GetCurrentDbSession()
        {
            IDbSession dbSession = CallContext.GetData(typeof(DbSession).FullName) as IDbSession;
            if (dbSession == null)
            {
                dbSession = new DbSession();
                CallContext.SetData(typeof(DbSession).FullName, dbSession);
            }
            return dbSession;
        }
    }
}
