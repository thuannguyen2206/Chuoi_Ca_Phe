using DataTransferObjects.DTOs.Menus;
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
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("list/adminrole={adminRole}")]
        [AllowAnonymous]
        public IActionResult GetAll(bool adminRole)
        {
            var result = _menuService.GetAll(adminRole);
            return Ok(result);
        }

        [HttpPost("create")]
        public IActionResult Create(MenuDto menu)
        {
            var result = _menuService.Create(menu);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _menuService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}/update")]
        public IActionResult Update(int id, MenuDto dto)
        {
            var result = _menuService.Update(id, dto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _menuService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
