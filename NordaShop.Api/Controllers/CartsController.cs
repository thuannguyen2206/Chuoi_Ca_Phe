using DataTransferObjects.DTOs.Carts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
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
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IUnitOfWork _uow;

        public CartsController(ICartService cartService, IUnitOfWork uow)
        {
            _cartService = cartService;
            _uow = uow;
        }

        [HttpGet("userid={userId}")]
        [AllowAnonymous]
        public IActionResult GetCartByUserId(Guid userId)
        {
            var result = _cartService.GetCart(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{userId}/mini-cart")]
        [AllowAnonymous]
        public IActionResult GetMiniCartByUserId(Guid userId)
        {
            var result = _cartService.GetMiniCart(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{userId}/total-products")]
        [AllowAnonymous]
        public IActionResult TotalInCart(Guid userId)
        {
            var result = _cartService.TotalProductInCart(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{cartId}")]
        [AllowAnonymous]
        public IActionResult GetCartById(int cartId)
        {
            var result = _cartService.GetCart(cartId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add-to-cart")]
        public IActionResult AddToCart(AddCartItemDto dto)
        {
            var result = _cartService.AddToCart(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("{userId}/sync-cart")]
        public IActionResult SyncCart(Guid userId, List<AddCartItemDto> dto)
        {
            var response = _cartService.SyncCart(userId, dto);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("user={userId}/update-quantity")]
        public IActionResult UpdateQuantity(Guid userId, [FromBody]List<CartItemUpdateDto> dto)
        {
            var result = _cartService.UpdateQuantity(userId, dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{cartId}")]
        public IActionResult Delete(int cartId)
        {
            var result = _cartService.Delete(cartId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("remove-item/{itemId}")]
        public IActionResult RemoveItem(int itemId)
        {
            var result = _cartService.RemoveProduct(itemId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("userid={userId}/clear")]
        public IActionResult ClearCart(Guid userId)
        {
            var result = _cartService.ClearCart(userId);
            _uow.SaveChanges();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
