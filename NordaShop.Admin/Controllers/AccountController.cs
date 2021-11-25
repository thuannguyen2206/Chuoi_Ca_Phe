using Common.Constants;
using DataTransferObjects.DTOs.Auths;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using NordaShop.Admin.Models.Account;
using NordaShop.IntegrationApi.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IUserApiClient _userApi;
        private readonly IHttpContextAccessor _httpContext;

        public AccountController (IConfiguration config, IUserApiClient userApi, IHttpContextAccessor httpContext)
        {
            _config = config;
            _userApi = userApi;
            _httpContext = httpContext;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = new SignInDto()
            {
                Username = model.Username,
                Password = model.Password,
                AdminRole = true
            };
            var response = await _userApi.SignIn(dto);
            if (!response.Success)
            {
                ModelState.AddModelError(string.Empty, NotificationConstants.SignInFailed);
                return View(model);
            }
            var userPrincipal = this.ValidateToken(response.Data);
            var authProperties = new AuthenticationProperties
            {
                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30), //thời gian xác thực hết hạn
                IsPersistent = model.RememberMe                    //có sử dụng cookie để lưu dữ liệu hay không
            };
            HttpContext.Session.Clear();
            HttpContext.Session.SetString(SystemConstants.Token, response.Data);
            HttpContext.Session.SetString(SystemConstants.UserId, userPrincipal?.FindFirstValue("Id"));
            HttpContext.Session.SetString(SystemConstants.Username, userPrincipal?.FindFirstValue("Username"));
            HttpContext.Session.SetString(SystemConstants.Role, userPrincipal?.FindFirstValue("Role"));
            await  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperties);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        // Encode token and get claims
        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidAudience = _config["Jwt:Audience"],
                ValidIssuer = _config["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]))
            };

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }

    }
}
