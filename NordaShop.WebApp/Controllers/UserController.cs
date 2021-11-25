using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Common.Constants;
using Common.Messages;
using DataTransferObjects.DTOs.Users;
using DataTransferObjects.DTOs.WishLists;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Enums;
using NordaShop.WebApp.Filters;
using NordaShop.WebApp.Models.Order;
using NordaShop.WebApp.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers
{
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApi;
        private readonly IHttpContextAccessor _httpContext;
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;
        private readonly IOrderApiClient _orderApi;

        public UserController(IUserApiClient userApi, IHttpContextAccessor httpContext, 
            INotyfService notyf, IMapper mapper, IOrderApiClient orderApi)
        {
            _userApi = userApi;
            _httpContext = httpContext;
            _notyf = notyf;
            _mapper = mapper;
            _orderApi = orderApi;
        }

        public IActionResult Index(UserNavTabViewModel userNavTab)
        {
            if (userNavTab == null)
            {
                userNavTab = new UserNavTabViewModel
                {
                    NavTab = UserNavTab.Dashboard
                };
            }
            return View(userNavTab);
        }

        public IActionResult SwitchUserNavTab(UserNavTab nav)
        {
            var userNavTab = new UserNavTabViewModel()
            {
                NavTab = nav
            };
            return RedirectToAction(nameof(UserController.Index), userNavTab);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddToWishList(int productId)
        {
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            if (string.IsNullOrEmpty(userId))
            {
                _notyf.Information(NotificationConstants.NotLogging);
                return Json(false);
            }
            var response = await _userApi.AddToWishlist(Guid.Parse(userId), productId);
            if (response != null && response.Success && response.ErrorCode == UserMessage.WishlistExisted)
            {
                _notyf.Information(NotificationConstants.ExistInWishlist);
                return Json(false);
            }
            else if (response != null && response.Success)
            {
                _notyf.Success(NotificationConstants.AddToWishlistSuccess);
                return Json(true);
            }
            else
            {
                _notyf.Error(NotificationConstants.Error);
                return Json(false);
            }
        }

        [HttpGet]
        public async Task<IActionResult> WishList()
        {
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            var response = await _userApi.GetWishList(Guid.Parse(userId ?? Guid.Empty.ToString()));
            if (response!=null && response.Success)
            {
                var model = _mapper.Map<List<WishListDto>, List<WishListViewModel>>(response.Data);
                return View(model);
            }
            _notyf.Error(NotificationConstants.WishlistNotFound);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RemoveWishlistItem(int id) // product id
        {
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            if (string.IsNullOrEmpty(userId))
            {
                _notyf.Error(NotificationConstants.UserNotFound);
            }
            else
            {
                var response = await _userApi.RemoveWishlistItem(Guid.Parse(userId), id);
                if (response)
                {
                    _notyf.Success(NotificationConstants.DeleteSuccess);
                }
                else
                {
                    _notyf.Error(NotificationConstants.DeleteFailed);
                }
            }
            return RedirectToAction(nameof(UserController.WishList));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInfo(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyf.Warning(NotificationConstants.InvalidForm);
            }
            else if(string.IsNullOrEmpty(model.CurrentPassword) && !string.IsNullOrEmpty(model.NewPassword))
            {
                _notyf.Warning(NotificationConstants.InputCurrentPass);
            }
            else
            {
                var dto = new UserUpdateDto()
                {
                    Address = model.Address,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    IsActive = true,
                    CurrentPassword = model.CurrentPassword,
                    NewPassword = model.NewPassword,
                    Username = model.Username
                };
                var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
                var response = await _userApi.Update(Guid.Parse(userId ?? Guid.Empty.ToString()), dto);
                if (response.Success)
                {
                    _notyf.Success(NotificationConstants.UpDateSuccess);
                }
                else
                {
                    switch (response.ErrorCode)
                    {
                        case UserMessage.NotFound:
                            _notyf.Error(NotificationConstants.UserNotFound);
                            break;
                        case UserMessage.ExistUserName:
                            _notyf.Error(NotificationConstants.ExistUserName);
                            break;
                        case UserMessage.ChangePassFailed:
                            _notyf.Error(NotificationConstants.ChangePassFailed);
                            break;
                        case UserMessage.UpdateFailed:
                            _notyf.Error(NotificationConstants.Error);
                            break;
                    }
                }
            }
            return RedirectToAction("Index", "User", new UserNavTabViewModel() { NavTab= UserNavTab.AccountDetail });
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            this._httpContext.HttpContext.Session.Clear();
            return RedirectToAction("SignIn", "Account");
        }

    }
}
