using MYZONE.BLL.Models;
using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Interfaces
{
    public interface IEventsManager
    {
        List<Events> GetEvents();
        Task Create(EventModel Event);
        Task Delete(string id);
        Task Update(EventWithIdModel eve);
        Events GetEventById(string id);
        List<Events> GetFilteredTitle(string srchd);
    }
}
