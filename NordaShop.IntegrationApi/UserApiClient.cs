using DataTransferObjects.DTOs.Auths;
using DataTransferObjects.DTOs.Contacts;
using DataTransferObjects.DTOs.Users;
using DataTransferObjects.DTOs.Utilities;
using DataTransferObjects.DTOs.WishLists;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NordaShop.IntegrationApi.Interfaces;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi
{
    public class UserApiClient : BaseApiClient, IUserApiClient
    {

        public UserApiClient(IConfiguration config, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext) 
            : base(config, clientFactory, httpContext)
        {

        }

        public async Task<ApiResult<string>> SignIn(SignInDto request)
        {
            return await PostAsync<ApiResult<string>>("/api/auth/signin", request);
        }

        public async Task<ApiResult<Guid>> Create(UserCreateDto request)
        {
            return await PostAsync<ApiResult<Guid>>($"/api/users/create", request);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await DeleteAsync($"/api/users/{id}");
        }

        public async Task<ApiResult<UserDto>> GetById(Guid id, bool isAdmin = false)
        {
            string url = $"/api/users/{id}";
            if (isAdmin)
            {
                url += $"/adminrole={isAdmin}";
            }
            return await GetAsync<ApiResult<UserDto>>(url);
        }

        public async Task<ApiResult<bool>> SignUp(SignUpDto request)
        {
            return await PostAsync<ApiResult<bool>>($"/api/auth/signup", request);
        }

        public async Task<ApiResult<Guid>> Update(Guid id, UserUpdateDto request)
        {
            return await PutAsync<ApiResult<Guid>>($"/api/users/{id}/update", request);
        }

        public async Task<ApiResult<int>> GetWishListCount(Guid userId)
        {
            return await GetAsync<ApiResult<int>>($"/api/users/{userId}/wish-list-count");
        }

        public async Task<ApiResult<List<WishListDto>>> GetWishList(Guid userId)
        {
            return await GetAsync<ApiResult<List<WishListDto>>>($"/api/users/{userId}/wish-lists");
        }

        public async Task<ApiResult<bool>> AddToWishlist(Guid userId, int productId)
        {
            return await PostAsync<ApiResult<bool>>($"/api/users/{userId}/wish-lists/{productId}/add", null);
        }

        public async Task<ApiResult<bool>> ForgotPassword(string email)
        {
            return await PostAsync<ApiResult<bool>>($"/api/auth/{email}/forgot-password", null);
        }

        public async Task<ApiResult<bool>> ResetPassword(ChangePasswordDto dto)
        {
            return await PutAsync<ApiResult<bool>>($"/api/auth/reset-password-token", dto);
        }

        public async Task<PageResult<List<UserDto>>> GetPagings(UserAdminPagingDto paging)
        {
            string url = $"/api/users/list?pageindex={paging.PageIndex}&pageiize={paging.PageSize}";

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                url += $"&keyword={paging.Keyword}";
            }
            return await GetAsync<PageResult<List<UserDto>>>(url);
        }

        public async Task<int> TotalActive()
        {
            var response = await GetAsync<ApiResult<int>>($"/api/users/total-actives");
            if (response != null && response.Success)
                return response.Data;
            return 0;
        }

        public async Task<ApiResult<UserDashboardDto>> GetDashboard(Guid userId)
        {
            return await GetAsync<ApiResult<UserDashboardDto>>($"/api/users/{userId}/dashboard");
        }

        public async Task<ApiResult<string>> ExternalSignIn(ExternalSignInDto dto)
        {
            return await PostAsync<ApiResult<string>>($"/api/auth/external-signin", dto);
        }

        public async Task<bool> CheckExistByEmail(string email)
        {
            var response = await GetAsync<ApiResult<bool>>($"/api/users/is-exist/{email}");
            if (response.Success)
                return true;
            return false;
        }

        public async Task<ApiResult<UserDto>> GetByEmail(string email)
        {
            return await GetAsync<ApiResult<UserDto>>($"/api/users/email={email}");
        }

        public async Task<bool> RemoveWishlistItem(Guid userId, int productId)
        {
            return await DeleteAsync($"/api/users/{userId}/wish-lists/{productId}/remove");
        }
    }
}
