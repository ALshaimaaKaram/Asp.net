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
    }

    public static class UserEditViewModelExtentions
    {
        public static User ToModel(this UserEditViewModel UserEditViewModel)
        {
            return new User()
            {
                ID = UserEditViewModel.ID,
                UserName = UserEditViewModel.UserName,
                Password = UserEditViewModel.Password
            };
        }
    }
}
