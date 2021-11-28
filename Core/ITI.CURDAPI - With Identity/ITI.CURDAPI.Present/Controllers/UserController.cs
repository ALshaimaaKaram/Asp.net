using ITI.CRUDAPI.ViewModel;
using ITI.CURDAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CURDAPI.Present.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        IUserRepository userRepository;
        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<ActionResult> signUp(SignUpModel sigUpModel)
        {
            string Token = await userRepository.SignUp(sigUpModel);

            if (string.IsNullOrEmpty(Token))
                return Unauthorized();

            return Ok(Token);
        }  
    }
}
