using AutoMapper;
using Common.Constants;
using DataTransferObjects.DTOs.Brands;
using Microsoft.AspNetCore.Mvc;
using NordaShop.Admin.Models.Brand;
using NordaShop.IntegrationApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IBrandApiClient _brandApi;
        private readonly IMapper _mapper;

        public BrandController(IBrandApiClient brandApi, IMapper mapper)
        {
            _brandApi = brandApi;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _brandApi.GetAll(true);
            var model = new List<BrandViewModel>();
            if (brands != null && brands.Success)
            {
                model = _mapper.Map<List<BrandDto>, List<BrandViewModel>>(brands.Data);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new BrandDto()
            {
                BrandName = model.BrandName,
                BrandFile = model.BrandFile,
                IsActive = model.IsActive,
                SeoAlias = model.SeoAlias
            };
            var response = await _brandApi.Create(dto);
            if (response)
            {
                SetAlert(NotificationConstants.CreateSuccess, "success");
                return RedirectToAction(nameof(BrandController.Index));
            }
            SetAlert(NotificationConstants.CreateFailed, "error");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _brandApi.GetById(id);
            if (brand != null && brand.Success)
            {
                var model = _mapper.Map<BrandViewModel>(brand.Data);
                return View(model);
            }
            SetAlert(NotificationConstants.BrandNotFound, "error");
            return RedirectToAction(nameof(BrandController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BrandViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = new BrandDto()
            {
                IsActive = model.IsActive,
                BrandFile = model.BrandFile,
                BrandName = model.BrandName,
                Id = model.Id,
                SeoAlias = model.SeoAlias
            };
            var response = await _brandApi.Update(model.Id, dto);
            if (response)
            {
                SetAlert(NotificationConstants.UpDateSuccess, "success");
                return RedirectToAction(nameof(BrandController.Index));
            }
            SetAlert(NotificationConstants.UpdateFailed, "error");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _brandApi.Delete(id);
            if (response)
            {
                SetAlert(NotificationConstants.DeleteSuccess, "success");
            }
            else
            {
                SetAlert(NotificationConstants.DeleteFailed, "error");
            }
            return RedirectToAction(nameof(BrandController.Index));
        }

    }
}
