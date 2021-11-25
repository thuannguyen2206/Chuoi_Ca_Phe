using AutoMapper;
using Common.Constants;
using DataTransferObjects.DTOs.Sliders;
using Microsoft.AspNetCore.Mvc;
using NordaShop.Admin.Models.Slide;
using NordaShop.IntegrationApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class SlideController : BaseController
    {
        private readonly ISlideApiClient _slideApi;
        private readonly IMapper _mapper;

        public SlideController(ISlideApiClient slideApi, IMapper mapper)
        {
            _slideApi = slideApi;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _slideApi.GetAll();
            var model = new List<SlideViewModel>();
            if (sliders != null && sliders.Success)
            {
                model = _mapper.Map<List<SliderDto>, List<SlideViewModel>>(sliders.Data);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CESlideViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new CESliderDto()
            {
                ImageFile = model.ImageFile,
                IsActive = model.IsActive,
                Name = model.Name,
                SortOrder = model.SortOrder,
                Title = model.Title
            };
            var success = await _slideApi.Create(dto);
            if (success)
            {
                SetAlert(NotificationConstants.CreateSuccess, "success");
                return RedirectToAction(nameof(SlideController.Index));
            }
            SetAlert(NotificationConstants.CreateFailed, "error");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var slider = await _slideApi.GetById(id);
            if (slider != null && slider.Success)
            {
                var model = new CESlideViewModel()
                {
                    Id = slider.Data.Id,
                    Title = slider.Data.Title,
                    SortOrder = slider.Data.SortOrder,
                    IsActive = slider.Data.IsActive,
                    Name = slider.Data.Name
                };
                return View(model);
            }
            SetAlert(NotificationConstants.MenuNotFound, "error");
            return RedirectToAction(nameof(SlideController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CESlideViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = new CESliderDto()
            {
                Id = model.Id,
                Title = model.Title,
                SortOrder = model.SortOrder,
                IsActive = model.IsActive,
                Name = model.Name,
                ImageFile = model.ImageFile
            };
            var success = await _slideApi.Update(model.Id, dto);
            if (success)
            {
                SetAlert(NotificationConstants.UpDateSuccess, "success");
                return RedirectToAction(nameof(SlideController.Index));
            }
            SetAlert(NotificationConstants.UpdateFailed, "error");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _slideApi.Delete(id);
            if (response)
            {
                SetAlert(NotificationConstants.DeleteSuccess, "success");
            }
            else
            {
                SetAlert(NotificationConstants.DeleteFailed, "error");
            }
            return RedirectToAction(nameof(SlideController.Index));
        }
    }
}
