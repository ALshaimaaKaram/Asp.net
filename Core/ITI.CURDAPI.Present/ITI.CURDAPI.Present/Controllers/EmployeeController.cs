using ITI.CURDAPI.Models;
using ITI.CURDAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CURDAPI.Present.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController : ControllerBase
    {
        IModelRepository<Employee> empRepo;
        IUnitOfWork unitOfWork;
        public EmployeeController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            empRepo = _unitOfWork.GetEmpRepo();
        }

        //[HttpGet()]
        //[Route("/Get")] == 
        //[HttpGet("/Get")]
        [HttpGet("")]
        public async Task<IEnumerable<Employee>> Get()
        {
            IEnumerable<Employee> employees = await empRepo.GetAsync();
            return employees;
        }
        
        [HttpPost("Create")]
        public async Task<IEnumerable<Employee>> Post(Employee employee)
        {
            await empRepo.Add(employee);
            await unitOfWork.Save();
            return await empRepo.GetAsync();
        }
        [HttpPatch("{id}")]
        public async Task<Employee> UpdatePatch([FromRoute]int Id, [FromBody]JsonPatchDocument employee)
        {
            Employee temp = await empRepo.UpdatePatch(Id,employee);
            await unitOfWork.Save();
            return temp;
        }

        [HttpPut("")]
        public async Task<Employee> Update(Employee employee)
        {
            Employee temp = await empRepo.Update(employee);
            await unitOfWork.Save();
            return temp;
        }

        [HttpDelete("{id}")]
        public async Task<Employee> Remove(int Id)
        {
            Employee empdeleted = await empRepo.GetByIdAsync(Id);
            Employee temp = await empRepo.Remove(empdeleted);
            await unitOfWork.Save();
            return temp;
        }
        [HttpGet("GetByID/{id}")]
        public async Task<Employee> GetByID(int Id)
        {
            Employee temp = await empRepo.GetByIdAsync(Id);
            return temp;
        }
    }
}
