using ITI.CURDAPI.Data;
using ITI.CURDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CURDAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        DBContext context;
        IModelRepository<Employee> empRepo;
        public UnitOfWork(DBContext _context, IModelRepository<Employee> _empRepo)
        {
            context = _context;
            empRepo = _empRepo;
        }

        public IModelRepository<Employee> GetEmpRepo()
        {
            return empRepo;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
