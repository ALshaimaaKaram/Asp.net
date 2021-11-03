using ITI.UserToken.Models;
using ITI.UserToken.Presentation.Filters;
using ITI.UserToken.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using ViewModels.User;

namespace ITI.UserToken.Presentation.Controllers
{
    [HandleError]
    public class UserController : Controller
    {
        IUnitOfWork UnitOfWork;
        IModelRepository<User> UserRepository;
        IModelRepository<Token> TokenRepository;
        public UserController(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
            UserRepository = UnitOfWork.GetUserRepo();
            TokenRepository = UnitOfWork.GetTokenRepo();
        }

        private IEnumerable<UserViewModel> getUsers()
        {
            return UserRepository.Get()
                        .Select(i => new UserViewModel()
                        {
                            ID = i.ID,
                            UserName = i.UserName,
                            Address = i.Address,
                            Mobile = i.Mobile
                        }).ToList();
        }


        [HttpPost]
        public ActionResult Search(string Mobile, string UserName)
        {
            var UserSearch = UserRepository.Get().Where(i => i.Mobile == Mobile || i.UserName == UserName).OrderBy(i => i.UserName)
                .ToList().Select(c => c.ToViewModel());

            return View("index", UserSearch);
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

        [CustomAuthentication]
        [CustomAuthorization]
        [CustomAction]
        [CustomResult]
        [CheckUserIdentity]
        [OutputCache(Duration = 10, Location = System.Web.UI.OutputCacheLocation.Client)]
        [HttpGet]
        public ActionResult index(int? page)
        {
            ViewBag.Title = "Index";


            //var Users = Pagenation(); 
            var Users = getUsers().ToList().ToPagedList(page ?? 1,5);

            ViewBag.Count = getUsers().Count() / 5;

            return View(Users);
        }

        public ActionResult SortDesc()
        {
            var Users = getUsers().OrderByDescending(i => i.UserName).Take(5);

            return View("index",Users);
        }

        public ActionResult Sort()
        {
            var Users = getUsers().OrderBy(i => i.UserName).Take(5);

            return View("index", Users);
        }

         static int Count = 0;
        public IEnumerable<UserViewModel> Pagenation()
        {
            
            var UserList = getUsers().Skip(Count).Take(5);

            //(step == "Prev") ?

            Count += 5;

            return UserList;
        }

        public IEnumerable<UserViewModel> PagenationPrev()
        {

            var UserList = getUsers().Skip(Count).Take(5);

            //(step == "Prev") ?

            Count += 5;

            return UserList;
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";

            return View();
        }

        [CheckUserIdentity]
        [HttpPost]
        public ActionResult Create(UserEditViewModel User)
        {
            //Thread.Sleep(5000);
            ViewBag.Title = "Create";


            if (ModelState.IsValid)
            {
                User UserAdd = User.ToModel();
                UserRepository.Add(UserAdd);

                TokenRepository.Add(new Token() { UserID = UserAdd.ID, Code = Guid.NewGuid().ToString() });

                UnitOfWork.Save();

                ModelState.Clear();
                return View();
                //return Redirect("/User/index");
            }

            return View();
        }

        [CheckUserIdentity]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            //throw new Exception();
            if (id == null || id <= 0)
                return Redirect("/User/Login");

            ViewBag.Title = $"Details User with {id}";
            User User = UserRepository.Get(id.Value);
            if (User == null)
                return Redirect("/User/Login");

            return View(User.ToViewModel());
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null || id <= 0)
                return Redirect("/User/Login");

            ViewBag.Title = $"Edit User with {id}";
            User User = UserRepository.Get(id.Value);
            if (User == null)
                return Redirect("/User/Login");

            return View(User.ToEditableModel());
        }

        [CheckUserIdentity]
        [HttpPost]
        public ActionResult Edit(UserEditViewModel User)
        {
            ViewBag.Title = "Edit User";


            if (ModelState.IsValid)
            {
                UserRepository.Edit(User.ToModel());
                UnitOfWork.Save();

                return Redirect("/User/index");
            }

            return View();
        }
        [CheckUserIdentity]
        [HttpGet]
        public ActionResult Delete(int? id)
        {

            if (id == null || id <= 0)
                return Redirect("/User/Login");

            UserRepository.Remove(new User() { ID = id.Value });
            UnitOfWork.Save();

            return PartialView("_UsersInfo", getUsers());
            //return Redirect("/User/index");
        }
    }
}