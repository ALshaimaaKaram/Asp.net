using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.UserTokenAPI.Data
{
    public interface IDBContextFactory
    {
        DbContext GetContext();
    }
}
