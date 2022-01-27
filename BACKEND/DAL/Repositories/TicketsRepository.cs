using Microsoft.EntityFrameworkCore;
using MYZONE.BLL.Models;
using MYZONE.DAL.Entities;
using MYZONE.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly MyzoneContext db;
        public TicketsRepository(MyzoneContext context)
        {
            this.db = context;
        }

        public async Task Create(Tickets ticket)
        {
            await db.Tickets.AddAsync(ticket);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Tickets ticket)
        {
            db.Tickets.Remove(ticket);
            await db.SaveChangesAsync();
        }

        public async Task Update(Tickets ticket)
        {
            db.Tickets.Update(ticket);
            await db.SaveChangesAsync();
        }

        public IQueryable<Tickets> GetAllTickets()
        {
            return db.Tickets;
        }

        public List<TicketByArtist> GetTicketByArtist()
        {

            var joined = db.Tickets.Join(db.Events,
                t => t.EventId, e => e.Id,
                (tick, ev) => new
                {
                    tick.Id,
                    tick.EventTitle,
                    tick.Cost,
                    tick.StartTime,
                    tick.EndTime,
                    tick.Status,
                    tick.EventId
                }).Join(db.Announcements,
                    t => t.EventId, a => a.EventId,
                    (tick, an) => new
                    {
                        tick.EventTitle,
                        tick.Cost,
                        tick.StartTime,
                        tick.EndTime,
                        tick.Status,
                        tick.Id,
                        tick.EventId,
                        an.ArtistId
                    }).Join(db.Artists,
                    t => t.ArtistId, a => a.Id,
                    (tick, a) => new TicketByArtist(
                        tick.Id,
                        tick.EventTitle,
                        tick.Cost,
                        tick.StartTime,
                        tick.EndTime,
                        tick.EventId,
                        tick.Status,
                        a.FirstName,
                        a.LastName));

            return joined.ToList();
        }
    }
}
