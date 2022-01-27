using Microsoft.AspNetCore.Identity;
using MYZONE.BLL.Interfaces;
using MYZONE.BLL.Models;
using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Manager
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenManager tokenManager;

        public AuthenticationManager(UserManager<User> usrManager,SignInManager<User> signInManager,ITokenManager tokenManager)
        {
            this.userManager = usrManager;
            this.signInManager = signInManager;
            this.tokenManager = tokenManager;
        }


        public async Task SignUp(RegisterModel registerModel)
        {
            var user = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.Username
            };

            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, registerModel.Role);
            }

        }
        public async Task<TokensModel> LogIn(LoginModel loginModel)
        {
            var user = await userManager.FindByEmailAsync(loginModel.Username);
            if(user == null)
            {
                user = await userManager.FindByNameAsync(loginModel.Username);
            }

            if(user != null)
            {

                var result = await signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
                if (result.Succeeded)
                {
                    var token = await tokenManager.GenerateToken(user);

                    return new TokensModel
                    {
                        AccesToken = token
                    };
                }
            }
            return null;
        }
    }
}
