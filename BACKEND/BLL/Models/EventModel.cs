using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Models
{
    public class EventModel
    {
        public EventModel() { }
        public EventModel(Events e)
        {
            this.Title = e.Title;
            this.Genre = e.Genre;
            this.StartTime = e.StartTime;
            this.TicketNum = e.TicketNum;
            this.Status = e.Status;
        }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string StartTime { get; set; }
        public int TicketNum { get; set; }
        public string Status { get; set; }
    }
}
