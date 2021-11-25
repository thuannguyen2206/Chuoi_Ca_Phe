using DataTransferObjects.DTOs.Posts;
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
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("list-in-site")]
        [AllowAnonymous]
        public IActionResult GetSitePagings([FromQuery]BlogPagingDto paging)
        {
            var result = _blogService.GetPagings(paging);
            return Ok(result);
        }

        [HttpGet("list-admin")]
        [AllowAnonymous]
        public IActionResult GetAdminPagings([FromQuery]BlogPagingDto paging)
        {
            var result = _blogService.GetPagings(paging, true);
            return Ok(result);
        }

        [HttpGet("{postId}/related")]
        [AllowAnonymous]
        public IActionResult GetRelatedPost(int postId)
        {
            var result = _blogService.GetRelatedPost(postId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("list-lastest-post")]
        [AllowAnonymous]
        public IActionResult GetLastestPost()
        {
            var result = _blogService.GetLastestPost();
            return Ok(result);
        }

        [HttpGet("{id}/adminRole={adminRole}")]
        [AllowAnonymous]
        public IActionResult GetById(int id, bool adminRole = false)
        {
            var result = _blogService.GetById(id, adminRole);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm] CEPostDto dto)
        {
            var result = _blogService.Create(dto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("{postId}/add-comment")]
        [AllowAnonymous]
        public IActionResult AddPostComment(int postId, PostCommentDto dto)
        {
            var result = _blogService.AddPostComment(postId, dto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}/update")]
        public IActionResult Update(int id, [FromForm] CEPostDto dto)
        {
            var result = _blogService.Update(id, dto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _blogService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete-comment/{commentId}")]
        public IActionResult DeleteComment(int commentId)
        {
            var result = _blogService.DeleteComment(commentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{postId}/list-comment")]
        public IActionResult GetPostComment(int postId, [FromQuery]BlogPagingDto paging)
        {
            var result = _blogService.GetPostComment(postId, paging);
            return Ok(result);
        }

        [HttpGet("{postId}/list-lastest-comments")]
        [AllowAnonymous]
        public IActionResult GetLastestPostComment(int postId)
        {
            var result = _blogService.GetLastestPostComment(postId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("file-upload-ckeditor")]
        public IActionResult FileUploadCkEditor([FromForm]IFormFile file)
        {
            var result = _blogService.FileUploadCkEditor(file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
