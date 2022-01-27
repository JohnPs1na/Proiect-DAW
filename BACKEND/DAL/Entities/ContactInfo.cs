using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Entities
{
    public class ContactInfo
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AdminId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public Admins Admin { get; set; }

    }
}
