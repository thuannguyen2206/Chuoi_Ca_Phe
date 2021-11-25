using AutoMapper;
using DataTransferObjects.DTOs.Products;
using Microsoft.AspNetCore.Mvc;
using NordaShop.Admin.Models.Product;
using NordaShop.IntegrationApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers.Components
{
    public class GalleryViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IProductApiClient _productApi;

        public GalleryViewComponent(IMapper mapper, IProductApiClient productApi)
        {
            _mapper = mapper;
            _productApi = productApi;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var model = new List<ProductImageViewModel>();
            var result = await _productApi.LoadProductImages(productId);
            if (result != null && result.Success)
            {
                model = _mapper.Map<List<ProductImageDto>, List<ProductImageViewModel>>(result.Data);
            }
            ViewBag.ProductId = productId;
            return View(model);
        }

    }
}
