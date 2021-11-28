using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CURDAPI.Repositories
{
    public interface IModelRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(int Id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> UpdatePatch(int Id, JsonPatchDocument entity);
        Task<T> Remove(T entity);
    }
}
