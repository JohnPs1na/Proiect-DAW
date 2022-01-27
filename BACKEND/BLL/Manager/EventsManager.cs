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
    public class EventsManager : IEventsManager
    {
        private readonly IEventsRepository eventsRepository;
        public EventsManager(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public async Task Create(EventModel Event)
        {
            var newEvent = new Events
            {
                Id = Guid.NewGuid().ToString(),
                Title = Event.Title,
                Genre = Event.Genre,
                StartTime = Event.StartTime,
                Status = "Pending",
                TicketNum = Event.TicketNum
            };

            await eventsRepository.Create(newEvent);
        }

        public async Task Delete(string id)
        {
            var ev = GetEventById(id);
            await eventsRepository.Delete(ev);
        }

        public List<Events> GetEvents()
        {
            return eventsRepository.GetEvents().ToList();
        }

        public Events GetEventById(string id)
        {
            return eventsRepository.GetEvents().FirstOrDefault(x => id == x.Id);
        }

        public async Task Update(EventWithIdModel ev)
        {

            var eve = GetEventById(ev.Id);
            eve.Title = ev.Title;
            eve.TicketNum = ev.TicketNum;
            eve.Status = ev.Status;
            eve.Genre = ev.Genre;
            eve.StartTime = ev.StartTime;
            await eventsRepository.Update(eve);
        }

        public List<Events> GetFilteredTitle(string srchd)
        {
            
            var lista = eventsRepository.GetEvents().Where(e => e.Title.ToUpper().Contains(srchd.ToUpper())).ToList();
            lista = lista.Concat(eventsRepository.GetEvents().Where(e => e.Genre.ToUpper().Contains(srchd.ToUpper())).ToList()).ToList();
            lista = lista.Distinct().ToList();
            return lista;
        }
    }
}
