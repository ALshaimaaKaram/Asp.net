using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CRUDAPI.ViewModel.Role
{
    public class RoleModel
    {
        public string RoleName { get; set; }
    }

    public static class RoleModelExtentions
    {
        public static IdentityRole ToModel(this RoleModel roleModel)
        {
            return new IdentityRole()
            {
                Name = roleModel.RoleName
            };
        }
    }
}
