using MYZONE.DAL.Entities;
using MYZONE.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Repositories
{
    public class ArtistsRepository : IArtistsRepository
    {
        private readonly MyzoneContext db;

        public ArtistsRepository(MyzoneContext context)
        {
            this.db = context;
        }

        public async Task Create(Artists artist)
        {
            await db.Artists.AddAsync(artist);

            await db.SaveChangesAsync();
        }

        public async Task Delete(Artists artist)
        {
            db.Artists.Remove(artist);
            await db.SaveChangesAsync(); 
        }

        public async Task Update(Artists artist)
        {
            db.Artists.Update(artist);
            await db.SaveChangesAsync();
        }

        public IQueryable<Artists> GetArtists()
        {
            return db.Artists;
        }
    }
}
