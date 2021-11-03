using ITI.UserTokenAPI.Data;
using ITI.UserTokenAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.UserTokenAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContext Context;
        IModelRepository<User> UserRepo;
        IModelRepository<Token> TokenRepo;
        public UnitOfWork(IDBContextFactory _Context, IModelRepository<User> _UserRepo, IModelRepository<Token> _TokenRepo)
        {
            Context = _Context.GetContext();
            UserRepo = _UserRepo;
            TokenRepo = _TokenRepo;
        }
        public IModelRepository<User> GetUserRepo()
        {
            return UserRepo;
        }
        public IModelRepository<Token> GetTokenRepo()
        {
            return TokenRepo;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
 