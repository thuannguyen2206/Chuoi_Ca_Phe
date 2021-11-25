using AutoMapper;
using DataTransferObjects.DTOs.Options;
using DataTransferObjects.DTOs.Products;
using DataTransferObjects.DTOs.Tags;
using Microsoft.AspNetCore.Mvc;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Models.Option;
using NordaShop.WebApp.Models.Product;
using NordaShop.WebApp.Models.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers.Components
{
    public class QuickViewProductViewComponent : ViewComponent
    {
        private readonly IProductApiClient _productApi;
        private readonly IOptionApiClient _optionApi;
        private readonly ITagApiClient _tagApi;
        private readonly IMapper _mapper;

        public QuickViewProductViewComponent(IProductApiClient productApi, IOptionApiClient optionApi, 
            IMapper mapper, ITagApiClient tagApi)
        {
            _productApi = productApi;
            _optionApi = optionApi;
            _mapper = mapper;
            _tagApi = tagApi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> Product id </param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(int id) // product id
        {
            var product = await _productApi.GetById(id);
            var options = await _optionApi.GetOptionByProductId(id);
            var tags = await _tagApi.GetTagOfProduct(id);
            var colors = await _optionApi.GetRelatedColor(id);
            var model = new QuickViewProductModel()
            {
                Product = _mapper.Map<ProductDto, ProductViewModel>(product.Data),
                Options = _mapper.Map<List<OptionDto>, List<OptionViewModel>>(options.Data),
                Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(tags.Data),
                RelatedColors = _mapper.Map<List<RelatedColorDto>, List<RelatedColorViewModel>>(colors.Data)
            };
            return View(model);
        }
    }
}
