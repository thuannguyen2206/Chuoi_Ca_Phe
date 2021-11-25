using DataAccess.Enums;
using DataTransferObjects.DTOs.Options;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface IOptionService
    {
        /// <summary>
        /// Get list option, if admin role is false then get list option have attribute isActive = true; ortherwise get all option
        /// </summary>
        /// <param name="adminRole"></param>
        /// <returns></returns>
        ApiResult<List<OptionDto>> GetOptions(bool adminRole = false);

        /// <summary>
        /// Get options by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        ApiResult<List<OptionDto>> GetProductOption(int productId);

        ApiResult<OptionDto> GetById(int id);

        ApiResult<int> Create(OptionDto dto);

        ApiResult<int> Update(int optionId, OptionDto dto);

        ApiResult<bool> Delete(int id);

        /// <summary>
        /// Get option (size) default of product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        ApiResult<OptionDto> GetProductDefaultOption(int productId, ProductOptionGroup group);

        ApiResult<List<RelatedColorDto>> GetProductRelatedColor(int productId);
    }
}
