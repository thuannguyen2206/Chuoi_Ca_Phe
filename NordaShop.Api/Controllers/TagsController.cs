using DataTransferObjects.DTOs.Tags;
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
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _tagService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("list/adminrole={adminRole}")]
        [AllowAnonymous]
        public IActionResult GetAll(bool adminRole)
        {
            var result = _tagService.GetAll(adminRole);
            return Ok(result);
        }

        [HttpGet("top-product-tags")]
        [AllowAnonymous]
        public IActionResult GetTopProductTags()
        {
            var result = _tagService.GetTopProductTags();
            return Ok(result);
        }

        [HttpGet("top-post-tags")]
        [AllowAnonymous]
        public IActionResult GetTopPostTags()
        {
            var result = _tagService.GetTopPostTags();
            return Ok(result);
        }

        [HttpPut("{id}/update")]
        public IActionResult Update(int id, TagDto dto)
        {
            var result = _tagService.Update(id, dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("create")]
        public IActionResult Create(TagDto dto)
        {
            var result = _tagService.Create(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("tag-of-product/{productId}")]
        [AllowAnonymous]
        public IActionResult GetTagOfProduct(int productId)
        {
            var result = _tagService.GetTagOfProduct(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("tag-of-post/{postId}")]
        [AllowAnonymous]
        public IActionResult GetTagOfPost(int postId)
        {
            var result = _tagService.GetTagOfPost(postId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
