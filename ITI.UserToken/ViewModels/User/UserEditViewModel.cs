using ITI.UserToken.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Validation;

namespace ViewModels
{
    public class UserEditViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "UserName Required")]
        [MaxLength(20, ErrorMessage = "Should Be At Most 10 Characters")]
        [MinLength(6, ErrorMessage = "Should Be At Less 6 Chars")]
        [EmailAddress(ErrorMessage = "Not Valid Email")]
        [ITIEmail(ErrorMessage = "Not ITI email")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [MaxLength(20, ErrorMessage = "Should Be At Most 10 Characters")]
        [MinLength(6, ErrorMessage = "Should Be At Less 6 Chars")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Address Required")]
        [MaxLength(500)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Mobile Required")]
        [MaxLength(12)]
        public string Mobile { get; set; }
    }

    public static class UserEditViewModelExtentions
    {
        public static ITI.UserToken.Models.User ToModel(this UserEditViewModel UserEditViewModel)
        {
            return new ITI.UserToken.Models.User()
            {
                ID = UserEditViewModel.ID,
                UserName = UserEditViewModel.UserName,
                Password = UserEditViewModel.Password,
                Address = UserEditViewModel.Address,
                Mobile = UserEditViewModel.Mobile
            };
        }

        public static UserEditViewModel ToEditableModel(this ITI.UserToken.Models.User User)
        {
            return new UserEditViewModel()
            {
                ID = User.ID,
                UserName = User.UserName,
                Address = User.Address,
                Mobile = User.Mobile
            };
        }
    }
}
