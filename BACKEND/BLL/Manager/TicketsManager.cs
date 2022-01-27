using MYZONE.BLL.Interfaces;
using MYZONE.BLL.Models;
using MYZONE.DAL.Entities;
using MYZONE.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Manager
{
    public class TicketsManager : ITicketsManager
    {
        private readonly ITicketsRepository ticketsRepository;
        private readonly IEventsRepository eventsRepository;
        public TicketsManager(ITicketsRepository repo, IEventsRepository eve)
        {
            this.ticketsRepository = repo;
            this.eventsRepository = eve;
        }
        public async Task Create(TicketModel ticket)
        {
            var newTicket = new Tickets
            {
                Id = Guid.NewGuid().ToString(),
                EventTitle = ticket.EventTitle,
                Cost = ticket.Cost,
                StartTime = ticket.StartTime,
                EndTime = ticket.EndTime,
                Status = ticket.Status,
                EventId = ticket.EventId
            };

            await ticketsRepository.Create(newTicket);
        }

        public async Task Delete(string id)
        {
            var ticket = GetTicketsById(id);
            await ticketsRepository.Delete(ticket);
        }

        public List<Tickets> GetTickets()
        {
            return ticketsRepository.GetAllTickets().ToList();
        }

        public Tickets GetTicketsById(string id)
        {
            var ticket = ticketsRepository.GetAllTickets().FirstOrDefault(x => x.Id == id);
            return ticket;
        }

        public async Task Update(string id,TicketModel ticket)
        {
            var tickToUpdate = new Tickets
            {
                Id = id,
                EventTitle = ticket.EventTitle,
                Cost = ticket.Cost,
                StartTime = ticket.StartTime,
                EndTime = ticket.EndTime,
                Status = ticket.Status,
                EventId = ticket.EventId
            };
            await ticketsRepository.Update(tickToUpdate);
        }

        public List<Tickets> GetTicketsByArtist(string data)
        {
            var joined = ticketsRepository.GetTicketByArtist();

            var fin = new List<Tickets>();


/*
            joined = joined.Where(a => a.FirstName.ToUpper().Contains(data.ToUpper()));*/
            
            foreach(var x in joined)
            {
                if (x.FirstName.ToUpper().Contains(data.ToUpper()) || x.LastName.ToUpper().Contains(data.ToUpper())){
                    fin.Add(new Tickets(x));
                }
            }

            fin = fin.Distinct().ToList();
            return fin;
        }
    }
}
