using ITI.CRUDAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CURDAPI.Repositories
{
    public interface IUserRepository
    {
        Task<string> SignUp(SignUpModel signUpModel);
       
    }
}
