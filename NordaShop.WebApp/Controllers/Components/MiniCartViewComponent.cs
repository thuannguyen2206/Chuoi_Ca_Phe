using AutoMapper;
using Common.Constants;
using Common.Helper;
using DataTransferObjects.DTOs.Carts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers.Components
{
    public class MiniCartViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly ICartApiClient _cartApi;
        private readonly ISession _session;

        public MiniCartViewComponent(IHttpContextAccessor httpContext, IMapper mapper, ICartApiClient cartApi)
        {
            _cartApi = cartApi;
            _httpContext = httpContext;
            _mapper = mapper;
            _session = _httpContext.HttpContext.Session;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            var model = new List<MiniCartItemViewModel>();
            if (string.IsNullOrEmpty(userId))
            {
                var cart = _session.GetObject<List<CartViewModel>>(SystemConstants.CartSession);
                foreach (var item in cart ?? Enumerable.Empty<CartViewModel>())
                {
                    model.Add(new MiniCartItemViewModel()
                    {
                        ImageLink = item.DefaultImage,
                        ProductName = item.Name,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        ProductId = item.ProductId,
                        Id = item.ItemId,
                        SeoAlias = item.SeoAlias
                    });
                }
            }
            else
            {
                var response = await _cartApi.GetMiniCart(Guid.Parse(userId));
                if (response.Success)
                {
                    model = _mapper.Map<List<CartItemDto>, List<MiniCartItemViewModel>>(response.Data);
                }
            }
            return View(model);
        }

    }
}
