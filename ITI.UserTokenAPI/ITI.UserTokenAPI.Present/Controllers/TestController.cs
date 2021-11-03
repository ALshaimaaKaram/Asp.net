using ITI.UserTokenAPI.Models;
using ITI.UserTokenAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.UserTokenAPI.Present.Controllers
{
    public class TestController : ApiController
    {
        IUnitOfWork UnitOfWork;
        IModelRepository<User> UserRepository;
        IModelRepository<Token> TokenRepository;
        public TestController(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
            UserRepository = UnitOfWork.GetUserRepo();
            TokenRepository = UnitOfWork.GetTokenRepo();
        }

        [HttpGet]
        public string GetString()
        {
            return "Hello!";
        }
    }
}
