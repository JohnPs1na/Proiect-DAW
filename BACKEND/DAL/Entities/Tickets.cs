using MYZONE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Entities
{
    public class Tickets
    {
        public Tickets() { }
        public Tickets(TicketByArtist tba)
        {
            this.Id = tba.Id;
            this.EventTitle = tba.EventTitle;
            this.StartTime = tba.StartTime;
            this.Cost = tba.Cost;
            this.EndTime = tba.EndTime;
            this.Status = tba.Status;
            this.EventId = tba.EventId;
        }
        public string Id { get; set; }
        public string EventTitle { get; set; }
        public int Cost { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Status { get; set; }
        public string EventId { get; set; }
        public Events Event { get; set; }
        public ICollection<TicketOrder> TicketOrders { get; set; }

    }
}
