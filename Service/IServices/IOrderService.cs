using DataAccess.Enums;
using DataTransferObjects.DTOs.Orders;
using DataTransferObjects.DTOs.Utilities;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IOrderService
    {
        /// <summary>
        /// Cart checkout
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Order code</returns>
        Task<ApiResult<Guid>> Checkout(Guid userId, NewOrderDto model);

        /// <summary>
        /// Get order paging
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        PageResult<List<OrderDto>> GetAllOrderPaging(OrderAdminPagingDto paging);

        /// <summary>
        /// Get list orders of user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="paging"></param>
        /// <returns></returns>
        ApiResult<List<UserOrderDto>> GetUserOrders(Guid userId);

        /// <summary>
        /// Get order detail by order id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        ApiResult<DetailDto> GetOrderById(int orderId);

        /// <summary>
        /// Get order by order code - use for order tracking
        /// </summary>
        /// <param name="orderCode"></param>
        /// <returns></returns>
        ApiResult<DetailDto> GetOrderByCode(Guid orderCode);

        /// <summary>
        /// Get order item by order id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        ApiResult<List<OrderDetailDto>> GetOrderItemByOrderId(int orderId);

        /// <summary>
        /// Check code is valid. If true return discount percent, ortherwise failed
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        ApiResult<int> GetDiscountPercent(string code);

        /// <summary>
        /// Total orders without canceled
        /// </summary>
        /// <returns></returns>
        ApiResult<int> TotalOrders();

        /// <summary>
        /// Get total income with condition paid orders
        /// </summary>
        /// <returns></returns>
        ApiResult<decimal> TotalIncome();

        /// <summary>
        /// Get current monthly income with condition paid orders
        /// </summary>
        /// <returns></returns>
        ApiResult<decimal> MonthlyIncome();

        /// <summary>
        /// Change order status
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        ApiResult<bool> ChangeOrderStatus(int orderId, OrderStatus status);

        /// <summary>
        /// Build order download template
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        string BuildOrderDownloadTemplate(int orderId);

    }
}
