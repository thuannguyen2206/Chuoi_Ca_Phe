using DataAccess.Enums;
using DataTransferObjects.DTOs.Options;
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
    public class OptionsController : ControllerBase
    {
        private readonly IOptionService _optionService;
        public OptionsController(IOptionService option)
        {
            _optionService = option;
        }

        [HttpGet("list/adminrole={adminRole}")]
        [AllowAnonymous]
        public IActionResult GetAll(bool adminRole)
        {
            var result = _optionService.GetOptions(adminRole);
            return Ok(result);
        }

        [HttpGet("productid={productid}")]
        [AllowAnonymous]
        public IActionResult GetoptionByProductId(int productid)
        {
            var result = _optionService.GetProductOption(productid);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var result = _optionService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("product-option-default/{productId}/group={group}")]
        [AllowAnonymous]
        public IActionResult GetDefaltOption(int productId, ProductOptionGroup group)
        {
            var result = _optionService.GetProductDefaultOption(productId, group);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("create")]
        public IActionResult Create(OptionDto dto)
        {
            var result = _optionService.Create(dto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}/update")]
        public IActionResult Update(int id, OptionDto model)
        {
            var result = _optionService.Update(id, model);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _optionService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("product-colors/{productId}")]
        [AllowAnonymous]
        public IActionResult GetProductRelatedColor(int productId)
        {
            var result = _optionService.GetProductRelatedColor(productId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
