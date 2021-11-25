using DataTransferObjects.DTOs.Promotions;
using DataTransferObjects.DTOs.Utilities;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IPromotionApiClient
    {
        Task<ApiResult<int>> Create(PromotionDto dto);

        Task<ApiResult<PromotionDto>> GetById(int id);

        Task<ApiResult<int>> Update(int id, PromotionDto dto);

        Task<PageResult<List<PromotionDto>>> GetPagings(PagingDto paging);

        Task<bool> Delete(int id);

        Task<ApiResult<PromotionDto>> GetOnShow();
    }
}
