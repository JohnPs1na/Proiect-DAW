using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MYZONE.DAL.Entities
{
    public class Artists
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Genre { get; set; }
        public bool Confirmed { get; set; }
        public ICollection<AnnouncementsArtistEvent> AnnouncementsArtistEvent { get; set; }

    }
}
