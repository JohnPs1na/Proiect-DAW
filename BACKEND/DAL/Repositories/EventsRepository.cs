using MYZONE.DAL.Entities;
using MYZONE.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly MyzoneContext db;

        public EventsRepository(MyzoneContext context)
        {
            this.db = context;
        }
        public async Task Create(Events Event)
        {
            await db.Events.AddAsync(Event);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Events ev)
        {
            db.Events.Remove(ev);
            await db.SaveChangesAsync();
        }

        public IQueryable<Events> GetEvents()
        {
            return db.Events;
        }

        public async Task Update(Events Event)
        {
            db.Events.Update(Event);
            await db.SaveChangesAsync();
        }
    }
}
