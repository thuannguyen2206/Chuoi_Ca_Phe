using DataTransferObjects.DTOs.Posts;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Http;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IBlogApiClient
    {
        Task<PageResult<List<PostDto>>> GetPosts(BlogPagingDto paging);

        Task<PageResult<List<PostDto>>> GetAdminPosts(BlogPagingDto paging);

        Task<ApiResult<PostDto>> GetById(int id, bool adminRole = false);

        Task<ApiResult<List<PostDto>>> GetRelatedPost(int postId);

        Task<ApiResult<List<PostDto>>> GetLastestPost();

        Task<bool> Create(CEPostDto dto);

        Task<bool> Update(int id, CEPostDto dto);

        Task<bool> Delete(int id);

        Task<bool> DeleteComment(int commentId);

        Task<PageResult<List<PostCommentDto>>> GetPostComment(int postId, BlogPagingDto paging);

        Task<ApiResult<List<PostCommentDto>>> GetLastestPostComment(int postId);

        Task<ApiResult<int>> AddPostComment(int postId, PostCommentDto dto);

        Task<string> UploadFileCkEditor(IFormFile file);

    }
}
