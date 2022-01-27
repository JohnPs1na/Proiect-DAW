using MYZONE.BLL.Models;
using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Interfaces
{
    public interface ITicketsRepository
    {
        IQueryable<Tickets> GetAllTickets();
        Task Create(Tickets ticket);
        Task Update(Tickets ticket);
        Task Delete(Tickets ticket);
        List<TicketByArtist> GetTicketByArtist();
    }
}
