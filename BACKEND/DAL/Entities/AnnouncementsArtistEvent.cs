using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Entities
{
    public class AnnouncementsArtistEvent
    {
        public string ArtistId { get; set; }
        public Artists Artist { get; set; }
        public string EventId { get; set; }
        public Events Event { get; set; }
    }
}
