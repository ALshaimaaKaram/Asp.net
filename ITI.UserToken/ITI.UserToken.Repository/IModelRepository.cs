using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.UserToken.Repository
{
    public interface IModelRepository<T>
    {
        void Add(T entity);
        T Get(int ID);
        IQueryable<T> Get();
        void Remove(T entity);
        void Edit(T entity);
    }
}
