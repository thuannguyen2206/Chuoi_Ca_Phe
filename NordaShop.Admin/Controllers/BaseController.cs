using Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.GetString(SystemConstants.UserId);
            var role = context.HttpContext.Session.GetString(SystemConstants.Role);
            if (string.IsNullOrEmpty(session) || string.IsNullOrEmpty(role) || role != "ADMIN")
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
            base.OnActionExecuting(context);
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;

            if (type == "success")
                TempData["AlertType"] = "alert-success";
            else if (type == "warning")
                TempData["AlertType"] = "alert-warning";
            else if (type == "error")
                TempData["AlertType"] = "alert-danger";
        }
    }
}
