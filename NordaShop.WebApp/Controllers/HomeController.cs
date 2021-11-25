using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Enums;
using NordaShop.WebApp.Models;
using NordaShop.WebApp.Models.Home;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using DataTransferObjects.DTOs.Sliders;
using NordaShop.WebApp.Models.Slide;
using DataTransferObjects.DTOs.Brands;
using NordaShop.WebApp.Models.Brand;
using DataTransferObjects.DTOs.Products;
using NordaShop.WebApp.Models.Product;
using Microsoft.AspNetCore.Http;
using Common.Constants;
using Common.Helper;
using NordaShop.WebApp.Models.Cart;
using DataTransferObjects.DTOs.Carts;
using System.Linq;
using System;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace NordaShop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductApiClient _productApi;
        private readonly ISlideApiClient _slideApi;
        private readonly IBrandApiClient _brandApi;
        private readonly IMapper _mapper;
        private readonly ICartApiClient _cartApi;
        private readonly IHttpContextAccessor _httpContext;
        private readonly INotyfService _notyf;
        private readonly ISession _session;

        public HomeController(ILogger<HomeController> logger, 
            IProductApiClient productApi, 
            ISlideApiClient slideApi, 
            IBrandApiClient brandApi,
            IMapper mapper,
            ICartApiClient cartApi,
            IHttpContextAccessor httpContext,
            INotyfService notyf)
        {
            _logger = logger;
            _productApi = productApi;
            _slideApi = slideApi;
            _brandApi = brandApi;
            _mapper = mapper;
            _cartApi = cartApi;
            _httpContext = httpContext;
            _notyf = notyf;
            _session = _httpContext.HttpContext.Session;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _slideApi.GetDashboardSlide();
            var banners = await _productApi.Banners();
            var topBrands = await _brandApi.GetTopBrands();
            await this.AsyncCart();
            var model = new HomeViewModel()
            {
                Sliders = _mapper.Map<List<SliderDto>, List<SlideViewModel>>(sliders.Data),
                BannerProducts = _mapper.Map<List<ProductDto>, List<ProductViewModel>>(banners.Data),
                ActiveTab = Tab.BestSellers,
                Brands = _mapper.Map<List<BrandDto>, List<BrandViewModel>>(topBrands.Data)
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult SwitchToTabs(string tabname)
        {
            if (string.IsNullOrEmpty(tabname))
            {
                tabname = Tab.BestSellers.ToString();
            }
            return ViewComponent("TabProduct", tabname);
        }


        private async Task AsyncCart()
        {
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            if (userId != null)
            {
                var cart = _session.GetObject<List<CartViewModel>>(SystemConstants.CartSession);
                if (cart != null && cart.Count > 0)
                {
                    var cartItems = new List<AddCartItemDto>();
                    foreach (var item in cart ?? Enumerable.Empty<CartViewModel>())
                    {
                        cartItems.Add(new AddCartItemDto()
                        {
                            SizeId = item.SizeId,
                            Quantity = item.Quantity,
                            ProductId = item.ProductId
                        });
                    }

                    var response = await _cartApi.SyncCart(Guid.Parse(userId), cartItems);
                    if (response == null || !response.Success)
                    {
                        _notyf.Error(NotificationConstants.AsyncCartFailed);
                    }
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
