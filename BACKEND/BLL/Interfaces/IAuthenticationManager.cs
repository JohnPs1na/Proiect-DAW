using Microsoft.AspNetCore.Identity;
using MYZONE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Interfaces
{
    public interface IAuthenticationManager
    {
        Task SignUp(RegisterModel registerModel);
        Task<TokensModel> LogIn(LoginModel loginModel);
    }
}
