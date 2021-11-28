using ITI.CURDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CURDAPI.Repositories
{
    public interface IUnitOfWork
    {
        IModelRepository<Employee> GetEmpRepo();
        Task Save();
    }
}
