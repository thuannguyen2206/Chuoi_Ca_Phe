using DataAccess.Enums;
using DataTransferObjects.DTOs.Options;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IOptionApiClient
    {
        Task<ApiResult<List<OptionDto>>> GetOptions(bool adminRole = false);

        Task<ApiResult<List<OptionDto>>> GetOptionByProductId(int productId);

        Task<ApiResult<OptionDto>> GetById(int id);

        Task<ApiResult<int>> Create(OptionDto dto);

        Task<ApiResult<int>> Update(int id, OptionDto dto);

        Task<bool> Delete(int id);

        Task<ApiResult<OptionDto>> GetDefaultOptionOfProduct(int productId, ProductOptionGroup group = ProductOptionGroup.Size);

        /// <summary>
        /// Get list color related of product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<ApiResult<List<RelatedColorDto>>> GetRelatedColor(int productId);
    }
}
