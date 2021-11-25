using DataAccess.Entities;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using Common.Helper;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Common.Messages;
using Common.Constants;
using DataTransferObjects.DTOs.Auths;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork uow, IConfiguration configuration)
        {
            _uow = uow;
            _configuration = configuration;
        }

        public ApiResult<string> Authentication(SignInDto model)
        {
            var user = _uow.GetRepository<User>().Single(x => x.Username == model.Username
                                                        && x.Password == PasswordHashing.Sha256Hash(model.Password)
                                                        && x.IsActive && x.EmailConfirmed && !x.IsDelete);

            if (user != null)
            {
                if (model.AdminRole && !user.IsAdmin)
                {
                    return new ApiResult<string>(false, errorCode: AuthMessage.Invalid);
                }

                string token = this.GenerateAuthenToken(user.Id, user.Username, user.Email, user.IsAdmin);
                return new ApiResult<string>(true, data: token);
            }
            return new ApiResult<string>(false, errorCode: AuthMessage.Invalid);
        }

        public ApiResult<bool> SignUp(SignUpDto model)
        {
            var userQuery = _uow.GetRepository<User>();
            var checkUsername = userQuery.QueryCondition(x => x.Username == model.Username).FirstOrDefault();
            if (checkUsername != null)
            {
                return new ApiResult<bool>(false, errorCode: AuthMessage.ExistUsername);
            }

            var checkEmail = userQuery.QueryCondition(x => x.Email == model.Email).FirstOrDefault();
            if (checkEmail != null)
            {
                return new ApiResult<bool>(false, errorCode: AuthMessage.ExistEmail);
            }

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                Username = model.Username,
                Password = PasswordHashing.Sha256Hash(model.Password),
                IsActive = true,
                IsDelete = false,
                EmailConfirmed = false,
                DateCreated = DateTime.Now,
                AccumulatedPoint = 0,
                IsAdmin = false
            };
            userQuery.Insert(user);
            return new ApiResult<bool>(true);
        }

        public ApiResult<int> CreateResetPasswordCode(string email)
        {
            var checkUser = _uow.GetRepository<User>().Single(x => x.IsActive && x.Email == email);
            if (checkUser != null)
            {
                int code = CreateResetPasswordCode();
                var entity = new CodeReset()
                {
                    DateCreated = DateTime.Now,
                    Code = code,
                    Email = email,
                    IsValid = true,
                    ExpireTime = DateTime.Now.AddMinutes(2)
                };
                _uow.GetRepository<CodeReset>().Insert(entity);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: code);
            }
            return new ApiResult<int>(false, data: 0);
        }

        public ApiResult<bool> ResetPassword(int code, string password, string email)
        {
            var codeResetQuery = _uow.GetRepository<CodeReset>();

            var listCodes = codeResetQuery.QueryCondition(x => x.Email == email && x.Code == code && x.IsValid)
                .OrderByDescending(x => x.Id)
                .ToList();

            CodeReset codeReset = null;
            if (listCodes != null)
            {
                var now = DateTime.Now;
                foreach (var item in listCodes)
                {
                    if (now.Subtract(item.DateCreated).TotalMinutes <= 2)
                    {
                        codeReset = item;
                        break;
                    }
                }
            }

            if (codeReset != null)
            {
                var userQuery = _uow.GetRepository<User>();
                var user = userQuery.Single(x => x.Email == email);
                user.Password = PasswordHashing.Sha256Hash(password);
                userQuery.Update(user);

                codeReset.IsValid = false;
                codeResetQuery.Update(codeReset);
                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false, errorCode: AuthMessage.ResetPasswordFailed);
        }

        private int CreateResetPasswordCode()
        {
            Random random = new Random();
            int code = random.Next(100000, 999999);
            return code;
        }

        public string GenerateConfirmToken(string plainText)
        {
            string token = PasswordHashing.Sha256Hash(plainText);
            return token;
        }

        public bool ExistEmail(string email)
        {
            var user = _uow.GetRepository<User>().Single(x => x.Email == email && x.IsActive && !x.IsDelete && x.EmailConfirmed);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public ApiResult<bool> ResetPassword(string token, string password)
        {
            var checkToken = _uow.GetRepository<TokenConfirm>().Single(x => x.Token == token);
            var userRepo = _uow.GetRepository<User>();
            if (checkToken != null)
            {
                if (DateTime.Compare(DateTime.Now, checkToken.ExpireTime) <= 0) // not expired yet
                {
                    var user = userRepo.Single(x => x.Email == checkToken.Email && x.IsActive && !x.IsDelete);
                    if (user != null)
                    {
                        user.Password = PasswordHashing.Sha256Hash(password);
                    }

                    userRepo.Update(user);
                    _uow.SaveChanges();
                    return new ApiResult<bool>(true);
                }
            }
            return new ApiResult<bool>(false);
        }

        // if user is exist, generate token and return
        // if user not exist, create new user and generate token after that return
        public ApiResult<string> ExternalSignIn(ExternalSignInDto dto)
        {
            try
            {
                var userRepo = _uow.GetRepository<User>();
                var user = userRepo.Single(x => x.Email == dto.Email && x.EmailConfirmed && !x.IsDelete);
                if (user != null)
                {
                    if (user.IsActive)
                    {
                        user.Username = dto.Username;
                        user.FirstName = dto.FirstName;
                        user.LastName = dto.LastName;

                        userRepo.Update(user);
                        _uow.SaveChanges();
                        string token = this.GenerateAuthenToken(user.Id, user.Username, user.Email, user.IsAdmin);
                        return new ApiResult<string>(true, data: token);
                    }
                    else
                    {
                        return new ApiResult<string>(true, errorCode: AuthMessage.UserLockout);
                    }
                }
                else
                {
                    var entity = new User()
                    {
                        DateCreated = DateTime.Now,
                        IsActive = true,
                        IsDelete = false,
                        IsAdmin = false,
                        Email = dto.Email,
                        Username = dto.Username,
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        EmailConfirmed = true,
                        ExternalProvider = dto.ExternalProvider
                    };
                    userRepo.Insert(entity);
                    _uow.SaveChanges();

                    string token = this.GenerateAuthenToken(entity.Id, entity.Username, entity.Email, entity.IsAdmin);
                    return new ApiResult<string>(true, data: token);
                }
            }
            catch (Exception)
            {
                return new ApiResult<string>(false, errorCode: AuthMessage.Invalid);
            }
        }

        private string GenerateAuthenToken(Guid userId, string username, string email, bool isAdmin = false)
        {
            var claims = new[]
                {
                    new Claim("Id", userId.ToString()),
                    new Claim("Username", username),
                    new Claim("Email", email),
                    new Claim("Role", isAdmin ? "ADMIN" : "CUSTOMER")
                };
            var sercretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(sercretKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(SystemConstants.ExpireTimeSignInToken),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
