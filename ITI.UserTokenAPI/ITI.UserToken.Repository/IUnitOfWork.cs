using ITI.UserTokenAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.UserTokenAPI.Repository
{
    public interface IUnitOfWork
    {
        IModelRepository<User> GetUserRepo();
        IModelRepository<Token> GetTokenRepo();
        void Save();
    }
}
