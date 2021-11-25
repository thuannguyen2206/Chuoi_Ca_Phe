using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Common.Constants;
using Common.Enums;
using DataTransferObjects.DTOs.Brands;
using DataTransferObjects.DTOs.Categories;
using DataTransferObjects.DTOs.Options;
using DataTransferObjects.DTOs.Products;
using DataTransferObjects.DTOs.Tags;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Models.Brand;
using NordaShop.WebApp.Models.Category;
using NordaShop.WebApp.Models.Option;
using NordaShop.WebApp.Models.Product;
using NordaShop.WebApp.Models.Promotion;
using NordaShop.WebApp.Models.Tag;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApi;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICategoryApiClient _categoryApi;
        private readonly IOptionApiClient _optionApi;
        private readonly IBrandApiClient _brandApi;
        private readonly IPromotionApiClient _promotionApi;
        private readonly ITagApiClient _tagApi;
        private readonly INotyfService _notyf;

        public ProductController(IProductApiClient productApi, 
            IMapper mapper, 
            IHttpContextAccessor httpContext,
            ICategoryApiClient categoryApi, 
            IOptionApiClient optionApi, 
            IBrandApiClient brandApi,
            IPromotionApiClient promotionApi,
            ITagApiClient tagApi,
            INotyfService notyf)
        {
            _productApi = productApi;
            _mapper = mapper;
            _categoryApi = categoryApi;
            _optionApi = optionApi;
            _brandApi = brandApi;
            _httpContext = httpContext;
            _promotionApi = promotionApi;
            _tagApi = tagApi;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            string keyword = _httpContext.HttpContext.Request.Query["keyword"].ToString();
            int.TryParse(_httpContext.HttpContext.Request.Query["pagesize"], out int pageSize);
            int.TryParse(_httpContext.HttpContext.Request.Query["pageindex"], out int pageIndex);
            int.TryParse(_httpContext.HttpContext.Request.Query["categoryid"], out int categoryid);
            decimal.TryParse(_httpContext.HttpContext.Request.Query["fromprice"], out decimal fromprice);
            decimal.TryParse(_httpContext.HttpContext.Request.Query["toprice"], out decimal toprice);
            int.TryParse(_httpContext.HttpContext.Request.Query["sort"], out int sort);
            int.TryParse(_httpContext.HttpContext.Request.Query["tagid"], out int tagid);
            var brandArr = _httpContext.HttpContext.Request.Query["brand"].ToArray();
            var optionArr = _httpContext.HttpContext.Request.Query["option"].ToArray();
            int[] brands = Array.ConvertAll(brandArr, int.Parse);
            int[] options = Array.ConvertAll(optionArr, int.Parse);

            var paging = new SitePagingDto()
            {
                CategoryId = categoryid,
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                SortProduct = (SortProduct)sort,
                FromPrice = fromprice,
                ToPrice = toprice,
                Options = options,
                Brands = brands,
                TagId = tagid
            };
            var products = await _productApi.GetPagings(paging);
            var categories = await _categoryApi.GetAll();
            var listOptions = await _optionApi.GetOptions();
            var maxPrice = await _productApi.GetMaxPrice();
            var listBrands = await _brandApi.GetAll();
            var promotion = await _promotionApi.GetOnShow();
            var tags = await _tagApi.GetTopProductTags();
            var model = new ShopViewModel()
            {
                Products = new PageResult<List<ProductViewModel>>()
                {
                    PageIndex = products.PageIndex,
                    PageSize = products.PageSize,
                    TotalRecords = products.TotalRecords,
                    Items = _mapper.Map<List<ProductDto>, List<ProductViewModel>>(products.Items)
                },
                Options = _mapper.Map<List<OptionDto>, List<OptionViewModel>>(listOptions.Data),
                Categories = _mapper.Map<List<CategoryDto>, List<CategoryViewModel>>(categories.Data),
                Brands = _mapper.Map<List<BrandDto>, List<BrandViewModel>>(listBrands.Data),
                Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(tags.Data),
                FilterProduct = (SortProduct)sort,
                PageSize = pageSize,
                MaxPrice = maxPrice
            };
            if (promotion != null && promotion.Success)
            {
                model.Promotion = _mapper.Map<PromotionViewModel>(promotion.Data);
            }

            foreach (var item in model.Options ?? Enumerable.Empty<OptionViewModel>())
            {
                if (options.Contains(item.Id))
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
            foreach (var item in model.Brands ?? Enumerable.Empty<BrandViewModel>())
            {
                if (brands.Contains(item.Id))
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
            ViewBag.Keyword = keyword;
            ViewBag.CategoryId = categoryid;
            ViewBag.FromPrice = fromprice;
            ViewBag.ToPrice = toprice;
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> Search(string keyword)
        {
            var response = await _productApi.Search(keyword);
            if (response != null && response.Success)
            {
                return Json(response.Data);
            }
            return Json(null);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _productApi.GetById(id);
            var products = await _productApi.GetRelated(id);
            var options = await _optionApi.GetOptionByProductId(id);
            var tags = await _tagApi.GetTagOfProduct(id);
            var colors = await _optionApi.GetRelatedColor(id);
            var ratings = await _productApi.GetProductRating(id);
            var model = new ProductDetailViewModel()
            {
                RelatedProducts = _mapper.Map<List<ProductDto>, List<ProductViewModel>>(products.Data),
                Product = _mapper.Map<ProductDto, ProductViewModel>(product.Data),
                Options = _mapper.Map<List<OptionDto>, List<OptionViewModel>>(options.Data),
                Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(tags.Data),
                RelatedColors = _mapper.Map<List<RelatedColorDto>, List<RelatedColorViewModel>>(colors.Data),
                ProductRatings = _mapper.Map<List<ProductRatingDto>, List<ProductRatingViewModel>>(ratings.Data)
            };

            if (product.Success)
            {
                return View(model);
            }
            _notyf.Error("Không tìm thấy sản phẩm này");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult QuickViewProduct(int id)
        {
            return ViewComponent("QuickViewProduct", id);
        }

        public async Task<JsonResult> CreateNewRating(ProductRatingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyf.Error(NotificationConstants.InvalidForm);
                return Json(new { status = false });
            }
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            var dto = new ProductRatingDto()
            {
                UserId = !string.IsNullOrEmpty(userId) ? Guid.Parse(userId) : Guid.Empty,
                Email = model.Email,
                Name = model.Name,
                ProductId = model.ProductId,
                RatingContent = model.RatingContent,
                RatingStar = model.RatingStar
            };
            var response = await _productApi.CreateNewRating(dto);
            if (response != null && response.Success)
            {
                _notyf.Success(NotificationConstants.CreateRatingSusscess);
                return Json(new { status = true, data = dto });
            }
            _notyf.Error(NotificationConstants.Error);
            return Json(new { status = false });
        }

    }
}
