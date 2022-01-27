using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYZONE.BLL.Interfaces;
using MYZONE.BLL.Models;
using MYZONE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IEventsManager eventsManager;
        public EventsController(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetEvents()
        {
            return Ok(eventsManager.GetEvents());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(eventsManager.GetEventById(id));
        }
        [HttpGet("filter/{srchd}")]
        public async Task<IActionResult> GetFilteredTitle([FromRoute] string srchd)
        {
            return Ok(eventsManager.GetFilteredTitle(srchd));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            try
            {
                var thisEv = eventsManager.GetEventById(id);
                var ev = new EventModel(thisEv);
                ev.Status = "Canceled";

                await eventsManager.Delete(id);
                return Ok(ev);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete("")]
        public async Task<IActionResult> DeleteEvent([FromBody] Events ev){
            try
            {
                var id = ev.Id;
                await eventsManager.Delete(ev.Id);
                var newEvents = eventsManager.GetEvents().Where(s => s.Id != id).ToArray();
                return Ok(newEvents);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("create")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddEvent([FromBody] EventModel model)
        {
            try
            {
                await eventsManager.Create(model);
                var events = eventsManager.GetEvents();
                return Ok(events);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEvent([FromBody] EventWithIdModel eve)
        {
            try
            {

                await eventsManager.Update(eve);

                var allEvents = eventsManager.GetEvents();
                return Ok(allEvents);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
