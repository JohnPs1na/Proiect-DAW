using MYZONE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Entities
{
    public class Events
    {
        public Events() { }
        public Events(EventModel ev)
        {
            this.Title = ev.Title;
            this.Genre = ev.Genre;
            this.StartTime = ev.StartTime;
            this.Status = ev.Status;
            this.TicketNum = ev.TicketNum;
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }
        public string StartTime { get; set; }
        public int TicketNum { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
        public string AdminId { get; set; }
        public Admins Admin { get; set; }
        public ICollection<AnnouncementsArtistEvent> AnnouncementsArtistEvent { get; set; }

    }
}
