using MYZONE.BLL.Models;
using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Interfaces
{
    public interface IContactInfoManager
    {
        Task Create(ContactInfoModel ci);
        ContactInfo GetContactInfoByAdminId(string id);

        Task Update(ContactInfoModel ci);
        Task Delete(string id);
    }
}
