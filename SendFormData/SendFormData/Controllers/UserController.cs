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

            //TempData["SelectedUser"] = userLogin;
            ViewBag.IdUser = userLogin.ID;
            ViewBag.UserName = userLogin.UserName;
            return View("~/Views/User/index.cshtml");
        }
    }
}