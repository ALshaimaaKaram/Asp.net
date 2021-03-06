using ITI.UserTokenAPI.Data;
using ITI.UserTokenAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.UserTokenAPI.Repository
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
        public void Edit(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public void Remove(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }
        public T Get(int ID)
        {
            return Table.FirstOrDefault(i => i.ID == ID);
        }
        public IQueryable<T> Get()
        {
            return Table;
        }
        public IQueryable<T> GetPaginatedResult(int currentPage, int pageSize = 10)
        {
            var data = Get();
            return data.OrderBy(d => d.ID).Skip((currentPage - 1) * pageSize).Take(pageSize);
        }
    }
}
