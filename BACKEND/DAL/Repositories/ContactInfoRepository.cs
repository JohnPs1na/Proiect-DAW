using MYZONE.BLL.Interfaces;
using MYZONE.DAL.Entities;
using MYZONE.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Repositories
{
    public class ContactInfoRepository : IContactInfoRepository
    {
        private readonly MyzoneContext db;

        public ContactInfoRepository(MyzoneContext context)
        {
            this.db = context;
        }

        public async Task Create(ContactInfo ci)
        {
            await db.ContactInfo.AddAsync(ci);
            await db.SaveChangesAsync();

        }

        public async Task Delete(ContactInfo ci)
        {
            db.ContactInfo.Remove(ci);
            await db.SaveChangesAsync();
        }


        public IQueryable<ContactInfo> GetContactInfos()
        {
            return db.ContactInfo;
        }


        public async Task Update(ContactInfo ci)
        {
            db.ContactInfo.Update(ci);
            await db.SaveChangesAsync();
        }
    }
}
