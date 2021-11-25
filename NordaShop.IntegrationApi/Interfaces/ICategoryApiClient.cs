using DataTransferObjects.DTOs.Categories;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface ICategoryApiClient
    {
        Task<ApiResult<List<CategoryDto>>> GetAll(bool adminRole = false);

        Task<ApiResult<CategoryDto>> GetById(int id);

        Task<ApiResult<int>> Create(CategoryDto category);

        Task<ApiResult<int>> Update(int id, CategoryDto category);

        Task<bool> Delete(int id);
    }
}
