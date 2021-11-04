using ITI.UserTokenAPI.Models;
using ITI.UserTokenAPI.Repository;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows;
using ViewModels;
using ViewModels.User;

namespace ITI.UserTokenAPI.Present.Controllers
{
    public class UserController : ApiController
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

        ResultViewModel Result = new ResultViewModel();

        public IEnumerable<UserViewModel> getUsers()
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
        public IEnumerable<UserViewModel> Search(string Mobile, string UserName)
        {
            var UserSearch = UserRepository.Get().Where(i => i.Mobile == Mobile || i.UserName == UserName).OrderBy(i => i.UserName)
                .ToList().Select(c => c.ToViewModel());

            return UserSearch;
        }

        [HttpGet]
        public void Login()
        {

        }

        [HttpPost]
        public User Login(UserLoginViewModel User)
        {
            if (!ModelState.IsValid)
                return new User();

            User UserLogin = UserRepository.Get().FirstOrDefault(
                i => i.UserName == User.UserName && i.Password == User.Password);

            if (UserLogin == null)
                return new User();

            //Session["User"] = User;

            return UserLogin;
        }

        //[CustomAuthentication]
        //[CustomAuthorization]
        //[CustomAction]
        //[CustomResult]
        //[CheckUserIdentity]
        //[OutputCache(Duration = 10, Location = System.Web.UI.OutputCacheLocation.Client)]

        [HttpGet]
        public ResultViewModel index()
        {
            //var users = pagenation();
            Result.Data = getUsers();
            //viewbag.count = getusers().count() / 5;
            return Result;
        }
        [HttpPost]
        public ResultViewModel index(int? page, string sortOrder)
        {

            var Users = getUsers();

            string userName = String.IsNullOrEmpty(sortOrder) ? "user_desc" : "";
            string mobile = sortOrder == "Mobile" ? "mobile_desc" : "Mobile";

            //var Users = getUsers();

            switch (sortOrder)
            {
                case "user_desc":
                    Users = Users.OrderByDescending(s => s.UserName);
                    break;
                case "Mobile":
                    Users = Users.OrderBy(s => s.Mobile);
                    break;
                case "mobile_desc":
                    Users = Users.OrderByDescending(s => s.Mobile);
                    break;
                default:
                    Users = Users.OrderBy(s => s.UserName);
                    break;
            }

            Result.Data = getUsers();
            return Result;
        }


        public IEnumerable<UserViewModel> SortDesc()
        {
            var Users = getUsers().OrderByDescending(i => i.UserName);

            return Users;
        }

        public IEnumerable<UserViewModel> Sort()
        {
            var Users = getUsers().OrderBy(i => i.UserName);

            return Users;
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

        //[CheckUserIdentity]
        [HttpPost]
        public UserViewModel Create(int id, string UserName, string Address, string Mobile, string Password)
        {
            //Thread.Sleep(5000);
            //ViewBag.Title = "Create";

            User User = new User();
            User.ID = id;
            User.Mobile = Mobile;
            User.UserName = UserName;
            User.Address = Address;
            User.Password = Password;



            UserViewModel UserAdd = User.ToViewModel();
            UserRepository.Add(User);

            TokenRepository.Add(new Token() { UserID = UserAdd.ID, Code = Guid.NewGuid().ToString() });

            UnitOfWork.Save();

            ModelState.Clear();
            return UserAdd;
        }

        //[CheckUserIdentity]
        [HttpGet]
        public UserViewModel Details(int? id)
        {
            //throw new Exception();
            if (id == null || id <= 0)
                return new UserViewModel();

            //ViewBag.Title = $"Details User with {id}";
            User User = UserRepository.Get(id.Value);
            if (User == null)
                return new UserViewModel();

            return User.ToViewModel();
        }

        [HttpGet]
        public UserEditViewModel Edit(int? id)
        {

            if (id == null || id <= 0)
                return new UserEditViewModel();

            //ViewBag.Title = $"Edit User with {id}";
            User User = UserRepository.Get(id.Value);
            if (User == null)
                return new UserEditViewModel();

            return User.ToEditableModel();
        }

        //[CheckUserIdentity]
        [HttpPost]
        public void Edit(UserEditViewModel User)
        {
            //ViewBag.Title = "Edit User";


            if (ModelState.IsValid)
            {
                UserRepository.Edit(User.ToModel());
                UnitOfWork.Save();

                return;
            }

            return;
        }
        //[CheckUserIdentity]
        [HttpGet]
        [Route("Delete")]
        public void Delete(int? id)
        {

            if (id == null || id <= 0)
                return;

            UserRepository.Remove(new User() { ID = id.Value });
            UnitOfWork.Save();

            return;
            //return Redirect("/User/index");
        }
    }
}
