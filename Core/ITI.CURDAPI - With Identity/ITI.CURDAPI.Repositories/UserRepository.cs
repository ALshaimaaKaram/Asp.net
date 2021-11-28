using ITI.CRUDAPI.ViewModel;
using ITI.CURDAPI.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CURDAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        UserManager<User> userManager;
        public IConfiguration configuration { get; }
        public UserRepository(UserManager<User> _userManager, IConfiguration _configuration)
        {
            userManager = _userManager;
            configuration = _configuration;
        }

        public async Task<string> SignUp(SignUpModel signUpModel)
        {
            User user = signUpModel.ToModel();
             var result = await userManager.CreateAsync(user, signUpModel.Password);

            if(!result.Succeeded)
                return null;

            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, signUpModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var Token = new JwtSecurityToken
            (
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(14),
                signingCredentials : new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
                claims: userClaims
            );

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
