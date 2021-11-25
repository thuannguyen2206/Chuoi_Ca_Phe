using AutoMapper;
using Common.Constants;
using DataTransferObjects.DTOs.Menus;
using Microsoft.AspNetCore.Mvc;
using NordaShop.Admin.Models.Menu;
using NordaShop.IntegrationApi.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuApiClient _menuApi;
        private readonly IMapper _mapper;

        public MenuController(IMenuApiClient menuApi, IMapper mapper)
        {
            _menuApi = menuApi;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var menus = await _menuApi.GetAll(true);
            var model = new List<MenuViewModel>();
            if (menus != null && menus.Success)
            {
                model = _mapper.Map<List<MenuDto>, List<MenuViewModel>>(menus.Data);
            }
            return View(model);
        }

        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new MenuDto()
            {
                DisplayOrder = model.DisplayOrder,
                IsActive = model.IsActive,
                Link = model.Link,
                Name = model.Name,
                SeoAlias = model.SeoAlias
            };
            var response = await _menuApi.Create(dto);
            if (response.Success)
            {
                SetAlert(NotificationConstants.CreateSuccess, "success");
                return RedirectToAction(nameof(MenuController.Index));
            }
            SetAlert(NotificationConstants.CreateFailed, "error");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _menuApi.GetById(id);
            if (category != null && category.Success)
            {
                var model = _mapper.Map<MenuViewModel>(category.Data);
                return View(model);
            }
            SetAlert(NotificationConstants.MenuNotFound, "error");
            return RedirectToAction(nameof(MenuController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MenuViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = new MenuDto()
            {
                DisplayOrder = model.DisplayOrder,
                IsActive = model.IsActive,
                Link = model.Link,
                Name = model.Name,
                Id = model.Id,
                SeoAlias = model.SeoAlias
            };
            var response = await _menuApi.Update(model.Id, dto);
            if (response != null && response.Success)
            {
                SetAlert(NotificationConstants.UpDateSuccess, "success");
                return RedirectToAction(nameof(MenuController.Index));
            }
            SetAlert(NotificationConstants.UpdateFailed, "error");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _menuApi.Delete(id);
            if (response)
            {
                SetAlert(NotificationConstants.DeleteSuccess, "success");
            }
            else
            {
                SetAlert(NotificationConstants.DeleteFailed, "error");
            }
            return RedirectToAction(nameof(MenuController.Index));
        }

    }
}
