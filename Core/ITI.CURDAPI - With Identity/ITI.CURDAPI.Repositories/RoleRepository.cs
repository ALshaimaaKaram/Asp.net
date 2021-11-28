using ITI.CRUDAPI.ViewModel.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CURDAPI.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        RoleManager<IdentityRole> roleManager;
        public IConfiguration configuration { get; }
        public RoleRepository(RoleManager<IdentityRole> _roleManager, IConfiguration _configuration)
        {
            roleManager = _roleManager;
            configuration = _configuration;
        }

        public async Task<string> CreateRole(RoleModel roleModel)
        {
            IdentityResult result = await roleManager.CreateAsync(roleModel.ToModel());
            if (!result.Succeeded)
                return null;



        }
    }
}
