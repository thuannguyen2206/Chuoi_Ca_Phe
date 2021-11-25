using DataTransferObjects.DTOs.Carts;
using DataTransferObjects.DTOs.Orders;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface ICartApiClient
    {
        Task<ApiResult<List<CartItemDto>>> GetMiniCart(Guid userId);

        Task<ApiResult<CartDto>> GetCart(Guid userId);

        Task<ApiResult<CartDto>> GetCart(int id);

        Task<ApiResult<int>> TotalProducts(Guid userId);

        Task<ApiResult<int>> AddToCart(AddCartItemDto dto);

        Task<ApiResult<bool>> UpdateQuantity(Guid userId, List<CartItemUpdateDto> dtos);

        Task<bool> ClearCart(Guid userId);

        Task<bool> RemoveCartItem(int itemId);

        Task<ApiResult<bool>> SyncCart(Guid userId, List<AddCartItemDto> cartItems);
    }
}
