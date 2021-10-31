using ITI.UserToken.Data;
using ITI.UserToken.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.UserToken.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContext Context;
        IModelRepository<User> UserRepo;
        public UnitOfWork(IDBContextFactory _Context, IModelRepository<User> _UserRepo)
        {
            Context = _Context.GetContext();
            UserRepo = _UserRepo;
        }
        public IModelRepository<User> GetUserRepo()
        {
            return UserRepo;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
 