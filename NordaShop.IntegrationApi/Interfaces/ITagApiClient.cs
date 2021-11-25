using DataTransferObjects.DTOs.Tags;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface ITagApiClient
    {
        Task<ApiResult<int>> Create(TagDto dto);

        Task<ApiResult<List<TagDto>>> GetAll(bool adminRole = false);

        Task<ApiResult<TagDto>> GetById(int id);

        Task<ApiResult<List<TagDto>>> GetTagOfProduct(int productId);

        Task<ApiResult<List<TagDto>>> GetTagOfPost(int postId);

        Task<ApiResult<List<TagDto>>> GetTopProductTags();

        Task<ApiResult<List<TagDto>>> GetTopPostTags();

        Task<ApiResult<int>> Update(int id, TagDto dto);

    }
}
