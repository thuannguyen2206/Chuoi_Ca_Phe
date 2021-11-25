using DataAccess.Enums;
using Microsoft.AspNetCore.Mvc;
using NordaShop.Admin.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers.Components
{
    public class OrderStatusViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int orderId, OrderStatus status)
        {
            var model = new ChangeOrderStatusViewModel()
            {
                OrderId = orderId,
                OrderStatus = status
            };
            return View("Default", model);
        }
    }
}
