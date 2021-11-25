using DataTransferObjects.DTOs.Carts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NordaShop.IntegrationApi.Interfaces;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi
{
    public class CartApiClient : BaseApiClient, ICartApiClient
    {
        public CartApiClient(IConfiguration config, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext) 
            : base(config, clientFactory, httpContext)
        {

        }

        public async Task<ApiResult<int>> AddToCart(AddCartItemDto dto)
        {
            return await PostAsync<ApiResult<int>>($"/api/carts/add-to-cart", dto);
        }

        public async Task<ApiResult<bool>> SyncCart(Guid userId, List<AddCartItemDto> cartItems)
        {
            return await PostAsync<ApiResult<bool>>($"/api/carts/{userId}/sync-cart", cartItems);
        }

        public async Task<bool> ClearCart(Guid userId)
        {
            return await DeleteAsync($"/api/carts/userid={userId}/clear");
        }

        public async Task<ApiResult<CartDto>> GetCart(Guid userId)
        {
            return await GetAsync<ApiResult<CartDto>>($"/api/carts/userid={userId}");
        }

        public async Task<ApiResult<CartDto>> GetCart(int id)
        {
            return await GetAsync<ApiResult<CartDto>>($"/api/carts/{id}");
        }

        public async Task<ApiResult<List<CartItemDto>>> GetMiniCart(Guid userId)
        {
            return await GetAsync<ApiResult<List<CartItemDto>>>($"/api/carts/{userId}/mini-cart");
        }

        public async Task<bool> RemoveCartItem(int itemId)
        {
            return await DeleteAsync($"/api/carts/remove-item/{itemId}");
        }

        public async Task<ApiResult<int>> TotalProducts(Guid userId)
        {
            return await GetAsync<ApiResult<int>>($"/api/carts/{userId}/total-products");
        }

        public async Task<ApiResult<bool>> UpdateQuantity(Guid userId, List<CartItemUpdateDto> dtos)
        {
            return await PutAsync<ApiResult<bool>>($"/api/carts/user={userId}/update-quantity", dtos);
        }
    }
}
