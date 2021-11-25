using DataTransferObjects.DTOs.Contacts;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("list")]
        public IActionResult GetPagings([FromQuery] PagingDto paging)
        {
            var result = _contactService.GetPagings(paging);
            return Ok(result);
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public IActionResult Create(ContactDto dto)
        {
            var result = _contactService.Create(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _contactService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _contactService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
