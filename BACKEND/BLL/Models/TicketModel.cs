using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Models
{
    public class TicketModel
    {
        public string EventTitle { get; set; }
        public int Cost { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Status { get; set; }
        public string EventId { get; set; }

    }
}
