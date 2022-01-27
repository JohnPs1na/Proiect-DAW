using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Interfaces
{
    public interface ITokenManager
    {
        Task<string> GenerateToken(User user);
    }
}
