using MYZONE.BLL.Models;
using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.BLL.Interfaces
{
    public interface IArtistsManager
    {
        List<Artists> GetArtists();
        Artists GetArtistById(string id);
        Task Create(Artists artist);
        Task Delete(string id);
        Task SetConfirmed(string id,bool checkmark);
    }
}
