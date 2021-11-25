using Common.Constants;
using DataTransferObjects.DTOs.Brands;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NordaShop.IntegrationApi.Interfaces;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi
{
    public class BrandApiClient : BaseApiClient, IBrandApiClient
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _config;

        public BrandApiClient(IConfiguration config, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext) 
            : base(config, clientFactory, httpContext)
        {
            _httpContext = httpContext;
            _httpClient = clientFactory;
            _config = config;
        }

        public async Task<bool> Create(BrandDto dto)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token ?? string.Empty);

            var reqquestContent = new MultipartFormDataContent();
            if (dto.BrandFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(dto.BrandFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)dto.BrandFile.OpenReadStream().Length);
                }
                ByteArrayContent fileContent = new ByteArrayContent(data);
                reqquestContent.Add(fileContent, "brandFile", dto.BrandFile.FileName);
            }

            reqquestContent.Add(new StringContent(dto.BrandName.ToString()), "brandName");
            reqquestContent.Add(new StringContent(dto.IsActive.ToString()), "isActive");

            var response = await client.PostAsync($"/api/brands/create", reqquestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            return await DeleteAsync($"/api/brands/{id}");
        }

        public async Task<ApiResult<List<BrandDto>>> GetAll(bool adminRole = false)
        {
            return await GetAsync<ApiResult<List<BrandDto>>>($"/api/brands/list/adminrole={adminRole}");
        }

        public async Task<ApiResult<BrandDto>> GetById(int id)
        {
            return await GetAsync<ApiResult<BrandDto>>($"/api/brands/{id}");
        }

        public async Task<ApiResult<List<BrandDto>>> GetPaging(PagingDto paging)
        {
            string url = $"/api/brands/list-paging?pageIndex={paging.PageIndex}&pageSize={paging.PageSize}";

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                url += $"&keyword={paging.Keyword}";
            }
            return await GetAsync<ApiResult<List<BrandDto>>>(url);
        }

        public async Task<ApiResult<List<BrandDto>>> GetTopBrands()
        {
            return await GetAsync<ApiResult<List<BrandDto>>>($"/api/brands/top-brand");
        }

        public async Task<bool> Update(int id, BrandDto dto)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token ?? string.Empty);

            var reqquestContent = new MultipartFormDataContent();
            if (dto.BrandFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(dto.BrandFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)dto.BrandFile.OpenReadStream().Length);
                }
                ByteArrayContent fileContent = new ByteArrayContent(data);
                reqquestContent.Add(fileContent, "brandFile", dto.BrandFile.FileName);
            }

            reqquestContent.Add(new StringContent(dto.BrandName), "brandName");
            reqquestContent.Add(new StringContent(dto.IsActive.ToString()), "isActive");

            var response = await client.PutAsync($"/api/brands/{id}/update", reqquestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
