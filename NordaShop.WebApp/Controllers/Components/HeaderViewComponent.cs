using AutoMapper;
using Common.Constants;
using Common.Helper;
using DataTransferObjects.DTOs.Categories;
using DataTransferObjects.DTOs.Menus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Models.Cart;
using NordaShop.WebApp.Models.Category;
using NordaShop.WebApp.Models.Menu;
using NordaShop.WebApp.Models.User;
using NordaShop.WebApp.Models.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICartApiClient _cartApi;
        private readonly IUserApiClient _userApi;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICategoryApiClient _categoryApi;
        private readonly IMapper _mapper;
        private readonly IMenuApiClient _menuApi;
        private readonly ISession _session;

        public HeaderViewComponent(ICartApiClient cartApi, 
            IHttpContextAccessor httpContext, 
            IUserApiClient userApi, 
            ICategoryApiClient categoryApi, 
            IMapper mapper, 
            IMenuApiClient menuApi)
        {
            _cartApi = cartApi;
            _httpContext = httpContext;
            _userApi = userApi;
            _categoryApi = categoryApi;
            _mapper = mapper;
            _menuApi = menuApi;
            _session = _httpContext.HttpContext.Session;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            int cartItems;
            int wishlistItems;
            if (string.IsNullOrEmpty(userId))
            {
                var cart = _session.GetObject<List<CartViewModel>>(SystemConstants.CartSession);
                var wishlist = _session.GetObject<List<WishListViewModel>>(SystemConstants.WishlistSession);
                cartItems = cart != null ? cart.Count : 0;
                wishlistItems = wishlist != null ? wishlist.Count : 0;
            }
            else
            {
                var cartItemCount = await _cartApi.TotalProducts(Guid.Parse(userId));
                var wishListCount = await _userApi.GetWishListCount(Guid.Parse(userId));
                cartItems = cartItemCount.Success ? cartItemCount.Data : 0;
                wishlistItems = wishListCount.Success ? wishListCount.Data : 0;
            }

            var categories = await _categoryApi.GetAll();
            var menus = await _menuApi.GetAll();
            var model = new HeaderViewModel
            {
                CartItemCount = cartItems,
                WishListCount = wishlistItems,
                Categories = categories.Success ? _mapper.Map<List<CategoryDto>, List<CategoryViewModel>>(categories.Data) : null,
                Menus = menus.Success ? _mapper.Map<List<MenuDto>, List<MenuViewModel>>(menus.Data) : null
            };
            return View("Default", model);
        }
    }
}
