using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MYZONE.BLL.Interfaces;
using MYZONE.BLL.Models;
using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager authenticationManager;
        private readonly UserManager<User> userManager;

        public AuthenticationController(IAuthenticationManager authenticationManager, UserManager<User> userManager)
        {
            this.authenticationManager = authenticationManager;
            this.userManager = userManager;
        }

        [HttpPost("sign-up")]
        [Authorize("Admin")]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel registerModel)
        {
            var exists = await userManager.FindByEmailAsync(registerModel.Email);
            if(exists != null)
            {
                return BadRequest("User with this email is already registered!");
            }
            try
            {
                await authenticationManager.SignUp(registerModel);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("sign-up/basic")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUpBasic([FromBody] NormalRegModel registerModel)
        {
            var regModel = new RegisterModel
            {
                Email = registerModel.Email,
                Username = registerModel.Username,
                Password = registerModel.Password,
                Role = "BasicUser"
            };

            var exists = await userManager.FindByEmailAsync(registerModel.Email);
            if (exists != null)
            {
                return BadRequest("User with this email is already registered!");
            }
            try
            {
                await authenticationManager.SignUp(regModel);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] LoginModel loginModel)
        {
            var tokens = await authenticationManager.LogIn(loginModel);
            if (tokens != null)
            {
                return Ok(tokens);
            }
            else
            {
                return BadRequest("Failed to login");
            }
        }
    }
}
