using DataTransferObjects.DTOs.Menus;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IMenuApiClient
    {
        Task<ApiResult<List<MenuDto>>> GetAll(bool adminRole = false);

        Task<ApiResult<int>> Create(MenuDto menu);

        Task<ApiResult<int>> Update(int id, MenuDto menu);

        Task<bool> Delete(int id);

        Task<ApiResult<MenuDto>> GetById(int id);
    }
}
