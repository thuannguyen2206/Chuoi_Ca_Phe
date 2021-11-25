using DataTransferObjects.DTOs.Users;
using DataTransferObjects.DTOs.Utilities;
using DataTransferObjects.DTOs.WishLists;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface IUserService
    {
        /// <summary>
        /// Get user information by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isAdmin"></param>
        /// <returns>User information</returns>
        ApiResult<UserDto> GetById(Guid id, bool isAdmin = false);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        ApiResult<List<UserDto>> GetAll();

        /// <summary>
        /// Get list users with paging
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List user</returns>
        PageResult<List<UserDto>> GetUserPaging(UserAdminPagingDto model);

        /// <summary>
        /// Remove user by email
        /// </summary>
        /// <param name="email"></param>
        void RemoveByEmail(string email);

        /// <summary>
        /// Update user information
        /// </summary>
        /// <param name="model"></param>
        /// <returns>User id if success, ortherwise errorcode</returns>
        ApiResult<Guid> Update(Guid id, UserUpdateDto model);

        /// <summary>
        /// Create user profile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResult<Guid> Create(UserCreateDto model);

        /// <summary>
        /// Delete an user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if successed, ortherwise false</returns>
        ApiResult<bool> Delete(Guid id);

        /// <summary>
        /// Get total wish list product by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ApiResult<int> GetWishListCount(Guid userId);

        /// <summary>
        /// Get favorite products of user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ApiResult<List<WishListDto>> GetWishList(Guid userId);

        /// <summary>
        /// Add product to user wish list
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        ApiResult<bool> AddToWishList(Guid userId, int productId);

        ApiResult<bool> RemoveWishlistItem(Guid userId, int productId);

        /// <summary>
        /// Total product are active
        /// </summary>
        /// <returns></returns>
        ApiResult<int> TotalActives();

        /// <summary>
        /// Get some infomation of customer dashboard
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ApiResult<UserDashboardDto> GetCustomerDashboard(Guid userId);

        ApiResult<bool> CheckExistByEmail(string email);

        ApiResult<UserDto> GetByEmail(string email);
    }
}
