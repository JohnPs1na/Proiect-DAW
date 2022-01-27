using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYZONE.BLL.Interfaces;
using MYZONE.BLL.Models;
using MYZONE.DAL.Entities;
using MYZONE.DAL.Interfaces;
using MYZONE.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MYZONE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private IArtistsManager manager;
        public ArtistsController(IArtistsManager artistsManager)
        {
            this.manager = artistsManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtists()
        {
            return Ok(manager.GetArtists());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistById(string id)
        {
            var Artist = manager.GetArtistById(id);
            return Ok(Artist);
        }

        [HttpPost("Model")]
        public async Task<IActionResult> Create([FromBody] ArtistModel artist)
        {
            try
            {
                var newArtist = new Artists
                {
                    Id = artist.Id,
                    FirstName = artist.FirstName,
                    LastName = artist.LastName,
                    Email = artist.Email,
                    Confirmed = false,
                    Genre = artist.Genre
                };
                await manager.Create(newArtist);
                return Ok("Artist Creat");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                await manager.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SetMark([FromRoute] string id, [FromBody] bool conf)
        {
            try
            {
                await manager.SetConfirmed(id, conf);
                return Ok(manager.GetArtistById(id));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message); 
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAll([FromBody] bool checkmark)
        {
            try
            {
                var artists = manager.GetArtists();
                foreach(var artist in artists)
                {
                    await SetMark(artist.Id, true);
                }
                return Ok(manager.GetArtists());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}
