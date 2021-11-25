using Common.Constants;
using Common.Messages;
using DataTransferObjects.DTOs.Auths;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly ILogger<AuthController> _logger;
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _config;

        public AuthController(IAuthService authService, IEmailService emailService, 
            ILogger<AuthController> logger, IUnitOfWork uow, IConfiguration config)
        {
            _authService = authService;
            _emailService = emailService;
            _logger = logger;
            _uow = uow;
            _config = config;
        }

        [HttpPost("signin")]
        public IActionResult SignIn(SignInDto model)
        {
            var token = _authService.Authentication(model);
            if (token.Success)
            {
                return Ok(token);
            }
            return BadRequest(token);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpDto model)
        {
            var result = _authService.SignUp(model);
            if (result.Success)
            {
                string token = AddConfirmToken(model.Email);
                if (!string.IsNullOrEmpty(token))
                {
                    // Encode token
                    string tokenEmailConfirm = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                    // Callback url
                    var confirmationLink = Url.Action("ConfirmEmail", "Auth", new { token = tokenEmailConfirm, email = model.Email }, Request.Scheme);

                    // Build body email
                    var dicContent = new Dictionary<string, string>();
                    dicContent.Add(EmailConstants.UserName, model.Username);
                    dicContent.Add(EmailConstants.ConfirmLink, confirmationLink);

                    string content = _emailService.BuildBodyEmail(EmailConstants.ConfirmEmailPath, dicContent);
                    try
                    {
                        await _emailService.SendEmailSendgridAsync(model.Email, content, AuthMessage.SubjectConfirmEmail);
                        //await _emailService.SendEmailSmtpAsync(model.Email, content, AuthControllerMessage.SubjectConfirmEmail);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError("Error can't send email: " + e.Message.ToString());
                        return BadRequest(new ApiResult<string>(false, errorCode: AuthMessage.CannotSendEmail));
                    }
                }
                this._uow.SaveChanges();
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("external-signin")]
        public IActionResult ExternalSignIn(ExternalSignInDto dto)
        {
            var result = _authService.ExternalSignIn(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("{email}/generate-code")]
        public IActionResult GenerateCode(string email) // Create code to reset password
        {
            var result = _authService.CreateResetPasswordCode(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("reset-password-code")]
        public IActionResult ResetPassword(ResetPasswordDto dto)
        {
            var result = _authService.ResetPassword(dto.Code, dto.Password, dto.Email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("reset-password-token")]
        public IActionResult ResetPassword(ChangePasswordDto dto)
        {
            var result = _authService.ResetPassword(dto.Token, dto.Password);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("{email}/forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var check = _authService.ExistEmail(email);
            if (check)
            {
                string token = AddConfirmToken(email);
                if (!string.IsNullOrEmpty(token))
                {
                    // Encode token
                    string tokenEmailConfirm = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                    // Callback url
                    var confirmLink = Url.Action("ConfirmToken", "Auth", new { token = tokenEmailConfirm, email }, Request.Scheme);

                    // Build body email
                    var dicContent = new Dictionary<string, string>();
                    dicContent.Add(EmailConstants.ConfirmLink, confirmLink);

                    string content = _emailService.BuildBodyEmail(EmailConstants.ResetPasswordPath, dicContent);
                    try
                    {
                        await _emailService.SendEmailSendgridAsync(email, content, AuthMessage.SubjectResetPassword);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError("Error can't send email: " + e.Message.ToString());
                        return BadRequest(new ApiResult<bool>(false, errorCode: "ResetPassword.CannotSendEmail"));
                    }
                    this._uow.SaveChanges();
                    return Ok(new ApiResult<bool>(true));
                }
                return BadRequest(new ApiResult<bool>(false, errorCode: "TokenIsNull"));
            }
            return BadRequest(new ApiResult<bool>(false, errorCode: "EmailNotFound"));
        }

        [HttpGet("confirm-token")]
        public IActionResult ConfirmToken(string token, string email)
        {
            // Encode token
            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            var result = _emailService.ConfirmToken(token, email);
            string wepAppUri = _config.GetValue<string>("WebAppUri");
            return Redirect($"{wepAppUri}/account/resetpassword?token={(result ? token : string.Empty)}");
        }

        [HttpGet("confirm-email")]
        public IActionResult ConfirmEmail(string token, string email)
        {
            // Encode token
            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            var result = _emailService.ConfirmEmail(token, email);
            //if (result)
            //{  
            //    return Ok(new ApiResult<bool>(true));
            //}
            //return BadRequest(new ApiResult<bool>(false));
            string wepAppUri = _config.GetValue<string>("WebAppUri");
            return Redirect($"{wepAppUri}/account/confirmresult?success={result}");
        }

        private string AddConfirmToken(string email)
        {
            string plainText = string.Format("{0}_{1}", email, DateTime.Now.ToString());
            string token = _authService.GenerateConfirmToken(plainText);
            bool result = _emailService.AddTokenConfirm(email, token);
            if (result)
            {
                return token;
            }
            return string.Empty;
        }

    }
}
