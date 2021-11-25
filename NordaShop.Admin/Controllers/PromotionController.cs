using AutoMapper;
using Common.Constants;
using DataTransferObjects.DTOs.Promotions;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordaShop.Admin.Models.Promotion;
using NordaShop.IntegrationApi.Interfaces;
using Service.ApiResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class PromotionController : BaseController
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IPromotionApiClient _promotionApi;

        public PromotionController(IHttpContextAccessor httpContext, IMapper mapper, IPromotionApiClient promotionApi)
        {
            _httpContext = httpContext;
            _mapper = mapper;
            _promotionApi = promotionApi;
        }

        public async Task<IActionResult> Index()
        {
            string keyword = _httpContext.HttpContext.Request.Query["keyword"].ToString();
            int.TryParse(_httpContext.HttpContext.Request.Query["pageindex"], out int pageIndex);

            var paging = new PagingDto()
            {
                Keyword = keyword,
                PageIndex = pageIndex
            };

            var result = await _promotionApi.GetPagings(paging);
            var model = new PageResult<List<PromotionViewModel>>();
            if (result != null)
            {
                model.Items = _mapper.Map<List<PromotionDto>, List<PromotionViewModel>>(result.Items);
                model.PageIndex = result.PageIndex;
                model.PageSize = result.PageSize;
                model.TotalRecords = result.TotalRecords;
            }
            ViewBag.Keyword = keyword;
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PromotionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new PromotionDto()
            {
                Description = model.Description,
                DiscountCode = model.DiscountCode,
                DiscountPercent = model.DiscountPercent,
                ExpireTime = model.ExpireTime,
                IsShow = model.IsShow,
                IsValid = model.IsValid,
                StartTime = model.StartTime,
                MaxValueDiscount = model.MaxValueDiscount
            };
            var response = await _promotionApi.Create(dto);
            if (response.Success)
            {
                SetAlert(NotificationConstants.CreateSuccess, "success");
                return RedirectToAction(nameof(PromotionController.Index));
            }
            SetAlert(NotificationConstants.CreateFailed, "error");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var option = await _promotionApi.GetById(id);
            if (option != null && option.Success)
            {
                var model = _mapper.Map<PromotionViewModel>(option.Data);
                return View(model);
            }
            SetAlert(NotificationConstants.PromotionNotFound, "error");
            return RedirectToAction(nameof(PromotionController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PromotionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = new PromotionDto()
            {
                Description = model.Description,
                DiscountCode = model.DiscountCode,
                DiscountPercent = model.DiscountPercent,
                ExpireTime = model.ExpireTime,
                IsShow = model.IsShow,
                IsValid = model.IsValid,
                StartTime = model.StartTime,
                MaxValueDiscount = model.MaxValueDiscount
            };
            var response = await _promotionApi.Update(model.Id, dto);
            if (response != null && response.Success)
            {
                SetAlert(NotificationConstants.UpDateSuccess, "success");
                return RedirectToAction(nameof(PromotionController.Index));
            }
            SetAlert(NotificationConstants.UpdateFailed, "error");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _promotionApi.Delete(id);
            if (response)
            {
                SetAlert(NotificationConstants.DeleteSuccess, "success");
            }
            else
            {
                SetAlert(NotificationConstants.DeleteFailed, "error");
            }
            return RedirectToAction(nameof(PromotionController.Index));
        }

    }
}
