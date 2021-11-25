using DataTransferObjects.DTOs.Contacts;
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
    public class ContactApiClient : BaseApiClient, IContactApiClient
    {
        public ContactApiClient(IConfiguration config, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext)
            : base(config, clientFactory, httpContext)
        {

        }

        public async Task<ApiResult<int>> AddContact(ContactDto dto)
        {
            return await PostAsync<ApiResult<int>>($"/api/contacts/create", dto);
        }

        public async Task<bool> Delete(int id)
        {
            return await DeleteAsync($"/api/contacts/{id}");
        }

        public async Task<ApiResult<ContactDto>> GetById(int id)
        {
            return await GetAsync<ApiResult<ContactDto>>($"/api/contacts/{id}");
        }

        public async Task<PageResult<List<ContactDto>>> GetListContactPaging(PagingDto paging)
        {
            string url = $"/api/contacts/list?pageindex={paging.PageIndex}&pageiize={paging.PageSize}";

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                url += $"&keyword={paging.Keyword}";
            }
            return await GetAsync<PageResult<List<ContactDto>>>(url);
        }


    }
}
