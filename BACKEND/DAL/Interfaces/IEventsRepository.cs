using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Interfaces
{
    public interface IEventsRepository
    {
        Task Create(Events Event);
        Task Update(Events Event);
        Task Delete(Events Event);
        IQueryable<Events> GetEvents();
    }
}
