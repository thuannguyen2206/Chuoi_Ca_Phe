using DataTransferObjects.DTOs.Tags;
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
    public class TagApiClient : BaseApiClient, ITagApiClient
    {
        public TagApiClient(IConfiguration config, IHttpClientFactory httpClient, IHttpContextAccessor httpContext)
            : base(config, httpClient, httpContext)
        {

        }

        public async Task<ApiResult<int>> Create(TagDto dto)
        {
            return await PostAsync<ApiResult<int>>($"/api/tags/create", dto);
        }

        public async Task<ApiResult<List<TagDto>>> GetAll(bool adminRole = false)
        {
            return await GetAsync<ApiResult<List<TagDto>>>($"/api/tags/list/adminrole={adminRole}");
        }

        public async Task<ApiResult<TagDto>> GetById(int id)
        {
            return await GetAsync<ApiResult<TagDto>>($"/api/tags/{id}");
        }

        public async Task<ApiResult<List<TagDto>>> GetTagOfPost(int postId)
        {
            return await GetAsync<ApiResult<List<TagDto>>>($"/api/tags/tag-of-post/{postId}");
        }

        public async Task<ApiResult<List<TagDto>>> GetTagOfProduct(int productId)
        {
            return await GetAsync<ApiResult<List<TagDto>>>($"/api/tags/tag-of-product/{productId}");
        }

        public async Task<ApiResult<List<TagDto>>> GetTopPostTags()
        {
            return await GetAsync<ApiResult<List<TagDto>>>($"/api/tags/top-post-tags");
        }

        public async Task<ApiResult<List<TagDto>>> GetTopProductTags()
        {
            return await GetAsync<ApiResult<List<TagDto>>>($"/api/tags/top-product-tags");
        }

        public async Task<ApiResult<int>> Update(int id, TagDto dto)
        {
            return await PutAsync<ApiResult<int>>($"/api/tags/{id}/update", dto);
        }
    }
}
