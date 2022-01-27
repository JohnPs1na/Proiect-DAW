using Microsoft.AspNetCore.Authorization;
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
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoManager ciManager;
        public ContactInfoController(IContactInfoManager contactInfo)
        {
            this.ciManager = contactInfo;
        }
        [HttpPost("add-Info")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddContactInfo([FromBody] ContactInfoModel model)
        {
            try
            {
                await ciManager.Create(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("admin/{id}")]
        public async Task<IActionResult> GetInfoByID([FromRoute] string id)
        {
            var info = ciManager.GetContactInfoByAdminId(id);
            return Ok(info);
        }

        [HttpPut("admin/update")]
        public async Task<IActionResult> UpdateInfo([FromBody] ContactInfoModel model)
        {
            await ciManager.Update(model);

            return Ok();
        }
        [HttpDelete("Info/delete")]
        public async Task<IActionResult> DeleteInfo([FromBody] string id)
        {
            await ciManager.Delete(id);
            return Ok();
        }
    }
}
