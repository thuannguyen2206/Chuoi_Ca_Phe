using DataTransferObjects.DTOs.Tags;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface ITagService
    {
        ApiResult<List<TagDto>> GetTopProductTags();

        ApiResult<List<TagDto>> GetTopPostTags();

        ApiResult<int> Create(TagDto dto);

        ApiResult<int> Update(int id, TagDto dto);

        ApiResult<TagDto> GetById(int id);

        ApiResult<List<TagDto>> GetTagOfProduct(int productId);

        ApiResult<List<TagDto>> GetTagOfPost(int postId);

        ApiResult<List<TagDto>> GetAll(bool adminRole = false);
    }
}
