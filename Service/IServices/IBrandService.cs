using DataTransferObjects.DTOs.Brands;
using DataTransferObjects.DTOs.Utilities;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface IBrandService
    {
        /// <summary>
        /// If is not admin role, get brands have isactive = true; otherwise get all brands
        /// </summary>
        /// <param name="adminRole"></param>
        /// <returns></returns>
        ApiResult<List<BrandDto>> GetAll(bool adminRole = false);

        /// <summary>
        /// Get top brand
        /// </summary>
        /// <returns></returns>
        ApiResult<List<BrandDto>> GetTopBrands();

        ApiResult<List<BrandDto>> GetPaging(PagingDto paging);

        ApiResult<BrandDto> GetById(int id);

        ApiResult<int> Create(BrandDto model);

        ApiResult<int> Update(int id, BrandDto model);

        ApiResult<bool> Delete(int id);
    }
}
