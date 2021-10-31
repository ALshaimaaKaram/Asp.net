using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.UserToken.Models;

namespace ViewModels
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Code { get; set; }
    }

    public static class UserViewModelExtentions
    {
        public static UserViewModel ToViewModel(this User User)
        {
            return new UserViewModel()
            {
                ID = User.ID,
                UserName = User.UserName,
                Code = User.Tokens?.FirstOrDefault()?.Code
            };
        }
    }
}
