using Common.Messages;
using DataAccess.Enums;
using DataTransferObjects.DTOs.Orders;
using DataTransferObjects.DTOs.Utilities;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Threading.Tasks;

namespace NordaShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IConverter _converter;

        public OrdersController(IOrderService orderService, IConverter converter)
        {
            _orderService = orderService;
            _converter = converter;
        }

        [HttpPost("users/{userId}/checkout")]
        [AllowAnonymous]
        public async Task<IActionResult> Checkout(Guid userId, NewOrderDto model)
        {
            var result = await _orderService.Checkout(userId, model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("list")]
        public IActionResult GetAllOrderPaging([FromQuery] OrderAdminPagingDto paging)
        {
            var result = _orderService.GetAllOrderPaging(paging);
            return Ok(result);
        }

        [HttpGet("users/{userId}")]
        public IActionResult GetUserOrders(Guid userId)
        {
            var result = _orderService.GetUserOrders(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            var result = _orderService.GetOrderById(orderId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{orderCode}/tracking")]
        [AllowAnonymous]
        public IActionResult GetOrderByCode(Guid orderCode)
        {
            var result = _orderService.GetOrderByCode(orderCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{orderId}/list-items")]
        public IActionResult GetOrderItemByOrderId(int orderId)
        {
            var result = _orderService.GetOrderItemByOrderId(orderId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("coupon/{code}/get-discount-percent")]
        [AllowAnonymous]
        public IActionResult GetDiscountPercent(string code)
        {
            var result = _orderService.GetDiscountPercent(code);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{orderId}/change-status")]
        public IActionResult ChangeOrderStatus(int orderId, [FromBody] OrderStatus status)
        {
            var result = _orderService.ChangeOrderStatus(orderId, status);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("total-orders")]
        public IActionResult TotalOrders()
        {
            var result = _orderService.TotalOrders();
            return Ok(result);
        }

        [HttpGet("total-income")]
        public IActionResult TotalIncome()
        {
            var result = _orderService.TotalIncome();
            return Ok(result);
        }

        [HttpGet("monthly-income")]
        public IActionResult MonthlyIncome()
        {
            var result = _orderService.MonthlyIncome();
            return Ok(result);
        }

        [HttpGet("{orderId}/download")]
        public IActionResult OrderDownload(int orderId)
        {
            var content = _orderService.BuildOrderDownloadTemplate(orderId);
            var result = new ApiResult<byte[]>();
            if (!string.IsNullOrEmpty(content))
            {
                var byteArray = GeneratePdfFile(content);
                result.Success = true;
                result.Data = byteArray;
                return Ok(result);
            }
            result.Success = false;
            result.Data = null;
            result.ErrorCode = OrderMessage.NotFound;
            return BadRequest(result);
        }

        private byte[] GeneratePdfFile(string content)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings() //{ Top = 1, Bottom = 1, Left = 1, Right = 1, Unit = Unit.Centimeters}
            };

            WebSettings webSettings = new WebSettings { DefaultEncoding = "utf-8" };
            HeaderSettings headerSettings = new HeaderSettings
            {
                FontSize = 10,
                FontName = "Ariel",
                Right = "norda",
                Line = true
            };
            FooterSettings footerSettings = new FooterSettings
            {
                FontSize = 12,
                FontName = "Ariel",
                Center = string.Empty,
                Line = false
            };
            ObjectSettings objectSettings = new ObjectSettings
            {
                HtmlContent = content,
                WebSettings = webSettings
            };
            HtmlToPdfDocument htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings },
            };
            return _converter.Convert(htmlToPdfDocument);
        }

    }
}
