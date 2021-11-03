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

        [System.Web.Mvc.HttpPost]
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
        [Route("Get")]
        public IEnumerable<UserViewModel> index()
        {
            var Users = Pagenation();

            //ViewBag.Count = getUsers().Count() / 5;

            return Users;
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

        [HttpGet]
        public void Create()
        {
            //ViewBag.Title = "Create";

            return;
        }

        //[CheckUserIdentity]
        [HttpPost]
        public void Create(UserEditViewModel User)
        {
            //Thread.Sleep(5000);
            //ViewBag.Title = "Create";


            if (ModelState.IsValid)
            {
                User UserAdd = User.ToModel();
                UserRepository.Add(UserAdd);

                TokenRepository.Add(new Token() { UserID = UserAdd.ID, Code = Guid.NewGuid().ToString() });

                UnitOfWork.Save();

                ModelState.Clear();
                return;
                //return Redirect("/User/index");
            }

            return;
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
