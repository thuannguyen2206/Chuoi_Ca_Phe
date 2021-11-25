using DataTransferObjects.DTOs.Categories;
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
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        public CategoryApiClient(IConfiguration config, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext) 
            : base(config, clientFactory, httpContext)
        {

        }

        public async Task<ApiResult<int>> Create(CategoryDto category)
        {
            return await PostAsync<ApiResult<int>>($"/api/categories/create", category);
        }

        public async Task<bool> Delete(int id)
        {
            return await DeleteAsync($"/api/categories/{id}");
        }

        public async Task<ApiResult<List<CategoryDto>>> GetAll(bool adminRole = false)
        {
            return await GetAsync<ApiResult<List<CategoryDto>>>($"/api/categories/list/adminrole={adminRole}");
        }

        public async Task<ApiResult<CategoryDto>> GetById(int id)
        {
            return await GetAsync<ApiResult<CategoryDto>>($"/api/categories/{id}");
        }

        public async Task<ApiResult<int>> Update(int id, CategoryDto category)
        {
            return await PutAsync<ApiResult<int>>($"/api/categories/{id}/update", category);
        }
    }
}
