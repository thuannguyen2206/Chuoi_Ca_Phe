using DataAccess.Enums;
using DataTransferObjects.DTOs.Orders;
using DataTransferObjects.DTOs.Utilities;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IOrderApiClient
    {
        Task<ApiResult<Guid>> Checkout(Guid userId, NewOrderDto dto);

        Task<ApiResult<DetailDto>> GetById(int id);

        Task<ApiResult<DetailDto>> GetByCode(Guid orderCode);

        Task<ApiResult<List<OrderDetailDto>>> GetOrderItemById(int id);

        Task<ApiResult<int>> GetDiscountPercent(string code);

        Task<ApiResult<List<UserOrderDto>>> GetUserOrders(Guid userId);

        Task<PageResult<List<OrderDto>>> GetAdminPaging(OrderAdminPagingDto paging);

        Task<bool> ChangeOrderStatus(int orderId, OrderStatus status);

        Task<decimal> TotalIncome();

        Task<int> TotalOrders();

        Task<decimal> MonthlyIncome();

        Task<byte[]> GetOrderDownloadTemplate(int orderId);

    }
}
