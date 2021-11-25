using AutoMapper;
using Common.Constants;
using Common.Helper;
using DataAccess.Enums;
using DataTransferObjects.DTOs.Orders;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordaShop.Admin.Models.Order;
using NordaShop.IntegrationApi.Interfaces;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderApiClient _orderApi;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public OrderController(IOrderApiClient orderApi, 
            IMapper mapper, 
            IHttpContextAccessor httpContext)
        {
            _orderApi = orderApi;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<IActionResult> Index()
        {
            string keyword = _httpContext.HttpContext.Request.Query["keyword"].ToString();
            int.TryParse(_httpContext.HttpContext.Request.Query["pageindex"], out int pageIndex);
            var fromDate = ConvertDateTimeHelper.ConvertDateTime(_httpContext.HttpContext.Request.Query["fromdate"].ToString());
            var toDate = ConvertDateTimeHelper.ConvertDateTime(_httpContext.HttpContext.Request.Query["todate"].ToString());
            
            var statusAsSTring = _httpContext.HttpContext.Request.Query["status"].ToString();
            OrderStatus? status;
            if (string.IsNullOrEmpty(statusAsSTring))
            {
                status = null;
            }
            else
            {
                status = (OrderStatus)Enum.Parse(typeof(OrderStatus), statusAsSTring);
            }
            var paging = new OrderAdminPagingDto()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                FromDate = fromDate,
                ToDate = toDate,
                OrderStatus = status
            };
            if (fromDate != null && toDate != null && fromDate > toDate)
            {
                SetAlert(NotificationConstants.OrderDateFilterInvalid, "warning");
            }
            var orders = await _orderApi.GetAdminPaging(paging);
            var model = new OrderIndexViewModel();
            if (orders != null)
            {
                model.FromDate = fromDate;
                model.ToDate = toDate;
                model.Keyword = keyword;
                model.OrderStatus = status;
                model.Orders = new PageResult<List<OrderInfoViewModel>>()
                {
                    PageIndex = orders.PageIndex,
                    PageSize = orders.PageSize,
                    TotalRecords = orders.TotalRecords,
                    Items = _mapper.Map<List<OrderDto>, List<OrderInfoViewModel>>(orders.Items)
                };
            }
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var response = await _orderApi.GetById(id);
            var model = new OrderViewModel();
            if (response != null && response.Success)
            {
                model = _mapper.Map<OrderViewModel>(response.Data);
                model.QRCodeLink = BitmapExtensions.CreateQRCodeBitMapAsUrl(response.Data.QRCodeContent);
                return View(model);
            }
            else
            {
                SetAlert(NotificationConstants.OrderNotFound, "error");
                return RedirectToAction(nameof(OrderController.Index));
            }
        }

        public async Task<JsonResult> ChangeStatus(int orderId, OrderStatus status)
        {
            var response = await _orderApi.ChangeOrderStatus(orderId, status);
            if (response)
            {
                SetAlert(NotificationConstants.UpDateSuccess, "success");
            }
            else
            {
                SetAlert(NotificationConstants.UpdateFailed, "error");
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult GetOrderStatus(int orderId, OrderStatus status)
        {
            return ViewComponent("OrderStatus", new { orderId, status });
        }

        public async Task<IActionResult> Download(int id)
        {
            var pdfFile = await _orderApi.GetOrderDownloadTemplate(id);
            return File(pdfFile, "application/pdf", "order.pdf");
        }

    }
}
