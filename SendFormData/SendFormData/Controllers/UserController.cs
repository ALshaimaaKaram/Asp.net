using SendFormData.Code;
using SendFormData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SendFormData.Controllers
{
    public class UserController : Controller
    {
        public ActionResult index()
        {
            TempData.Keep("User");
            return View(InMemoryUserStorage.Users);
        }

        [HttpGet]
        public ActionResult Login()
        
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User userLogin =
                InMemoryUserStorage.Users.FirstOrDefault(s => s.UserName == user.UserName
                && s.Password == user.Password);

            if (userLogin == null)
                return View();

            #region ViewBag
            //Not Valid because I move data from Action to Action (view to view)
            //ViewBag.IdUser = userLogin.ID;
            //ViewData[UserName] = userLogin.UserName; 
            #endregion

            TempData["User"] = userLogin;
       
            return Redirect("/User/index");
        }

        public ActionResult Display(int ID)
        {
            User userSelection = InMemoryUserStorage.Users.FirstOrDefault(s => s.ID == ID);

            if (userSelection == null)
                return View();

            return View(userSelection);
        }
    }
}