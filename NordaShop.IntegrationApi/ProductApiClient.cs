using Common.Constants;
using DataTransferObjects.DTOs.Products;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _config;

        public ProductApiClient(IConfiguration config, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext)
            : base(config, clientFactory, httpContext)
        {
            _httpClient = clientFactory;
            _config = config;
            _httpContext = httpContext;
        }

        public async Task<ApiResult<List<ProductDto>>> GetAll()
        {
            return await GetAsync<ApiResult<List<ProductDto>>>("/api/products/all");
        }

        public async Task<ApiResult<ProductDto>> GetById(int id, bool isAdmin = false)
        {
            string url = $"/api/products/{id}";
            if (isAdmin)
            {
                url += $"/adminrole={isAdmin}";
            }
            return await GetAsync<ApiResult<ProductDto>>(url);
        }

        public async Task<ApiResult<List<ProductDto>>> Banners()
        {
            return await GetAsync<ApiResult<List<ProductDto>>>("/api/products/banner");
        }

        public async Task<ApiResult<List<ProductDto>>> GetTabProducts(string tabname)
        {
            return await GetAsync<ApiResult<List<ProductDto>>>($"/api/products/tabname={tabname}");
        }

        public async Task<PageResult<List<ProductDto>>> GetPagings(SitePagingDto paging)
        {
            string url = $"/api/products/list?pageIndex={paging.PageIndex}&pageSize={paging.PageSize}&sortProduct={paging.SortProduct}";

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                url += $"&keyword={paging.Keyword}";
            }

            if (paging.CategoryId.HasValue && paging.CategoryId > 0)
            {
                url += $"&categoryId={paging.CategoryId}";
            }

            if (paging.TagId.HasValue && paging.TagId > 0)
            {
                url += $"&tagId={paging.TagId}";
            }

            if (paging.FromPrice <= paging.ToPrice && paging.ToPrice > 0)
            {
                url += $"&fromPrice={paging.FromPrice}&toPrice={paging.ToPrice}";
            }

            if (paging.Options != null && paging.Options.Length > 0)
            {
                foreach (var option in paging.Options)
                {
                    url += $"&option={option}";
                }
            }
            if (paging.Brands != null && paging.Brands.Length > 0)
            {
                foreach (var brand in paging.Brands)
                {
                    url += $"&brand={brand}";
                }
            }
            return await GetAsync<PageResult<List<ProductDto>>>(url);
        }

        public async Task<ApiResult<List<ProductDto>>> GetRelated(int productId)
        {
            return await GetAsync<ApiResult<List<ProductDto>>>($"/api/products/{productId}/related");
        }

        public async Task<int> GetMaxPrice()
        {
            var response = await GetAsync<ApiResult<decimal>>($"/api/products/max-price");
            if (response != null && response.Success)
            {
                return response.Data > 0 ? (int)Math.Ceiling(response.Data) : SystemConstants.DefaultMaxPrice;
            }
            return SystemConstants.DefaultMaxPrice;
        }

        public async Task<ApiResult<List<ProductAutocompleteSearchDto>>> Search(string keyword)
        {
            return await GetAsync<ApiResult<List<ProductAutocompleteSearchDto>>>($"/api/products/keyword={keyword}");
        }

        public async Task<PageResult<List<ProductDto>>> GetAdminPagings(ProductAdminPagingDto paging)
        {
            string url = $"/api/products/admin-role/list?pageindex={paging.PageIndex}&pagesize={paging.PageSize}";//&sortProduct={paging.SortProduct}";

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                url += $"&keyword={paging.Keyword}";
            }

            if (paging.CategoryId.HasValue)
            {
                url += $"&categoryid={paging.CategoryId}";
            }

            if (paging.BrandId.HasValue)
            {
                url += $"&brandid={paging.BrandId}";
            }
            return await GetAsync<PageResult<List<ProductDto>>>(url);
        }

        public async Task<bool> Delete(int id)
        {
            return await DeleteAsync($"/api/products/{id}");
        }

        public async Task<bool> Create(ProductCreateDto dto)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token ?? string.Empty);

            var reqquestContent = new MultipartFormDataContent();
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var fileInfo in dto.Files)
                {
                    byte[] data;
                    using (var br = new BinaryReader(fileInfo.OpenReadStream()))
                    {
                        data = br.ReadBytes((int)fileInfo.OpenReadStream().Length);
                    }
                    ByteArrayContent fileContent = new ByteArrayContent(data);
                    reqquestContent.Add(fileContent, "files", fileInfo.FileName);
                }
            }

            if (dto.Options != null && dto.Options.Length > 0)
            {
                foreach (var item in dto.Options)
                {
                    reqquestContent.Add(new StringContent(item.ToString()), "options");
                }
            }

            if (dto.Tags != null && dto.Tags.Length > 0)
            {
                foreach (var item in dto.Tags)
                {
                    reqquestContent.Add(new StringContent(item.ToString()), "tags");
                }
            }

            reqquestContent.Add(new StringContent(dto.Name.ToString()), "name");
            reqquestContent.Add(new StringContent(dto.Price.ToString()), "price");
            reqquestContent.Add(new StringContent(dto.OriginalPrice.ToString()), "originalPrice");
            reqquestContent.Add(new StringContent(dto.DiscountPrice.ToString()), "discountPrice");
            reqquestContent.Add(new StringContent(dto.Stock.ToString()), "stock");
            reqquestContent.Add(new StringContent(dto.IsActive.ToString()), "isActive");
            reqquestContent.Add(new StringContent(dto.BrandId.ToString()), "brandId");
            reqquestContent.Add(new StringContent(dto.ColorId.ToString()), "colorId");
            reqquestContent.Add(new StringContent(dto.CategoryId.ToString()), "categoryId");
            reqquestContent.Add(new StringContent(dto.OnTopHot.ToString()), "onTopHot");
            reqquestContent.Add(new StringContent(dto.OnBanner.ToString()), "onBanner");

            if (dto.CodeProduct != null)
                reqquestContent.Add(new StringContent(dto.CodeProduct.ToString()), "codeProduct");
            if (dto.Description != null)
                reqquestContent.Add(new StringContent(dto.Description.ToString()), "description");
            if (dto.Title != null)
                reqquestContent.Add(new StringContent(dto.Title.ToString()), "title");
            if (dto.SeoAlias != null)
                reqquestContent.Add(new StringContent(dto.SeoAlias.ToString()), "seoAlias");

            var response = await client.PostAsync($"/api/products/create", reqquestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, ProductUpdateDto dto)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token ?? string.Empty);

            var reqquestContent = new MultipartFormDataContent();
            if (dto.Options != null && dto.Options.Length > 0)
            {
                foreach (var item in dto.Options)
                {
                    reqquestContent.Add(new StringContent(item.ToString()), "options");
                }
            }

            if (dto.Tags != null && dto.Tags.Length > 0)
            {
                foreach (var item in dto.Tags)
                {
                    reqquestContent.Add(new StringContent(item.ToString()), "tags");
                }
            }

            reqquestContent.Add(new StringContent(dto.Name.ToString()), "name");
            reqquestContent.Add(new StringContent(dto.Price.ToString()), "price");
            reqquestContent.Add(new StringContent(dto.DiscountPrice.ToString()), "discountPrice");
            reqquestContent.Add(new StringContent(dto.OriginalPrice.ToString()), "originalPrice");
            reqquestContent.Add(new StringContent(dto.IsActive.ToString()), "isActive");
            reqquestContent.Add(new StringContent(dto.BrandId.ToString()), "brandId");
            reqquestContent.Add(new StringContent(dto.ColorId.ToString()), "colorId");
            reqquestContent.Add(new StringContent(dto.CategoryId.ToString()), "categoryId");
            reqquestContent.Add(new StringContent(dto.OnTopHot.ToString()), "onTopHot");
            reqquestContent.Add(new StringContent(dto.OnBanner.ToString()), "onBanner");

            if (dto.CodeProduct != null)
                reqquestContent.Add(new StringContent(dto.CodeProduct.ToString()), "codeProduct");
            if (dto.Description != null)
                reqquestContent.Add(new StringContent(dto.Description.ToString()), "description");
            if (dto.Title != null)
                reqquestContent.Add(new StringContent(dto.Title.ToString()), "title");
            if (dto.SeoAlias != null)
                reqquestContent.Add(new StringContent(dto.SeoAlias.ToString()), "seoAlias");

            var response = await client.PutAsync($"/api/products/{id}/update", reqquestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<ApiResult<List<ProductImageDto>>> LoadProductImages(int productId)
        {
            return await GetAsync<ApiResult<List<ProductImageDto>>>($"/api/products/{productId}/images");
        }

        public async Task<bool> UploadImages(int productId, List<IFormFile> images)
        {
            var token = _httpContext.HttpContext.Session.GetString(SystemConstants.Token);
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_config["BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token ?? string.Empty);

            var reqquestContent = new MultipartFormDataContent();
            if (images != null && images.Count > 0)
            {
                foreach (var fileInfo in images)
                {
                    byte[] data;
                    using (var br = new BinaryReader(fileInfo.OpenReadStream()))
                    {
                        data = br.ReadBytes((int)fileInfo.OpenReadStream().Length);
                    }
                    ByteArrayContent fileContent = new ByteArrayContent(data);
                    reqquestContent.Add(fileContent, "images", fileInfo.FileName);
                }
            }
            var response = await client.PostAsync($"/api/products/{productId}/upload-images", reqquestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAllImages(int productId)
        {
            return await DeleteAsync($"/api/products/{productId}/remove-all-images");
        }

        public async Task<int> ToTalActives()
        {
            var response = await GetAsync<ApiResult<int>>($"/api/products/total-actives");
            if (response != null && response.Success)
                return response.Data;
            return 0;
        }

        public async Task<int> TotalSold()
        {
            var response = await GetAsync<ApiResult<int>>($"/api/products/total-sold");
            if (response != null && response.Success)
                return response.Data;
            return 0;
        }

        public async Task<ApiResult<List<ProductRatingDto>>> GetProductRating(int productId)
        {
            return await GetAsync<ApiResult<List<ProductRatingDto>>>($"/api/products/{productId}/ratings");
        }

        public async Task<ApiResult<int>> CreateNewRating(ProductRatingDto dto)
        {
            return await PostAsync<ApiResult<int>>($"/api/products/create-rating", dto);
        }
    }
}
