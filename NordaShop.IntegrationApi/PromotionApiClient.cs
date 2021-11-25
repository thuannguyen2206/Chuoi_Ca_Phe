using DataTransferObjects.DTOs.Promotions;
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
    public class PromotionApiClient : BaseApiClient, IPromotionApiClient
    {
        public PromotionApiClient(IConfiguration config, IHttpClientFactory httpClient, IHttpContextAccessor httpContext)
            :base(config, httpClient, httpContext)
        {

        }

        public async Task<ApiResult<int>> Update(int id, PromotionDto dto)
        {
            return await PutAsync<ApiResult<int>>($"/api/promotions/{id}/update", dto);
        }

        public async Task<ApiResult<int>> Create(PromotionDto dto)
        {
            return await PostAsync<ApiResult<int>>($"/api/promotions/create", dto);
        }

        public async Task<PageResult<List<PromotionDto>>> GetPagings(PagingDto paging)
        {
            string url = $"/api/promotions/list?pageindex={paging.PageIndex}&pagesize={paging.PageSize}";
            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                url += $"&keyword={paging.Keyword}";
            }

            return await GetAsync<PageResult<List<PromotionDto>>>(url);
        }

        public async Task<ApiResult<PromotionDto>> GetById(int id)
        {
            return await GetAsync<ApiResult<PromotionDto>>($"/api/promotions/{id}");
        }

        public async Task<bool> Delete(int id)
        {
            return await DeleteAsync($"/api/promotions/{id}");
        }

        public async Task<ApiResult<PromotionDto>> GetOnShow()
        {
            return await GetAsync<ApiResult<PromotionDto>>($"/api/promotions/on-show");
        }
    }
}
