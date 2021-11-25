using AutoMapper;
using Common.Constants;
using Common.Messages;
using DataTransferObjects.DTOs.Contacts;
using DataTransferObjects.DTOs.Users;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordaShop.Admin.Models.User;
using NordaShop.IntegrationApi.Interfaces;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserApiClient _userApi;
        private readonly IMapper _mapper;
        private readonly IContactApiClient _contactApi;

        public UserController(IHttpContextAccessor httpContext, 
            IUserApiClient userApi, 
            IMapper mapper, 
            IContactApiClient contactApi)
        {
            _httpContext = httpContext;
            _userApi = userApi;
            _mapper = mapper;
            _contactApi = contactApi;
        }

        public async Task<IActionResult> Index()
        {
            string keyword = _httpContext.HttpContext.Request.Query["keyword"].ToString();
            //int.TryParse(_httpContext.HttpContext.Request.Query["pagesize"], out int pageSize);
            int.TryParse(_httpContext.HttpContext.Request.Query["pageindex"], out int pageIndex);
            
            var paging = new UserAdminPagingDto()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                //PageSize = pageSize
            };
            var users = await _userApi.GetPagings(paging);
            var model = new PageResult<List<UserViewModel>>();
            if (users != null && users.Items != null)
            {
                model.PageIndex = users.PageIndex;
                model.PageSize = users.PageSize;
                model.TotalRecords = users.TotalRecords;
                model.Items = _mapper.Map<List<UserDto>, List<UserViewModel>>(users.Items);
            }
            
            ViewBag.Keyword = keyword;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            var user = await _userApi.GetById(Guid.Parse(userId), true);
            if (user != null && user.Success)
            {
                var model = _mapper.Map<UserEditViewModel>(user.Data);
                return View(model);
            }
            SetAlert(NotificationConstants.UserNotFound, "error");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> MyProfile(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (string.IsNullOrEmpty(model.CurrentPassword) && !string.IsNullOrEmpty(model.NewPassword))
            {
                SetAlert(NotificationConstants.InputCurrentPass, "warning");
                return View(model);
            }

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
                SetAlert(NotificationConstants.UpDateSuccess, "success");
            }
            else
            {
                switch (response.ErrorCode)
                {
                    case UserMessage.NotFound:
                        SetAlert(NotificationConstants.UserNotFound, "error");
                        break;
                    case UserMessage.ExistUserName:
                        SetAlert(NotificationConstants.ExistUserName, "error");
                        break;
                    case UserMessage.ChangePassFailed:
                        SetAlert(NotificationConstants.ChangePassFailed, "error");
                        break;
                    case UserMessage.UpdateFailed:
                        SetAlert(NotificationConstants.UpdateFailed, "error");
                        break;
                }
                return View(model);
            }
            return RedirectToAction(nameof(UserController.MyProfile));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new UserCreateDto()
            {
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsActive = model.IsActive,
                Password = model.NewPassword,
                Username = model.Username,
                PhoneNumber = model.PhoneNumber,
                IsAdmin = model.IsAdmin
            };
            var response = await _userApi.Create(dto);
            if (response.Success)
            {
                SetAlert(NotificationConstants.CreateSuccess, "success");
                return RedirectToAction(nameof(UserController.Index));
            }

            switch (response.ErrorCode)
            {
                case UserMessage.ExistUserName:
                    SetAlert(NotificationConstants.ExistUserName, "error");
                    break;
                case UserMessage.ExistEmail:
                    SetAlert(NotificationConstants.ExistEmail, "error");
                    break;
                case UserMessage.CreateFailed:
                    SetAlert(NotificationConstants.CreateFailed, "error");
                    break;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userApi.GetById(id, true);
            if (user != null && user.Success)
            {
                var model = _mapper.Map<UserEditViewModel>(user.Data);
                return View(model);
            }
            SetAlert(NotificationConstants.UserNotFound, "error");
            return RedirectToAction(nameof(UserController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = new UserUpdateDto()
            {
                Id = model.Id,
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsActive = model.IsActive,
                PhoneNumber = model.PhoneNumber,
                Username = model.Username
            };
            var response = await _userApi.Update(model.Id, dto);
            if (response.Success)
            {
                SetAlert(NotificationConstants.UpDateSuccess, "success");
                return RedirectToAction(nameof(UserController.Index));
            }

            switch (response.ErrorCode)
            {
                case UserMessage.ExistUserName:
                    SetAlert(NotificationConstants.ExistUserName, "error");
                    break;
                case UserMessage.NotFound:
                    SetAlert(NotificationConstants.UserNotFound, "error");
                    break;
                case UserMessage.UpdateFailed:
                    SetAlert(NotificationConstants.UpdateFailed, "error");
                    break;
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _userApi.Delete(id);
            if (response)
            {
                SetAlert(NotificationConstants.DeleteSuccess, "success");
            }
            else
            {
                SetAlert(NotificationConstants.DeleteFailed, "error");
            }
            return RedirectToAction(nameof(UserController.Index));
        }

        [HttpGet]
        public async Task<IActionResult> ListContacts()
        {
            string keyword = _httpContext.HttpContext.Request.Query["keyword"].ToString();
            int.TryParse(_httpContext.HttpContext.Request.Query["pageindex"], out int pageIndex);

            var paging = new PagingDto()
            {
                Keyword = keyword,
                PageIndex = pageIndex
            };
            var contacts = await _contactApi.GetListContactPaging(paging);
            var model = new PageResult<List<ContactViewModel>>();
            if(contacts != null){
                model.PageIndex = contacts.PageIndex;
                model.PageSize = contacts.PageSize;
                model.TotalRecords = contacts.TotalRecords;
                model.Items = _mapper.Map<List<ContactDto>, List<ContactViewModel>>(contacts.Items);
            }
            ViewBag.Keyword = keyword;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ContactDetail(int id)
        {
            var conatct = await _contactApi.GetById(id);
            if (conatct != null && conatct.Success)
            {
                var model = _mapper.Map<ContactViewModel>(conatct.Data);
                return View(model);
            }
            SetAlert(NotificationConstants.FeedbackNotFound, "error");
            return RedirectToAction(nameof(UserController.ListContacts));
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var response = await _contactApi.Delete(id);
            if (response)
            {
                SetAlert(NotificationConstants.DeleteSuccess, "success");
            }
            else
            {
                SetAlert(NotificationConstants.DeleteFailed, "error");
            }
            return RedirectToAction(nameof(UserController.ListContacts));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            this._httpContext.HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}
