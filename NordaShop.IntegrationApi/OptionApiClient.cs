using DataAccess.Enums;
using DataTransferObjects.DTOs.Options;
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
    public class OptionApiClient : BaseApiClient, IOptionApiClient
    {
        public OptionApiClient(IConfiguration config, IHttpClientFactory httpClient, IHttpContextAccessor httpContext)
            :base(config, httpClient, httpContext)
        {

        }

        public async Task<ApiResult<int>> Create(OptionDto dto)
        {
            return await PostAsync<ApiResult<int>>($"/api/options/create", dto);
        }

        public async Task<bool> Delete(int id)
        {
            return await DeleteAsync($"/api/options/{id}");
        }

        public async Task<ApiResult<OptionDto>> GetById(int id)
        {
            return await GetAsync<ApiResult<OptionDto>>($"/api/options/{id}");
        }

        public async Task<ApiResult<OptionDto>> GetDefaultOptionOfProduct(int productId, ProductOptionGroup group = ProductOptionGroup.Size)
        {
            return await GetAsync<ApiResult<OptionDto>>($"/api/options/product-option-default/{productId}/group={group}");
        }

        public async Task<ApiResult<List<OptionDto>>> GetOptionByProductId(int productId)
        {
            return await GetAsync<ApiResult<List<OptionDto>>>($"/api/options/productid={productId}");
        }

        public async Task<ApiResult<List<OptionDto>>> GetOptions(bool adminRole = false)
        {
            return await GetAsync<ApiResult<List<OptionDto>>>($"/api/options/list/adminrole={adminRole}");
        }

        public async Task<ApiResult<List<RelatedColorDto>>> GetRelatedColor(int productId)
        {
            return await GetAsync<ApiResult<List<RelatedColorDto>>>($"/api/options/product-colors/{productId}");
        }

        public async Task<ApiResult<int>> Update(int id, OptionDto dto)
        {
            return await PutAsync<ApiResult<int>>($"/api/options/{id}/update", dto);
        }
    }
}
