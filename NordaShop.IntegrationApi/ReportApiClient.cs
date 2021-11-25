using DataTransferObjects.DTOs.Charts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NordaShop.IntegrationApi.Interfaces;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi
{
    public class ReportApiClient: BaseApiClient, IReportApiClient
    {
        public ReportApiClient(IConfiguration config, 
            IHttpClientFactory clientFactory, 
            IHttpContextAccessor httpContext)
            : base(config, clientFactory, httpContext)
        {
        
        }

        public async Task<ApiResult<List<DateRevenueStatistic>>> RevenueStatistic(string from, string to)
        {
            return await GetAsync<ApiResult<List<DateRevenueStatistic>>>($"/api/reports/revenue-statistic?from={from}&to={to}");
        }

        public async Task<ApiResult<List<TopSellingProduct>>> TopAllSellingProducts()
        {
            return await GetAsync<ApiResult<List<TopSellingProduct>>>($"/api/reports/top-all-selling-product");
        }

        public async Task<ApiResult<List<TopSellingProduct>>> TopMonthSellingProducts(string time)
        {
            return await GetAsync<ApiResult<List<TopSellingProduct>>>($"/api/reports/{time}/top-month-selling-product/");
        }
    }
}
