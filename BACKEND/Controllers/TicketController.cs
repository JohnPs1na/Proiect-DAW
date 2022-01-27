using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYZONE.BLL.Interfaces;
using MYZONE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketsManager manager;
        public TicketController(ITicketsManager man)
        {
            this.manager = man;
        }

        [HttpGet("Read")]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = manager.GetTickets();
            return Ok(tickets);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                await manager.Delete(id);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] string id, [FromBody] TicketModel model)
        {
            try
            {
                await manager.Update(id, model);
                var ti = manager.GetTicketsById(id);
                return Ok(ti);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTicket([FromBody] TicketModel model)
        {
            try
            {
                await manager.Create(model);
                return Ok(model);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Get/{data}")]
        public async Task<IActionResult> GetbyArtist([FromRoute] string data)
        {
            var lista = manager.GetTicketsByArtist(data);
            lista = lista.Distinct().ToList();
            return Ok(lista);
        }
    }
}
