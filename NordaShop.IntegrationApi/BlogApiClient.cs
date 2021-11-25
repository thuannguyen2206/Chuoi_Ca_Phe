using Common.Constants;
using DataTransferObjects.DTOs.Posts;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
    public class BlogApiClient : BaseApiClient, IBlogApiClient
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _config;

        public BlogApiClient(IConfiguration config, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext)
            : base(config, clientFactory, httpContext)
        {
            _httpClient = clientFactory;
            _config = config;
            _httpContext = httpContext;
        }

        public async Task<ApiResult<int>> AddPostComment(int postId, PostCommentDto dto)
        {
            return await PostAsync<ApiResult<int>>($"/api/blogs/{postId}/add-comment", dto);
        }

        public async Task<bool> Create(CEPostDto dto)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token ?? string.Empty);

            var reqquestContent = new MultipartFormDataContent();
            if (dto.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(dto.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)dto.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent fileContent = new ByteArrayContent(data);
                reqquestContent.Add(fileContent, "imageFile", dto.ImageFile.FileName);
            }

            if (dto.Tags != null && dto.Tags.Length > 0)
            {
                foreach (var item in dto.Tags)
                {
                    reqquestContent.Add(new StringContent(item.ToString()), "tags");
                }
            }

            reqquestContent.Add(new StringContent(dto.ReviewContent.ToString()), "reviewContent");
            reqquestContent.Add(new StringContent(dto.IsActive.ToString()), "isActive");

            if (dto.Title != null)
                reqquestContent.Add(new StringContent(dto.Title.ToString()), "title");
            if (dto.SeoAlias != null)
                reqquestContent.Add(new StringContent(dto.SeoAlias.ToString()), "seoAlias");

            var response = await client.PostAsync($"/api/blogs/create", reqquestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            return await DeleteAsync($"/api/blogs/{id}");
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            return await DeleteAsync($"/api/blogs/delete-comment/{commentId}");
        }

        public async Task<PageResult<List<PostDto>>> GetAdminPosts(BlogPagingDto paging)
        {
            string url = $"/api/blogs/list-admin?pageindex={paging.PageIndex}&pagesize={paging.PageSize}";

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                url += $"&keyword={paging.Keyword}";
            }
            return await GetAsync<PageResult<List<PostDto>>>(url);
        }

        public async Task<ApiResult<PostDto>> GetById(int id, bool adminRole = false)
        {
            return await GetAsync<ApiResult<PostDto>>($"/api/blogs/{id}/adminRole={adminRole}");
        }

        public async Task<ApiResult<List<PostDto>>> GetLastestPost()
        {
            return await GetAsync<ApiResult<List<PostDto>>>($"/api/blogs/list-lastest-post");
        }

        public async Task<ApiResult<List<PostCommentDto>>> GetLastestPostComment(int postId)
        {
            return await GetAsync<ApiResult<List<PostCommentDto>>>($"/api/blogs/{postId}/list-lastest-comments");
        }

        public async Task<PageResult<List<PostCommentDto>>> GetPostComment(int postId, BlogPagingDto paging)
        {
            string url = $"/api/blogs/{postId}/list-comment?pageindex={paging.PageIndex}&pagesize={paging.PageSize}";

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                url += $"&keyword={paging.Keyword}";
            }
            return await GetAsync<PageResult<List<PostCommentDto>>>(url);
        }

        public async Task<PageResult<List<PostDto>>> GetPosts(BlogPagingDto paging)
        {
            string url = $"/api/blogs/list-in-site?pageindex={paging.PageIndex}&pagesize={paging.PageSize}";

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                url += $"&keyword={paging.Keyword}";
            }

            if (paging.TagId.HasValue && paging.TagId > 0)
            {
                url += $"&tagid={paging.TagId}";
            }

            return await GetAsync<PageResult<List<PostDto>>>(url);
        }

        public async Task<ApiResult<List<PostDto>>> GetRelatedPost(int postId)
        {
            return await GetAsync<ApiResult<List<PostDto>>>($"/api/blogs/{postId}/related");
        }

        public async Task<bool> Update(int id, CEPostDto dto)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token ?? string.Empty);

            var reqquestContent = new MultipartFormDataContent();
            if (dto.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(dto.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)dto.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent fileContent = new ByteArrayContent(data);
                reqquestContent.Add(fileContent, "imageFile", dto.ImageFile.FileName);
            }

            if (dto.Tags != null && dto.Tags.Length > 0)
            {
                foreach (var item in dto.Tags)
                {
                    reqquestContent.Add(new StringContent(item.ToString()), "tags");
                }
            }

            reqquestContent.Add(new StringContent(dto.ReviewContent.ToString()), "reviewContent");
            reqquestContent.Add(new StringContent(dto.IsActive.ToString()), "isActive");

            if (dto.Title != null)
                reqquestContent.Add(new StringContent(dto.Title.ToString()), "title");
            if (dto.SeoAlias != null)
                reqquestContent.Add(new StringContent(dto.SeoAlias.ToString()), "seoAlias");

            var response = await client.PutAsync($"/api/blogs/{id}/update", reqquestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<string> UploadFileCkEditor(IFormFile file)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token ?? string.Empty);

            var reqquestContent = new MultipartFormDataContent();
            if (file != null)
            {
                byte[] data;
                using (var br = new BinaryReader(file.OpenReadStream()))
                {
                    data = br.ReadBytes((int)file.OpenReadStream().Length);
                }
                ByteArrayContent fileContent = new ByteArrayContent(data);
                reqquestContent.Add(fileContent, "imageFile", file.FileName);
            }

            var response = await client.PostAsync($"/api/blogs/file-upload-ckeditor", reqquestContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var deserializeObject = JsonConvert.DeserializeObject<ApiResult<string>>(body);
                return deserializeObject != null && deserializeObject.Success ? deserializeObject.Data : string.Empty;
            }
            return string.Empty;
        }


    }
}
