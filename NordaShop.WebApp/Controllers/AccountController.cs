using AspNetCoreHero.ToastNotification.Abstractions;
using Common.Constants;
using Common.Messages;
using DataTransferObjects.DTOs.Auths;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Models.Account;
using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Globalization;

namespace NordaShop.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserApiClient _userApi;
        private readonly IConfiguration _config;
        private readonly INotyfService _notyf;

        public AccountController(IUserApiClient userApi,
            IConfiguration config,
            INotyfService notyf)
        {
            _userApi = userApi;
            _config = config;
            _notyf = notyf;
        }

        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = new SignInDto()
            {
                Username = model.Username,
                Password = model.Password,
                AdminRole = false
            };
            var response = await _userApi.SignIn(dto);
            if (!response.Success)
            {
                _notyf.Error(NotificationConstants.SignInFailed);
                return View(model);
            }
            var userPrincipal = this.ValidateToken(response.Data);
            var authProperties = new AuthenticationProperties
            {
                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),    //thời gian xác thực hết hạn
                IsPersistent = model.RememberMe                    //có sử dụng cookie để lưu dữ liệu hay không
            };
            //HttpContext.Session.Clear();
            HttpContext.Session.SetString(SystemConstants.Token, response.Data);
            HttpContext.Session.SetString(SystemConstants.UserId, userPrincipal?.FindFirstValue("Id"));
            HttpContext.Session.SetString(SystemConstants.Username, userPrincipal?.FindFirstValue("Username"));
            HttpContext.Session.SetString(SystemConstants.Email, userPrincipal?.FindFirstValue("Email"));
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperties);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var captcha = Request.Form["g-recaptcha-response"].ToString();
            if (!await IsValidCaptcha(captcha))
                return View(model);

            var dto = new SignUpDto()
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                RePassword = model.RePassword
            };
            var response = await _userApi.SignUp(dto);
            if (!response.Success)
            {
                string message = response.ErrorCode switch
                {
                    AuthMessage.ExistUsername => NotificationConstants.ExistUserName,
                    AuthMessage.ExistEmail => NotificationConstants.ExistEmail,
                    AuthMessage.CannotSendEmail => NotificationConstants.SendConfirmEmailFailed,
                    _ => NotificationConstants.SignUpFailed,
                };
                _notyf.Error(message);
                return View(model);
            }
            _notyf.Success(NotificationConstants.SignUpSuccess);
            return RedirectToAction("SignIn", "Account");
        }

        public IActionResult FacebookSignIn()
        {
            var properties = new AuthenticationProperties()
            {
                RedirectUri = Url.Action(nameof(CallbackFacebookSignIn))
            };
            return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> CallbackFacebookSignIn()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (result.Succeeded)
            {
                var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value,
                });

                var dto = new ExternalSignInDto()
                {
                    ExternalProvider = "FaceBook",
                    Email = claims.FirstOrDefault(x => x.Type.Split("/").Last() == "emailaddress").Value,
                    Username = claims.FirstOrDefault(x => x.Type.Split("/").Last() == "name").Value,
                    FirstName = claims.FirstOrDefault(x => x.Type.Split("/").Last() == "givenname").Value,
                    LastName = claims.FirstOrDefault(x => x.Type.Split("/").Last() == "surname").Value
                };

                var response = await _userApi.ExternalSignIn(dto);
                if (response != null && response.Success && response.ErrorCode == AuthMessage.UserLockout)
                {
                    _notyf.Error(NotificationConstants.LockoutAccount);
                    return RedirectToAction(nameof(AccountController.SignIn));
                }else if (response != null && response.Success)
                {
                    var userPrincipal = this.ValidateToken(response.Data);
                    HttpContext.Session.Clear();
                    HttpContext.Session.SetString(SystemConstants.Token, response.Data);
                    HttpContext.Session.SetString(SystemConstants.UserId, userPrincipal?.FindFirstValue("Id"));
                    HttpContext.Session.SetString(SystemConstants.Username, dto.Username);
                    return Redirect("/");
                }
            }
            _notyf.Error(NotificationConstants.FacebookSignInFailed);
            return RedirectToAction(nameof(AccountController.SignIn));
        }

        public IActionResult GoogleSignIn()
        {
            var properties = new AuthenticationProperties()
            {
                RedirectUri = Url.Action(nameof(CallbackGoogleSignIn))
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> CallbackGoogleSignIn()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (result.Succeeded)
            {
                var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });

                var dto = new ExternalSignInDto()
                {
                    ExternalProvider = "Google",
                    Email = claims.FirstOrDefault(x => x.Type.Split("/").Last() == "emailaddress").Value,
                    Username = claims.FirstOrDefault(x => x.Type.Split("/").Last() == "name").Value,
                    FirstName = claims.FirstOrDefault(x => x.Type.Split("/").Last() == "givenname").Value,
                    LastName = claims.FirstOrDefault(x => x.Type.Split("/").Last() == "surname").Value
                };

                var response = await _userApi.ExternalSignIn(dto);
                if (response != null && response.Success && response.ErrorCode == AuthMessage.UserLockout)
                {
                    _notyf.Error(NotificationConstants.LockoutAccount);
                    return RedirectToAction(nameof(AccountController.SignIn));
                }
                else if (response != null && response.Success)
                {
                    var userPrincipal = this.ValidateToken(response.Data);
                    HttpContext.Session.Clear();
                    HttpContext.Session.SetString(SystemConstants.Token, response.Data);
                    HttpContext.Session.SetString(SystemConstants.UserId, userPrincipal?.FindFirstValue("Id"));
                    HttpContext.Session.SetString(SystemConstants.Username, dto.Username);
                    return Redirect("/");
                }
            }
            _notyf.Error(NotificationConstants.GoogleSignInFailed);
            return RedirectToAction(nameof(AccountController.SignIn));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ConfirmResult(bool success)
        {
            TempData["SuccessConfirm"] = success;
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                _notyf.Error(NotificationConstants.InvalidForm);
                return View();
            }

            var response = await _userApi.ForgotPassword(email);
            if (response != null && response.Success)
            {
                _notyf.Success(NotificationConstants.SendResetPassEmailSuccess);
                return RedirectToAction(nameof(AccountController.SignIn));
            }
            _notyf.Error(NotificationConstants.Error);
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                _notyf.Error(NotificationConstants.GetTokenFailed);
                return RedirectToAction(nameof(AccountController.SignIn));
            }
            var model = new ResetPasswordViewModel() { Token = token };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = new ChangePasswordDto()
            {
                Token = model.Token,
                Password = model.Password
            };
            var result = await _userApi.ResetPassword(dto);
            if (result.Success)
            {
                _notyf.Success(NotificationConstants.ChangePassSuccess);
            }
            else
            {
                _notyf.Error(NotificationConstants.ChangePassFailed);
            }
            return RedirectToAction(nameof(AccountController.SignIn));
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _config.GetValue<string>("Jwt:Audience");
            validationParameters.ValidIssuer = _config.GetValue<string>("Jwt:Issuer");
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:Key")));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }

        private async Task<bool> IsValidCaptcha(string captcha)
        {
            try
            {
                using var client = new HttpClient();
                string secretKey = _config.GetValue<string>("ReCaptcha:ServerKey");
                var response = await client.PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={captcha}", new StringContent(""));
                var jsonString = await response.Content.ReadAsStringAsync();
                var captchaVerfication = JsonConvert.DeserializeObject<JObject>(jsonString);
                var success = captchaVerfication.GetValue("success");
                return (bool)success;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
