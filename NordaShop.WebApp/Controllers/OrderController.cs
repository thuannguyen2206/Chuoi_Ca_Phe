using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Common.Constants;
using Common.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Enums;
using NordaShop.WebApp.Filters;
using NordaShop.WebApp.Models.Order;
using NordaShop.WebApp.Models.QRCode;
using NordaShop.WebApp.Models.User;
using System;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers
{
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderApiClient _orderApi;
        private readonly INotyfService _notyf;
        private readonly IConfiguration _config;

        public OrderController(IMapper mapper, 
            IOrderApiClient orderApi, 
            INotyfService notyf, 
            IConfiguration config)
        {
            _mapper = mapper;
            _orderApi = orderApi;
            _notyf = notyf;
            _config = config;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult OrderTracking()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> OrderTracking(OrderTrackingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Guid.TryParse(model.OrderCode, out Guid orderCode);
            if (orderCode != Guid.Empty)
            {
                var response = await _orderApi.GetByCode(orderCode);
                if (response != null && response.Success)
                {
                    model.Detail = _mapper.Map<DetailViewModel>(response.Data);
                    model.Detail.QRCodeLink = BitmapExtensions.CreateQRCodeBitMapAsUrl(response.Data.QRCodeContent);
                    _notyf.Success(NotificationConstants.OrderTrackingSuccess);
                }
                else
                {
                    ViewBag.Message = NotificationConstants.OrderTrackingNotFound;
                }
            }
            else
            {
                ViewBag.Message = NotificationConstants.OrderCodeInValid;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderItem(int id)
        {
            var order = await _orderApi.GetById(id);
            if (order != null && order.Success)
            {
                var model = _mapper.Map<DetailViewModel>(order.Data);
                model.QRCodeLink = BitmapExtensions.CreateQRCodeBitMapAsUrl(order.Data.QRCodeContent);
                return View(model);
            }
            else
            {
                _notyf.Error(NotificationConstants.OrderNotFound);
                return RedirectToAction("Index", "User", new UserNavTabViewModel() { NavTab = UserNavTab.Orders });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetByCode(Guid id) // id parameter is code of order
        {
            var order = await _orderApi.GetByCode(id);
            if (order != null && order.Success)
            {
                var model = _mapper.Map<DetailViewModel>(order.Data);
                model.QRCodeLink = BitmapExtensions.CreateQRCodeBitMapAsUrl(order.Data.QRCodeContent);
                return View(model);
            }
            else
            {
                _notyf.Error(NotificationConstants.OrderNotFound);
                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        public IActionResult OrderResult(bool success, Guid orderid)
        {
            TempData["SuccessOrder"] = success;
            TempData["OrderCode"] = orderid;
            return View();
        }

        public async Task<IActionResult> Download(int id)
        {
            var pdfFile = await _orderApi.GetOrderDownloadTemplate(id);
            return File(pdfFile, "application/pdf", "order.pdf");
        }

    }
}
