using ITI.UserToken.Models;
using ITI.UserToken.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using ViewModels.User;

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
            ViewBag.Title = "Index";
            if (Session["User"] == null)
                return Redirect("/User/Login");

            var Users = UserRepository.Get()
                        .Select(i => new UserViewModel()
                        {
                            ID = i.ID,
                            UserName = i.UserName,
                            Address = i.Address,
                            Mobile = i.Mobile
                        }).ToList();

            return View(Users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";

            return View();
        }

        [HttpPost]
        public ActionResult Create(UserEditViewModel User)
        {
            ViewBag.Title = "Create";
            if (Session["User"] == null)
                return Redirect("/User/Login");

            if (ModelState.IsValid)
            {
                UserRepository.Add(User.ToModel());
                UnitOfWork.Save();

                return Redirect("/User/index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "User Login Page";
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel User)
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