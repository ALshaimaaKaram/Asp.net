using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
    }

    public static class UserViewModelExtentions
    {
        public static UserViewModel ToViewModel(this ITI.UserTokenAPI.Models.User User)
        {
            return new UserViewModel()
            {
                ID = User.ID,
                UserName = User.UserName,
                Code = User.Tokens?.FirstOrDefault()?.Code,
                Address = User.Address,
                Mobile = User.Mobile
            };
        }
    }
}
