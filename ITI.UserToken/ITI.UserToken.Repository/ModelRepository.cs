using ITI.UserToken.Data;
using ITI.UserToken.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.UserToken.Repository
{
    public class ModelRepository<T> : IModelRepository<T> where T:BaseModel
    {
        DbContext Context;
        DbSet<T> Table;
        public ModelRepository(IDBContextFactory _Factory)
        {
            Context = _Factory.GetContext();
            Table = Context.Set<T>();
        }
        public void Add(T entity)
        {
            Table.Add(entity);
        }
        public T Get(int ID)
        {
            return Table.FirstOrDefault(i => i.ID == ID);
        }
        public IQueryable<T> Get()
        {
            return Table;
        }
        public void Remove(int ID)
        {
            Table.Remove(Get(ID));
        }
    }
}
