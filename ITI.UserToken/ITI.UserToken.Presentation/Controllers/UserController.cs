using ITI.UserToken.Models;
using ITI.UserToken.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace ITI.UserToken.Presentation.Controllers
{
    public class UserController : Controller
    {
        IUnitOfWork UnitOfWork;
        IModelRepository<User> UserRepository;
        public UserController(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
            UserRepository = UnitOfWork.GetUserRepo();
        }

        [HttpGet]
        public ActionResult index()
        {
            if (Session["User"] == null)
                return Redirect("/User/Login");

            var Users = UserRepository.Get()
                        .ToList().Select(i => i.ToViewModel());

            return View(Users);
        }

        [HttpPost]
        public ActionResult Add(User User)
        {
            if (Session["User"] == null)
                return Redirect("/User/Login");

            UserRepository.Add(User);
            UnitOfWork.Save();

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserEditViewModel User)
        {
            if (!ModelState.IsValid)
                return View();

            User UserLogin = UserRepository.Get().FirstOrDefault(
                i => i.UserName == User.UserName && i.Password == User.Password);

            if (UserLogin == null)
                return View();

            Session["User"] = User;
      
            return Redirect("/User/index");
        }
    }
}