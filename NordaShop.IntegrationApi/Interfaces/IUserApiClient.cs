using DataTransferObjects.DTOs.Auths;
using DataTransferObjects.DTOs.Contacts;
using DataTransferObjects.DTOs.Users;
using DataTransferObjects.DTOs.Utilities;
using DataTransferObjects.DTOs.WishLists;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> SignIn(SignInDto request);

        Task<ApiResult<bool>> SignUp(SignUpDto request);

        Task<ApiResult<UserDto>> GetById(Guid id, bool isAdmin = false);

        Task<ApiResult<Guid>> Update(Guid id, UserUpdateDto request);

        Task<bool> Delete(Guid id);

        Task<ApiResult<Guid>> Create(UserCreateDto request);

        Task<ApiResult<int>> GetWishListCount(Guid userId);

        Task<ApiResult<List<WishListDto>>> GetWishList(Guid userId);

        Task<ApiResult<bool>> AddToWishlist(Guid userId, int productId);

        Task<bool> RemoveWishlistItem(Guid userId, int productId);

        Task<ApiResult<bool>> ForgotPassword(string email);

        Task<ApiResult<bool>> ResetPassword(ChangePasswordDto dto);

        Task<PageResult<List<UserDto>>> GetPagings(UserAdminPagingDto paging);

        Task<int> TotalActive();

        Task<ApiResult<UserDashboardDto>> GetDashboard(Guid userId);

        Task<ApiResult<string>> ExternalSignIn(ExternalSignInDto dto);

        Task<bool> CheckExistByEmail(string email);

        Task<ApiResult<UserDto>> GetByEmail(string email);
    }
}
