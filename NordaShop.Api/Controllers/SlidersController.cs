using DataTransferObjects.DTOs.Sliders;
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
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _sliderService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _sliderService.GetAll();
            return Ok(result);
        }

        [HttpGet("on-site")]
        [AllowAnonymous]
        public IActionResult GetOnSite()
        {
            var result = _sliderService.GetDashboard();
            return Ok(result);
        }

        [HttpPut("{id}/update")]
        public IActionResult Update(int id, [FromForm] CESliderDto dto)
        {
            var result = _sliderService.Update(id, dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm] CESliderDto dto)
        {
            var result = _sliderService.Create(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _sliderService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
