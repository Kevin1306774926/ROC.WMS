using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using ROC.Modles;


namespace ROC.DAL
{
    public class DbContextFactory:IDbContextFactory
    {

        public DbContext GetCurrentThreadInstance()
        {
            DbContext db = CallContext.GetData(typeof(RocContext).FullName) as DbContext;
            if (db == null)
            {
                db = new RocContext();
                CallContext.SetData(typeof(RocContext).FullName, db);
            }
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            return db;
        }
    }
}
