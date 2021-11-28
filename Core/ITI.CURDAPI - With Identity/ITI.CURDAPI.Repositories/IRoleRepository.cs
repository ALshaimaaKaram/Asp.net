using ITI.CRUDAPI.ViewModel.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CURDAPI.Repositories
{
    public interface IRoleRepository
    {
        Task<string> CreateRole(RoleModel roleModel);
    }
}
