using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Models
{
    public class TicketByArtist
    {
        public TicketByArtist(string id,string EventTitle,int Cost,string StartTime,string EndTime,string EventId, string status,string name, string fam)
        {
            Id = id;
            this.EventTitle = EventTitle;
            this.Cost = Cost;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Status = status;
            this.EventId = EventId;
            this.FirstName = name;
            this.LastName = fam;
        }
        public string Id { get; set; }
        public string EventTitle { get; set; }
        public int Cost { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Status { get; set; }
        public string EventId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
