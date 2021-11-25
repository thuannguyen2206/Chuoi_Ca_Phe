using DataTransferObjects.DTOs.Posts;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Http;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface IBlogService
    {
        /// <summary>
        /// Get list post paging
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="adminRole"></param>
        /// <returns></returns>
        PageResult<List<PostDto>> GetPagings(BlogPagingDto paging, bool adminRole = false);

        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResult<PostDto> GetById(int id, bool adminRole = false);

        /// <summary>
        /// Create new post
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ApiResult<int> Create(CEPostDto dto);

        /// <summary>
        /// Update a post
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        ApiResult<int> Update(int id, CEPostDto dto);

        /// <summary>
        /// Create comment for post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        ApiResult<int> AddPostComment(int postId, PostCommentDto dto);

        /// <summary>
        /// Get post's comment
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        PageResult<List<PostCommentDto>> GetPostComment(int postId, BlogPagingDto paging);

        /// <summary>
        /// Get top lastest post comment
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        ApiResult<List<PostCommentDto>> GetLastestPostComment(int postId);

        /// <summary>
        /// Get related of current post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        ApiResult<List<PostDto>> GetRelatedPost(int postId);

        /// <summary>
        /// Get top lastest post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        ApiResult<List<PostDto>> GetLastestPost();

        /// <summary>
        /// Delete post by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResult<bool> Delete(int id);

        /// <summary>
        /// Delete a comment of post
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        ApiResult<bool> DeleteComment(int commentId);

        /// <summary>
        /// Upload with ckeditor
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        ApiResult<string> FileUploadCkEditor(IFormFile file);



    }
}
