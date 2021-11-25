using AutoMapper;
using Common.Constants;
using DataTransferObjects.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NordaShop.Admin.Models.Category;
using NordaShop.IntegrationApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryApiClient _categoryApi;
        private readonly IMapper _mapper;
        private readonly IMenuApiClient _menuApi;

        public CategoryController(ICategoryApiClient categoryApi, IMapper mapper, IMenuApiClient menuApi)
        {
            _categoryApi = categoryApi;
            _mapper = mapper;
            _menuApi = menuApi;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _categoryApi.GetAll(true);
            var model = new List<CategoryViewModel>();
            if (response != null && response.Success)
            {
                model = _mapper.Map<List<CategoryDto>, List<CategoryViewModel>>(response.Data);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var menus = await _menuApi.GetAll();
            ViewBag.Menus = menus.Data.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            var categories = await _categoryApi.GetAll();
            ViewBag.Categories = categories.Data.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCEViewModel model)
        {
            var menus = await _menuApi.GetAll();
            ViewBag.Menus = menus.Data.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == model.MenuId
            });
            var categories = await _categoryApi.GetAll();
            ViewBag.Categories = categories.Data.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = x.Id == model.ParentId
            });
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new CategoryDto()
            {
                Description = model.Description,
                Name = model.Name,
                IsActive = model.IsActive,
                ParentId = model.ParentId,
                Title = model.Title,
                SortOrder = model.SortOrder,
                MenuId = model.MenuId,
                SeoAlias = model.SeoAlias
            };
            var response = await _categoryApi.Create(dto);
            if (response.Success)
            {
                SetAlert(NotificationConstants.CreateSuccess, "success");
                return RedirectToAction(nameof(CategoryController.Index));
            }
            SetAlert(NotificationConstants.CreateFailed, "error");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryApi.GetById(id);
            if (category != null && category.Success)
            {
                var menus = await _menuApi.GetAll();
                ViewBag.Menus = menus.Data.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                    Selected = x.Id == category.Data.MenuId
                });
                var categories = await _categoryApi.GetAll();
                ViewBag.Categories = categories.Data.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = x.ParentId.HasValue && x.ParentId > 0 && x.ParentId == category.Data.ParentId
                });

                var model = _mapper.Map<CategoryCEViewModel>(category.Data);
                return View(model);
            }
            SetAlert(NotificationConstants.CategoryNotFound, "error");
            return RedirectToAction(nameof(CategoryController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryCEViewModel model)
        {
            var menus = await _menuApi.GetAll();
            ViewBag.Menus = menus.Data.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == model.MenuId
            });
            var categories = await _categoryApi.GetAll();
            ViewBag.Categories = categories.Data.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = x.ParentId.HasValue && x.ParentId > 0 && x.ParentId == model.ParentId
            });

            if (!ModelState.IsValid)
            {
                SetAlert(NotificationConstants.InvalidForm, "error");
                return View(model);
            }
            var dto = new CategoryDto()
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name,
                IsActive = model.IsActive,
                ParentId = model.ParentId,
                Title = model.Title,
                SortOrder = model.SortOrder,
                MenuId = model.MenuId,
                SeoAlias = model.SeoAlias
            };
            var response = await _categoryApi.Update(model.Id, dto);
            if (response.Success)
            {
                SetAlert(NotificationConstants.UpDateSuccess, "success");
                return RedirectToAction(nameof(UserController.Index));
            }
            SetAlert(NotificationConstants.UpdateFailed, "error");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryApi.Delete(id);
            if (response)
            {
                SetAlert(NotificationConstants.DeleteSuccess, "success");
            }
            else
            {
                SetAlert(NotificationConstants.DeleteFailed, "error");
            }
            return RedirectToAction(nameof(CategoryController.Index));
        }

    }
}
