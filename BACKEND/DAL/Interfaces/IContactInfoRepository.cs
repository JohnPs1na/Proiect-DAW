using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Interfaces
{
    public interface IContactInfoRepository
    {
        IQueryable<ContactInfo> GetContactInfos();


        Task Create(ContactInfo artist);
        Task Delete(ContactInfo artist);
        Task Update(ContactInfo artist);
    }
}
