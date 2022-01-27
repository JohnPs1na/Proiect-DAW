using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Entities
{
    public class TicketOrder
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string TicketId { get; set; }
        public Tickets Ticket { get; set; }
    }
}
