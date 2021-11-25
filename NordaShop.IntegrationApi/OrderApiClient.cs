using DataAccess.Enums;
using DataTransferObjects.DTOs.Orders;
using DataTransferObjects.DTOs.Utilities;
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
    public class OrderApiClient : BaseApiClient, IOrderApiClient
    {
        public OrderApiClient(IConfiguration config, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext)
            : base(config, clientFactory, httpContext)
        {

        }

        public async Task<ApiResult<Guid>> Checkout(Guid userId, NewOrderDto dto)
        {
            return await PostAsync<ApiResult<Guid>>($"/api/orders/users/{userId}/checkout", dto);
        }

        public async Task<ApiResult<DetailDto>> GetById(int id)
        {
            return await GetAsync<ApiResult<DetailDto>>($"/api/orders/{id}");
        }

        public async Task<ApiResult<int>> GetDiscountPercent(string code)
        {
            return await GetAsync<ApiResult<int>>($"/api/orders/coupon/{code}/get-discount-percent");
        }

        public async Task<PageResult<List<OrderDto>>> GetAdminPaging(OrderAdminPagingDto paging)
        {
            string url = $"/api/orders/list?pageindex={paging.PageIndex}&pagesize={paging.PageSize}&orderstatus={paging.OrderStatus}";
            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                url += $"&keyword={paging.Keyword}";
            }
            if (DateTime.MinValue != paging.FromDate && paging.FromDate != null && paging.ToDate != null && paging.FromDate <= paging.ToDate)
            {
                url += $"&fromdate={paging.FromDate}&todate={paging.ToDate}";
            }
            return await GetAsync<PageResult<List<OrderDto>>>(url);
        }

        public async Task<ApiResult<List<OrderDetailDto>>> GetOrderItemById(int id)
        {
            return await GetAsync<ApiResult<List<OrderDetailDto>>>($"/api/orders/{id}/list-items");
        }

        public async Task<ApiResult<List<UserOrderDto>>> GetUserOrders(Guid userId)
        {
            return await GetAsync<ApiResult<List<UserOrderDto>>>($"/api/orders/users/{userId}");
        }

        public async Task<decimal> TotalIncome()
        {
            var response = await GetAsync<ApiResult<decimal>>($"/api/orders/total-income");
            if (response != null && response.Success)
                return response.Data;
            return 0;
        }

        public async Task<int> TotalOrders()
        {
            var response = await GetAsync<ApiResult<int>>($"/api/orders/total-orders");
            if (response != null && response.Success)
                return response.Data;
            return 0;
        }

        public async Task<decimal> MonthlyIncome()
        {
            var response = await GetAsync<ApiResult<decimal>>($"/api/orders/monthly-income");
            if (response != null && response.Success)
                return response.Data;
            return 0;
        }

        public async Task<bool> ChangeOrderStatus(int orderId, OrderStatus status)
        {
            var response = await PutAsync<ApiResult<bool>>($"/api/orders/{orderId}/change-status", status);
            if (response != null && response.Success)
            {
                return true;
            }
            return false;
        }

        public async Task<ApiResult<DetailDto>> GetByCode(Guid orderCode)
        {
            return await GetAsync<ApiResult<DetailDto>>($"/api/orders/{orderCode}/tracking");
        }

        public async Task<byte[]> GetOrderDownloadTemplate(int orderId)
        {
            var response = await GetAsync<ApiResult<byte[]>>($"/api/orders/{orderId}/download");
            if (response != null && response.Success)
            {
                return response.Data;
            }
            return new byte[0];
        }
    }
}
