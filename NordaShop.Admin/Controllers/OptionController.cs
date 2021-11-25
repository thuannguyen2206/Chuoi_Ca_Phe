using AutoMapper;
using DataTransferObjects.DTOs.Options;
using Microsoft.AspNetCore.Mvc;
using NordaShop.Admin.Models.Option;
using NordaShop.IntegrationApi.Interfaces;
using DataAccess.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Common.Constants;

namespace NordaShop.Admin.Controllers
{
    public class OptionController : BaseController
    {
        private readonly IOptionApiClient _optionApi;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public OptionController(IOptionApiClient optionApi, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _optionApi = optionApi;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<IActionResult> Index()
        {
            var options = await _optionApi.GetOptions(true);
            var model = new List<OptionViewModel>();
            if (options != null && options.Success)
            {
                model = _mapper.Map<List<OptionDto>, List<OptionViewModel>>(options.Data);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OptionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.OptionGroup = model.GroupName == "Size" ? ProductOptionGroup.Size : ProductOptionGroup.Color;

            var dto = new OptionDto()
            {
                IsActive = model.IsActive,
                NameOption = model.NameOption,
                OptionGroup = model.OptionGroup,
                SeoAlias = model.SeoAlias
            };
            var response = await _optionApi.Create(dto);
            if (response.Success)
            {
                SetAlert(NotificationConstants.CreateSuccess, "success");
                return RedirectToAction(nameof(OptionController.Index));
            }
            SetAlert(NotificationConstants.CreateFailed, "error");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var option = await _optionApi.GetById(id);
            if (option != null && option.Success)
            {
                var model = _mapper.Map<OptionViewModel>(option.Data);
                model.GroupName = option.Data.OptionGroup.ToString();
                return View(model);
            }
            SetAlert(NotificationConstants.OptionNotFound, "error");
            return RedirectToAction(nameof(OptionController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OptionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.OptionGroup = model.GroupName == "Size" ? ProductOptionGroup.Size : ProductOptionGroup.Color;
            var dto = new OptionDto()
            {
                IsActive = model.IsActive,
                NameOption = model.NameOption,
                OptionGroup = model.OptionGroup,
                Id = model.Id,
                SeoAlias = model.SeoAlias
            };
            var response = await _optionApi.Update(model.Id, dto);
            if (response != null && response.Success)
            {
                SetAlert(NotificationConstants.UpDateSuccess, "success");
                return RedirectToAction(nameof(OptionController.Index));
            }
            SetAlert(NotificationConstants.UpdateFailed, "error");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _optionApi.Delete(id);
            if (response)
            {
                SetAlert(NotificationConstants.DeleteSuccess, "success");
            }
            else
            {
                SetAlert(NotificationConstants.DeleteFailed, "error");
            }
            return RedirectToAction(nameof(OptionController.Index));
        }

    }
}
