using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Common.Constants;
using System.IO;

namespace NordaShop.IntegrationApi
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContext;

        public BaseApiClient(IConfiguration config, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext)
        {
            _clientFactory = clientFactory;
            _config = config;
            _httpContext = httpContext;
        }

        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var deserializeObject = JsonConvert.DeserializeObject<TResponse>(body);
                return deserializeObject;
            }
            return JsonConvert.DeserializeObject<TResponse>(body ?? string.Empty);
        }

        protected async Task<TResponse> PostAsync<TResponse>(string url, object obj)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var data = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
            
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token ?? string.Empty);

            var response = await client.PostAsync(url, httpContent);
            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var deserializeObject = JsonConvert.DeserializeObject<TResponse>(body);
                return deserializeObject;
            }
            return JsonConvert.DeserializeObject<TResponse>(body ?? string.Empty);
        }

        protected async Task<TResponse> PutAsync<TResponse>(string url, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PutAsync(url, httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var deserializeObject = JsonConvert.DeserializeObject<TResponse>(body);
                return deserializeObject;
            }
            return JsonConvert.DeserializeObject<TResponse>(body ?? string.Empty);
        }

        protected async Task<bool> DeleteAsync(string url)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}
