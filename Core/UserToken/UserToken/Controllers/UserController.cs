using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserToken.Data;
using UserToken.Models;
using UserToken.ViewModels;

namespace UserToken.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        MemoryStorage Data = new MemoryStorage();
        //static List<User> Users
        //    = new List<User>()
        //    {
        //        new User{ID=1, Password="Sohag", UserName = "Alshaimaa"}
        //    };

        [Route("GetData")]
        public ActionResult<ResultViewModel> GetData()
        {
            result.Data = "This is all of our data";
            return result;
        }

        ResultViewModel result = new ResultViewModel();

        [Route("Login")]
        public ActionResult<ResultViewModel> Login(string password, string userName)
        {
            User user = Data.Users.Where(i => i.Password == password && i.UserName == userName).FirstOrDefault();

            if (user == null)
            {
                result.Massage = "Not Found";
                return result;
            }

            //string token = Guid.NewGuid().ToString();
            string token = userName.ToLower() + password.ToLower();
            result.Massage = "this Success";
            HttpContext.Session.SetString("token",token);

            result.Data = token;

            return result;
        }
    }
}
