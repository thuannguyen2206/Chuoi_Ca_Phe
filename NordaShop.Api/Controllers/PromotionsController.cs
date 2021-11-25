using DataTransferObjects.DTOs.Promotions;
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
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionsController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet("list")]
        public IActionResult ListPromotions([FromQuery] PagingDto paging)
        {
            var result = _promotionService.GetPagings(paging);
            return Ok(result);
        }

        [HttpPost("create")]
        public IActionResult CreatePromotion(PromotionDto dto)
        {
            var result = _promotionService.Create(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetPromotionById(int id)
        {
            var result = _promotionService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}/update")]
        public IActionResult UpdatePromotion(int id, PromotionDto dto)
        {
            var result = _promotionService.Update(id, dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePromotion(int id)
        {
            var result = _promotionService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("on-show")]
        [AllowAnonymous]
        public IActionResult GetOnShowPromotion()
        {
            var result = _promotionService.GetOnShowPromotion();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
