using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Models
{
    public class EventWithIdModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string StartTime { get; set; }
        public int TicketNum { get; set; }
        public string Status { get; set; }
    }
}
