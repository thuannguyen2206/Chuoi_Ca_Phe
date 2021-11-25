using AutoMapper;
using Common.Constants;
using DataTransferObjects.DTOs.Tags;
using Microsoft.AspNetCore.Mvc;
using NordaShop.Admin.Models.Tag;
using NordaShop.IntegrationApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class TagController : BaseController
    {
        private readonly ITagApiClient _tagApi;
        private readonly IMapper _mapper;

        public TagController(ITagApiClient tagApi, IMapper mapper)
        {
            _tagApi = tagApi;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _tagApi.GetAll(true);
            var model = new List<TagViewModel>();
            if (response != null && response.Success)
            {
                model = _mapper.Map<List<TagDto>, List<TagViewModel>>(response.Data);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TagViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new TagDto()
            {
                IsActive = model.IsActive,
                TagName = model.TagName,
                SeoAlias = model.SeoAlias
            };
            var response = await _tagApi.Create(dto);
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
            var tag = await _tagApi.GetById(id);
            if (tag != null && tag.Success)
            {
                var model = _mapper.Map<TagViewModel>(tag.Data);
                return View(model);
            }
            SetAlert(NotificationConstants.TagNotFound, "error");
            return RedirectToAction(nameof(CategoryController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TagViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = new TagDto()
            {
                Id = model.Id,
                IsActive = model.IsActive,
                TagName = model.TagName,
                SeoAlias = model.SeoAlias
            };
            var response = await _tagApi.Update(model.Id, dto);
            if (response.Success)
            {
                SetAlert(NotificationConstants.UpDateSuccess, "success");
                return RedirectToAction(nameof(UserController.Index));
            }
            SetAlert(NotificationConstants.UpdateFailed, "error");
            return View(model);
        }


    }
}
