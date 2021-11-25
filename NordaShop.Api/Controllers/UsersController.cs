using DataTransferObjects.DTOs.Users;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id}/adminrole={isAdmin}")]
        [Route("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(Guid id, bool isAdmin = false)
        {
            var result = _userService.GetById(id, isAdmin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("list")]
        public IActionResult GetUserPaging([FromQuery] UserAdminPagingDto paging)
        {
            var result = _userService.GetUserPaging(paging);
            return Ok(result);
        }

        [HttpPut("{id}/update")]
        public IActionResult Update(Guid id, UserUpdateDto dto)
        {
            var result = _userService.Update(id, dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("create")]
        public IActionResult Create(UserCreateDto dto)
        {
            var result = _userService.Create(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _userService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{userId}/wish-lists")]
        public IActionResult GetWishList(Guid userId)
        {
            var result = _userService.GetWishList(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("{userId}/wish-lists/{productId}/add")]
        public IActionResult AddToWishList(Guid userId, int productId)
        {
            var result = _userService.AddToWishList(userId, productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{userId}/wish-lists/{productId}/remove")]
        public IActionResult RemoveWishlistItem(Guid userId, int productId)
        {
            var result = _userService.RemoveWishlistItem(userId, productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{userId}/wish-list-count")]
        [AllowAnonymous]
        public IActionResult GetWishListCount(Guid userId)
        {
            var result = _userService.GetWishListCount(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("total-actives")]
        public IActionResult TotalActives()
        {
            var result = _userService.TotalActives();
            return Ok(result);
        }

        [HttpGet("{userId}/dashboard")]
        public IActionResult UserTotalIncome(Guid userId)
        {
            var result = _userService.GetCustomerDashboard(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("is-exist/{email}")]
        //[AllowAnonymous]
        public IActionResult CheckExistByEmail(string email)
        {
            var result = _userService.CheckExistByEmail(email);
            return Ok(result);
        }

        [HttpGet("email={email}")]
        //[AllowAnonymous]
        public IActionResult GetByEmail(string email)
        {
            var result = _userService.GetByEmail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
