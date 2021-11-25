using DataTransferObjects.DTOs.Brands;
using DataTransferObjects.DTOs.Utilities;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IBrandApiClient
    {
        Task<ApiResult<List<BrandDto>>> GetAll(bool adminRole = false);

        Task<ApiResult<List<BrandDto>>> GetTopBrands();

        Task<ApiResult<List<BrandDto>>> GetPaging(PagingDto paging);

        Task<bool> Create(BrandDto dto);

        Task<ApiResult<BrandDto>> GetById(int id);

        Task<bool> Update(int id, BrandDto dto);

        Task<bool> Delete(int id);
    }
}
