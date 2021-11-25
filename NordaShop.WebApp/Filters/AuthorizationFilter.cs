using Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpContext;

        public AuthorizationFilter(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.Any(item => item is AllowAnonymousAttribute))
            {
                return;
            }

            string userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new RedirectResult("/Account/SignIn");
            }

            //if (context.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            //    if (string.IsNullOrEmpty(userId))
            //    {
            //        context.Result = new RedirectResult("/Account/SignIn");
            //    }
            //}
            //else
            //{
            //    context.Result = new RedirectResult("/Account/SignIn");
            //}
        }
    }
}
