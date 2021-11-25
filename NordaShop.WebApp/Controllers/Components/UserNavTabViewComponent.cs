using AutoMapper;
using Common.Constants;
using DataTransferObjects.DTOs.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Enums;
using NordaShop.WebApp.Models.Order;
using NordaShop.WebApp.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers.Components
{
    public class UserNavTabViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserApiClient _userApi;
        private readonly IOrderApiClient _orderApi;
        private readonly IMapper _mapper;


        public UserNavTabViewComponent(IHttpContextAccessor httpContext, IUserApiClient userApi, 
            IOrderApiClient orderApi, IMapper mapper)
        {
            _httpContext = httpContext;
            _orderApi = orderApi;
            _userApi = userApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(UserNavTab nav)
        {
            var session = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            var userId = Guid.Parse(session ?? Guid.Empty.ToString());
            string viewName = string.Empty;
            object model = null;
            switch (nav)
            {
                case UserNavTab.Dashboard:
                    viewName = "Default";
                    model = await GetDashboard(userId);
                    break;
                case UserNavTab.Orders:
                    viewName = "Order";
                    model = await GetUserOrders(userId);
                    break;
                case UserNavTab.Download:
                    viewName = "Download";
                    break;
                case UserNavTab.PaymentMethod:
                    viewName = "PaymentMethod";
                    break;
                case UserNavTab.Address:
                    viewName = "Address";
                    break;
                case UserNavTab.AccountDetail:
                    viewName = "AccountDetail";
                    model = await GetAccountDetail(userId);
                    break;
            }
            return View(viewName, model);
        }


        private async Task<UserViewModel> GetAccountDetail(Guid userId)
        {
            var response = await _userApi.GetById(userId);
            var model = new UserViewModel();
            if (response != null && response.Success)
            {
                model = _mapper.Map<UserViewModel>(response.Data);
            }
            return model;
        }

        private async Task<List<OrderViewModel>> GetUserOrders(Guid userId)
        {
            var response = await _orderApi.GetUserOrders(userId);
            var model = new List<OrderViewModel>();
            if (response != null && response.Success)
            {
                model = _mapper.Map<List<UserOrderDto>, List<OrderViewModel>>(response.Data);
            }
            return model;
        }

        private async Task<DashboardViewModel> GetDashboard(Guid userId)
        {
            var response = await _userApi.GetDashboard(userId);
            var model = new DashboardViewModel();
            if (response != null && response.Success)
            {
                model = _mapper.Map<DashboardViewModel>(response.Data);
            }
            return model;
        }

    }
}
