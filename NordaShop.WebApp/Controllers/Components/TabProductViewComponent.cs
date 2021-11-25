using AutoMapper;
using DataTransferObjects.DTOs.Products;
using Microsoft.AspNetCore.Mvc;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Enums;
using NordaShop.WebApp.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers.Components
{
    public class TabProductViewComponent : ViewComponent
    {
        private readonly IProductApiClient _productApi;
        private readonly IMapper _mapper;
        public TabProductViewComponent(IProductApiClient productApi, IMapper mapper)
        {
            _productApi = productApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(string tabname)
        {
            var response = await _productApi.GetTabProducts(tabname);
            var model = new List<ProductViewModel>();
            if (response.Success)
            {
                model = _mapper.Map<List<ProductDto>, List<ProductViewModel>>(response.Data);
            }
            return View("Default", model);
        }
    }
}
