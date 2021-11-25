using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IRoleApiClient
    {
        /// <summary>
        /// Check if role is admin then return true, else return false
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> CheckAdminRole(Guid userId);


    }
}
