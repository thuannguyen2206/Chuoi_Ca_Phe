using AutoMapper;
using DataTransferObjects.DTOs.Menus;
using Microsoft.AspNetCore.Mvc;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Models.Menu;
using NordaShop.WebApp.Models.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IMenuApiClient _menuApi;
        private readonly IMapper _mapper;

        public FooterViewComponent(IMenuApiClient menuApi, IMapper mapper)
        {
            _menuApi = menuApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menus = await _menuApi.GetAll();
            var model = new FooterViewModel()
            {
                Menus = menus.Success ? _mapper.Map<List<MenuDto>, List<MenuViewModel>>(menus.Data) : null
            };

            return View(model);
        }
    }
}
