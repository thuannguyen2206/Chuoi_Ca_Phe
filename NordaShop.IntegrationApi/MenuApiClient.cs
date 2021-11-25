using DataTransferObjects.DTOs.Menus;
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
    public class MenuApiClient : BaseApiClient, IMenuApiClient
    {
        public MenuApiClient(IConfiguration config, IHttpClientFactory httpClient, IHttpContextAccessor httpContext)
            :base(config, httpClient, httpContext)
        {

        }

        public async Task<ApiResult<int>> Create(MenuDto menu)
        {
            return await PostAsync<ApiResult<int>>($"/api/menus/create", menu);
        }

        public async Task<bool> Delete(int id)
        {
            return await DeleteAsync($"/api/menus/{id}");
        }

        public async Task<ApiResult<List<MenuDto>>> GetAll(bool adminRole = false)
        {
            return await GetAsync<ApiResult<List<MenuDto>>>($"/api/menus/list/adminrole={adminRole}");
        }

        public async Task<ApiResult<MenuDto>> GetById(int id)
        {
            return await GetAsync<ApiResult<MenuDto>>($"/api/menus/{id}");
        }

        public async Task<ApiResult<int>> Update(int id, MenuDto dto)
        {
            return await PutAsync<ApiResult<int>>($"/api/menus/{id}/update", dto);
        }
    }
}
