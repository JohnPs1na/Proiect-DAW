using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Interfaces
{
    public interface IArtistsRepository
    {
        IQueryable<Artists> GetArtists();

        Task Create(Artists artist);
        Task Delete(Artists artist);
        Task Update(Artists artist);
    }
}
