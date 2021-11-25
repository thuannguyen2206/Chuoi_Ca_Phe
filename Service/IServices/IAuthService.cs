using DataTransferObjects.DTOs.Auths;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Service.IServices
{
    public interface IAuthService
    {
        /// <summary>
        /// AUthentication
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResult<string> Authentication(SignInDto model);

        /// <summary>
        /// Sign up
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResult<bool> SignUp(SignUpDto model);

        /// <summary>
        /// Create code to reset password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        ApiResult<int> CreateResetPasswordCode(string email);

        /// <summary>
        /// Reset password by code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        ApiResult<bool> ResetPassword(int code, string password, string email);

        /// <summary>
        /// Reset password by token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ApiResult<bool> ResetPassword(string token, string password);

        /// <summary>
        /// Create confirm token
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        string GenerateConfirmToken(string plainText);

        bool ExistEmail(string email);

        /// <summary>
        /// External sign in like facebook, google, ...
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Token if sign in success, else error</returns>
        ApiResult<string> ExternalSignIn(ExternalSignInDto dto);
    }
}
