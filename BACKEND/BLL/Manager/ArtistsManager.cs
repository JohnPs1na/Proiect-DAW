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
    public class ArtistsManager :IArtistsManager
    {
        private readonly IArtistsRepository artistRepository;
        public ArtistsManager(IArtistsRepository repository)
        {
            this.artistRepository = repository;
        }

        public async Task Create(Artists artist)
        {
            await artistRepository.Create(artist);
        }

        //Artists can be deleted only by admins
        public async Task Delete(string id)
        {
            var artist = GetArtistById(id);
            await artistRepository.Delete(artist);
        }

        public List<Artists> GetArtists()
        {
            return artistRepository.GetArtists().ToList();
        }

        public Artists GetArtistById(string id)
        {
            var artist = artistRepository.GetArtists().FirstOrDefault(x => x.Id == id);
            return artist;
        }

        //not implemented yet
        public async Task SetConfirmed(string id, bool checkmark)
        {
            var artist = GetArtistById(id);
            artist.Confirmed = checkmark;
            await artistRepository.Update(artist);
        }
    }
}
