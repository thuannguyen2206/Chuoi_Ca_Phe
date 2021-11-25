using DataTransferObjects.DTOs.Carts;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface ICartService
    {
        /// <summary>
        /// Sync shopping cart between logged in and not logged in status
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        ApiResult<bool> SyncCart(Guid userId, List<AddCartItemDto> dto);

        /// <summary>
        /// Get cart by cart id
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        ApiResult<CartDto> GetCart(int cartId);

        /// <summary>
        /// Get cart of user by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ApiResult<CartDto> GetCart(Guid userId);

        /// <summary>
        /// Get mini cart of user by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ApiResult<List<CartItemDto>> GetMiniCart(Guid userId);

        /// <summary>
        /// Add product to cart, if product is exist, return truue but not update quantity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResult<int> AddToCart(AddCartItemDto dto);

        /// <summary>
        /// Remove product out of cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        ApiResult<int> RemoveProduct(int itemId);

        /// <summary>
        /// Delete cart by id
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        ApiResult<bool> Delete(int cartId);

        /// <summary>
        /// Remove all product in cart
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ApiResult<int> ClearCart(Guid userId);

        /// <summary>
        /// Update  quantity of product in cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResult<bool> UpdateQuantity(Guid userId, List<CartItemUpdateDto> dto);

        /// <summary>
        /// Get total products in cart by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ApiResult<int> TotalProductInCart(Guid userId);

    }
}
