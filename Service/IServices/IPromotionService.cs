using DataTransferObjects.DTOs.Promotions;
using DataTransferObjects.DTOs.Utilities;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface IPromotionService
    {
        /// <summary>
        /// Create a new promotion to sale
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ApiResult<int> Create(PromotionDto dto);

        /// <summary>
        /// Update a promotion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        ApiResult<int> Update(int id, PromotionDto dto);

        /// <summary>
        /// Get list promotion paging
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        PageResult<List<PromotionDto>> GetPagings(PagingDto paging);

        /// <summary>
        /// Get promotion by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResult<PromotionDto> GetById(int id);

        /// <summary>
        /// Delete promotion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResult<bool> Delete(int id);

        /// <summary>
        /// Get one promotion on show in shop
        /// </summary>
        /// <returns></returns>
        ApiResult<PromotionDto> GetOnShowPromotion();
    }
}
