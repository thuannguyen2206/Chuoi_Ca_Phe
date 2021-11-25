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
    public class RoleApiClient : BaseApiClient, IRoleApiClient
    {
        public RoleApiClient(IConfiguration config, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext) 
            : base(config, clientFactory, httpContext)
        {

        }

        public async Task<bool> CheckAdminRole(Guid userId)
        {
            var response = await GetAsync<ApiResult<bool>>($"/api/roles/userid={userId}/check-admin-role");
            if (response != null && response.Success)
            {
                return true;
            }
            return false;
        }

    }
}
