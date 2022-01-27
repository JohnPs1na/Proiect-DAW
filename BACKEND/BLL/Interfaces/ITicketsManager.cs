using MYZONE.BLL.Models;
using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Interfaces
{
    public interface ITicketsManager
    {
        List<Tickets> GetTickets();
        Tickets GetTicketsById(string id);
        //Tickets GetTicketByArtistId(string id);
        Task Create(TicketModel ticket);
        Task Delete(string id);
        Task Update(string id,TicketModel ticket);
        List<Tickets> GetTicketsByArtist(string data);
    }
}
