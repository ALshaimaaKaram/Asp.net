using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.UserTokenAPI.Data
{
    public class DBContextFactory:IDBContextFactory
    {
        private readonly DbContext Context;

        public DBContextFactory()
        {
            Context = Context ?? new POSDBContext();
        }

        public DbContext GetContext()
        {
            return Context;
        }
    }
}
