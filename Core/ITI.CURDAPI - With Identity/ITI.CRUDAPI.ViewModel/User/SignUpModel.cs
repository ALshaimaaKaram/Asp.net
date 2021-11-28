using ITI.CURDAPI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CRUDAPI.ViewModel
{
    public class SignUpModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public static class SignUpModelExtentions
    { 
        public static User ToModel(this SignUpModel signUpModel)
        {
            return new User()
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName,
                UserName = signUpModel.Email,
                Email = signUpModel.Email,
            };
        }
    }
}
