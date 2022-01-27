using MYZONE.BLL.Interfaces;
using MYZONE.BLL.Models;
using MYZONE.DAL.Entities;
using MYZONE.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Manager
{
    public class ContactInfoManager : IContactInfoManager
    {
        private readonly IContactInfoRepository ciRepo;
        public ContactInfoManager(IContactInfoRepository repository)
        {
            this.ciRepo = repository;
        }
        public async Task Create(ContactInfoModel ci)
        {
            var newCI = new ContactInfo
            {
                Id = Guid.NewGuid().ToString(),
                Email = ci.Email,
                PhoneNumber = ci.PhoneNumber,
                City = ci.City,
                Address = ci.Address,
                AdminId = ci.AdminId
            };

            await ciRepo.Create(newCI);
        }

        public ContactInfo GetContactInfoByAdminId(string id)
        {

            var info = ciRepo.GetContactInfos().FirstOrDefault(x => x.AdminId == id);

            return info;
            
        }

        public async Task Update(ContactInfoModel ci)
        {
            var info = GetContactInfoByAdminId(ci.AdminId);
            info.Email = ci.Email;
            info.City = ci.City;
            info.Address = ci.Address;
            info.PhoneNumber = ci.PhoneNumber;
            await ciRepo.Update(info);
        }

        public async Task Delete(string id)
        {
            var info = GetContactInfoByAdminId(id);
            await ciRepo.Delete(info);
        }
    }
}
