using Common.Constants;
using DataTransferObjects.DTOs.Sliders;
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
    public class SlideApiClient : BaseApiClient, ISlideApiClient
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _config;

        public SlideApiClient(IConfiguration config, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext)
            : base(config, clientFactory, httpContext)
        {
            _httpContext = httpContext;
            _config = config;
            _httpClient = clientFactory;
        }

        public async Task<bool> Create(CESliderDto slider)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token ?? string.Empty);

            var reqquestContent = new MultipartFormDataContent();
            if (slider.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(slider.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)slider.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent fileContent = new ByteArrayContent(data);
                reqquestContent.Add(fileContent, "imageFile", slider.ImageFile.FileName);
            }

            reqquestContent.Add(new StringContent(slider.Name.ToString()), "name");
            reqquestContent.Add(new StringContent(slider.SortOrder.ToString()), "sortOrder");
            reqquestContent.Add(new StringContent(slider.IsActive.ToString()), "isActive");

            if (!string.IsNullOrEmpty(slider.Title))
                reqquestContent.Add(new StringContent(slider.Title.ToString()), "title");
            
            var response = await client.PostAsync($"/api/sliders/create", reqquestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            return await DeleteAsync($"/api/siders/{id}");
        }

        public async Task<ApiResult<List<SliderDto>>> GetDashboardSlide()
        {
            return await GetAsync<ApiResult<List<SliderDto>>>("/api/sliders/on-site");
        }

        public async Task<ApiResult<SliderDto>> GetById(int id)
        {
            return await GetAsync<ApiResult<SliderDto>>($"/api/sliders/{id}");
        }

        public async Task<bool> Update(int id, CESliderDto slider)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token ?? string.Empty);

            var reqquestContent = new MultipartFormDataContent();
            if (slider.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(slider.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)slider.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent fileContent = new ByteArrayContent(data);
                reqquestContent.Add(fileContent, "imageFile", slider.ImageFile.FileName);
            }

            reqquestContent.Add(new StringContent(slider.Name.ToString()), "name");
            reqquestContent.Add(new StringContent(slider.SortOrder.ToString()), "sortOrder");
            reqquestContent.Add(new StringContent(slider.IsActive.ToString()), "isActive");

            if (!string.IsNullOrEmpty(slider.Title))
                reqquestContent.Add(new StringContent(slider.Title.ToString()), "title");

            var response = await client.PutAsync($"/api/sliders/{id}/update", reqquestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<ApiResult<List<SliderDto>>> GetAll()
        {
            return await GetAsync<ApiResult<List<SliderDto>>>("/api/sliders/all");
        }
    }
}
