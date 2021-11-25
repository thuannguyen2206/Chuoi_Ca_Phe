using Common.Helper;
using Common.Messages;
using DataAccess.Entities;
using DataAccess.Enums;
using DataTransferObjects.DTOs.Options;
using DataTransferObjects.DTOs.Users;
using DataTransferObjects.DTOs.Utilities;
using DataTransferObjects.DTOs.WishLists;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUtilityService _utilityService;

        public UserService(IUnitOfWork uow, IUtilityService utilityService)
        {
            _uow = uow;
            _utilityService = utilityService;
        }

        public ApiResult<Guid> Update(Guid id, UserUpdateDto dto)
        {
            try
            {
                var userRepo = _uow.GetRepository<User>();
                var user = userRepo.Single(x => x.Id == id && x.EmailConfirmed && !x.IsDelete);

                if (user == null)
                {
                    return new ApiResult<Guid>(false, errorCode: UserMessage.NotFound);
                }
                var checkUserName = userRepo.Single(x => x.Id != id && !x.IsDelete && x.Username.ToLower() == dto.Username.Trim().ToLower());
                if (checkUserName != null)
                {
                    return new ApiResult<Guid>(false, errorCode: UserMessage.ExistUserName);
                }
                var checkEmail = userRepo.Single(x => x.Id != id && !x.IsDelete && x.Email == dto.Email);
                if (checkEmail != null)
                {
                    return new ApiResult<Guid>(false, errorCode: UserMessage.ExistEmail);
                }

                user.Username = dto.Username;
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.IsActive = dto.IsActive;
                user.PhoneNumber = dto.PhoneNumber;
                user.Address = dto.Address;
                user.DateModified = DateTime.Now;
                user.IsAdmin = dto.IsAdmin;
                user.Email = dto.Email;
                if (dto.AvatarFile != null)
                {
                    string path = _utilityService.SaveFile(dto.AvatarFile, "images/users/");
                    user.AvatarLink = path;
                }
                if (!string.IsNullOrEmpty(dto.CurrentPassword) && !string.IsNullOrEmpty(dto.NewPassword))
                {
                    var checkPass = user.Password == PasswordHashing.Sha256Hash(dto.CurrentPassword);
                    if (checkPass)
                    {
                        user.Password = PasswordHashing.Sha256Hash(dto.NewPassword);
                    }
                    else
                    {
                        return new ApiResult<Guid>(false, errorCode: UserMessage.ChangePassFailed);
                    }
                }

                userRepo.Update(user);
                _uow.SaveChanges();
                return new ApiResult<Guid>(true, data: user.Id);
            }
            catch
            {
                return new ApiResult<Guid>(false, errorCode: UserMessage.UpdateFailed);
            }
        }

        public ApiResult<List<UserDto>> GetAll()
        {
            try
            {
                var users = _uow.GetRepository<User>().QueryAllReadOnly()
                .Select(x => new UserDto()
                {
                    Id = x.Id,
                    Address = x.Address,
                    DateCreated = x.DateCreated,
                    Email = x.Email,
                    EmailConfirmed = x.EmailConfirmed,
                    FirstName = x.FirstName,
                    IsActive = x.IsActive,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Username = x.Username
                }).ToList();
                return new ApiResult<List<UserDto>>(true, data: users);
            }
            catch (Exception e)
            {
                return new ApiResult<List<UserDto>>(false, data: null, errorCode:e.Message);
            }
        }

        // if is admin then check active condition
        public ApiResult<UserDto> GetById(Guid id, bool isAdmin = false)
        {
            var user = _uow.GetRepository<User>().Single(x => x.Id == id && !x.IsDelete && x.EmailConfirmed);
            if (user != null)
            {
                if (!isAdmin && !user.IsActive)
                {
                    return new ApiResult<UserDto>(false, errorCode: UserMessage.NotPermisstion);
                }
                var model = new UserDto()
                {
                    Id = id,
                    Address = user.Address,
                    DateCreated = user.DateCreated,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    FirstName = user.FirstName,
                    IsActive = user.IsActive,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Username = user.Username,
                    IsAdmin = user.IsAdmin,
                    AvatarLink = user.AvatarLink,
                    AccumulatedPoint = user.AccumulatedPoint
                };
                return new ApiResult<UserDto>(true, data: model);
            }
            return new ApiResult<UserDto>(false, data: null, errorCode: UserMessage.NotFound);
        }

        public PageResult<List<UserDto>> GetUserPaging(UserAdminPagingDto paging)
        {
            var userRepo = _uow.GetRepository<User>().QueryConditionReadOnly(x => !x.IsDelete && x.EmailConfirmed);
            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                paging.Keyword = paging.Keyword.Trim().ToLower();
                userRepo = userRepo.Where(x => x.Username.ToLower().Contains(paging.Keyword)
                  || x.FirstName.ToLower().Contains(paging.Keyword)
                  || x.LastName.ToLower().Contains(paging.Keyword)
                  || x.Email.ToLower().Contains(paging.Keyword)
                  || x.Address.ToLower().Contains(paging.Keyword));
            }

            int totalRow = userRepo.Count();
            var result = userRepo.OrderByDescending(x => x.DateCreated)
                .ThenBy(x=>x.Username)
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .Select(x => new UserDto()
                {
                    Id = x.Id,
                    Address = x.Address,
                    DateCreated = x.DateCreated,
                    Email = x.Email,
                    EmailConfirmed = x.EmailConfirmed,
                    FirstName = x.FirstName,
                    IsActive = x.IsActive,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Username = x.Username,
                    AvatarLink = x.AvatarLink,
                }).ToList();

            var pageResult = new PageResult<List<UserDto>>()
            {
                Items = result,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                TotalRecords = totalRow
            };
            return pageResult;
        }

        public void RemoveByEmail(string email)
        {
            var repo = _uow.GetRepository<User>();
            var user = repo.Single(x => x.Email == email);
            if (user != null)
            {
                repo.Delete(user);
                _uow.SaveChanges(); 
            }
        }

        public ApiResult<Guid> Create(UserCreateDto dto)
        {
            try
            {
                var userRepo = _uow.GetRepository<User>();
                var checkUsername = userRepo.Single(x => !x.IsDelete && x.Username == dto.Username);
                if (checkUsername != null)
                {
                    return new ApiResult<Guid>(false, errorCode: UserMessage.ExistUserName);
                }

                var checkEmail = userRepo.Single(x => !x.IsDelete && x.Email == dto.Email);
                if (checkEmail != null)
                {
                    return new ApiResult<Guid>(false, errorCode: UserMessage.ExistEmail);
                }

                var user = new User()
                {
                    Username = dto.Username,
                    Password = PasswordHashing.Sha256Hash(dto.Password),
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    IsActive = dto.IsActive,
                    PhoneNumber = dto.PhoneNumber,
                    Address = dto.Address,
                    DateCreated = DateTime.Now,
                    Email = dto.Email,
                    EmailConfirmed = true,
                    IsDelete = false,
                    IsAdmin = dto.IsAdmin,
                    AccumulatedPoint = 0
                };
                if (dto.AvatarFile != null)
                {
                    string path = _utilityService.SaveFile(dto.AvatarFile, "images/users/");
                    user.AvatarLink = path;
                }

                userRepo.Insert(user);
                _uow.SaveChanges();
                return new ApiResult<Guid>(true, data: user.Id);
            }
            catch (Exception)
            {
                return new ApiResult<Guid>(false, errorCode: UserMessage.CreateFailed);
            }
        }

        public ApiResult<bool> Delete(Guid id)
        {
            var userRepo = _uow.GetRepository<User>();
            var user = userRepo.FindById(id);
            if (user != null)
            {
                user.DateModified = DateTime.Now;
                user.IsActive = false;
                user.IsDelete = true;

                userRepo.Update(user);
                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false);
        }

        public ApiResult<int> GetWishListCount(Guid userId)
        {
            var user = _uow.GetRepository<User>().FindById(userId);
            if (user == null)
            {
                return new ApiResult<int>(false, errorCode: UserMessage.NotFound);
            }

            var result = _uow.GetRepository<WishList>().QueryConditionReadOnly(x => x.UserId == userId).Count();
            return new ApiResult<int>(true, data: result);
        }

        public ApiResult<List<WishListDto>> GetWishList(Guid userId)
        {
            var user = _uow.GetRepository<User>().Single(x => x.Id == userId && x.IsActive && x.EmailConfirmed && !x.IsDelete);
            if (user == null)
            {
                return new ApiResult<List<WishListDto>>(false, errorCode: ProductMessage.UserNotFound);
            }

            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);
            var productDetailRepo = _uow.GetRepository<ProductDetail>().QueryAllReadOnly();
            var wishlistRepo = _uow.GetRepository<WishList>().QueryConditionReadOnly(x => x.UserId == userId);
            var sizeOption = from a in _uow.GetRepository<Option>().QueryConditionReadOnly(x => !x.IsDelete && x.IsActive && x.OptionGroup == ProductOptionGroup.Size)
                             join b in _uow.GetRepository<ProductOption>().QueryAllReadOnly() on a.Id equals b.OptionId
                             select new { a.Id, a.NameOption, b.ProductId };


            var result = (from a in wishlistRepo
                          join b in productRepo on a.ProductId equals b.Id
                          join c in productImageRepo on b.Id equals c.ProductId into pi
                          from c in pi.DefaultIfEmpty()
                          join d in productDetailRepo on b.Id equals d.ProductId into pd
                          from d in pd.DefaultIfEmpty()
                          select new WishListDto()
                          {
                              ProductId = a.ProductId,
                              DateCreated = a.DateCreated,
                              ImageLink = c.ImageLink,
                              NameProduct = b.Name,
                              Price = (b.Price - b.DiscountPrice),
                              Quantity = a.Quantity,
                              SeoAlias = d.SeoAlias,
                              Options = sizeOption.Where(x => x.ProductId == a.ProductId).Select(x => new OptionDto()
                              {
                                  Id = x.Id,
                                  NameOption = x.NameOption
                              }).ToList()
                          }).ToList();

            return new ApiResult<List<WishListDto>>(true, data: result);
        }

        public ApiResult<bool> AddToWishList(Guid userId, int productId)
        {
            var wishlistRepo = _uow.GetRepository<WishList>();
            var product = _uow.GetRepository<Product>().Single(x => x.Id == productId && x.IsActive && !x.IsDelete);
            if (product == null)
            {
                return new ApiResult<bool>(false, errorCode: ProductMessage.NotFound);
            }
            var user= _uow.GetRepository<User>().Single(x => x.Id == userId && x.IsActive && x.EmailConfirmed && !x.IsDelete);
            if (user == null)
            {
                return new ApiResult<bool>(false, errorCode: UserMessage.NotFound);
            }

            var checkExist = wishlistRepo.Single(x => x.UserId == userId && x.ProductId == productId);
            if (checkExist != null)
            {
                return new ApiResult<bool>(true, errorCode: UserMessage.WishlistExisted);
            }
            var entity = new WishList()
            {
                DateCreated = DateTime.Now,
                ProductId = productId,
                Quantity = 1,
                UserId = userId
            };
            wishlistRepo.Insert(entity);
            _uow.SaveChanges();
            return new ApiResult<bool>(true, data: true);
        }

        public ApiResult<int> TotalActives()
        {
            var users = _uow.GetRepository<User>().QueryConditionReadOnly(x => !x.IsDelete && x.EmailConfirmed && x.IsActive).Count();
            return new ApiResult<int>(true, data: users);
        }

        public ApiResult<UserDashboardDto> GetCustomerDashboard(Guid userId)
        {
            var user = _uow.GetRepository<User>().Single(x => x.Id == userId && x.IsActive && x.EmailConfirmed && !x.IsDelete);
            if (user == null)
            {
                return new ApiResult<UserDashboardDto>(false, errorCode: UserMessage.NotFound);
            }

            var orderRepo = _uow.GetRepository<Order>().QueryConditionReadOnly(x => x.UserId == userId);
            var totalPurchaseCost = orderRepo.Sum(x => x.TotalPrice);
            var totalOrders = orderRepo.Count();
            var now = DateTime.Now;
            var monthlyPurchaseCost = orderRepo.Where(x => x.DateCreated.Year == now.Year && x.DateCreated.Month == now.Month)
                .Sum(x => x.TotalPrice);

            var result = new UserDashboardDto()
            {
                MonthlyPurchaseCost = monthlyPurchaseCost,
                TotalPurchaseCost = totalPurchaseCost,
                UserTotalOrders = totalOrders,
                AccumulatedPoint = user.AccumulatedPoint
            };
            return new ApiResult<UserDashboardDto>(true, data: result);
        }

        public ApiResult<bool> CheckExistByEmail(string email)
        {
            var user = _uow.GetRepository<User>().Single(x => x.Email == email && !x.IsDelete);
            if (user != null)
                return new ApiResult<bool>(true, data: true);
            return new ApiResult<bool>(false, data: false);
        }

        public ApiResult<UserDto> GetByEmail(string email)
        {
            var user = _uow.GetRepository<User>().Single(x => x.Email == email && x.EmailConfirmed && !x.IsDelete);
            if (user != null)
            {
                if (!user.IsActive)
                {
                    return new ApiResult<UserDto>(true, errorCode: UserMessage.NotPermisstion);
                }

                var dto = new UserDto()
                {
                    Id = user.Id,
                    Address = user.Address,
                    DateCreated = user.DateCreated,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    FirstName = user.FirstName,
                    IsActive = user.IsActive,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Username = user.Username,
                    IsAdmin = user.IsAdmin,
                    AvatarLink = user.AvatarLink
                };
                return new ApiResult<UserDto>(true, data: dto);
            }
            return new ApiResult<UserDto>(false, errorCode: UserMessage.NotFound);
        }

        public ApiResult<bool> RemoveWishlistItem(Guid userId, int productId)
        {
            var product = _uow.GetRepository<Product>().Single(x => x.Id == productId && x.IsActive && !x.IsDelete);
            if (product == null)
            {
                return new ApiResult<bool>(false, errorCode: ProductMessage.NotFound);
            }
            var user = _uow.GetRepository<User>().Single(x => x.Id == userId && x.IsActive && x.EmailConfirmed && !x.IsDelete);
            if (user == null)
            {
                return new ApiResult<bool>(false, errorCode: UserMessage.NotFound);
            }
            var wishlistRepo = _uow.GetRepository<WishList>();
            var wishList = wishlistRepo.Single(x => x.UserId == userId && x.ProductId == productId);
            if (wishList != null)
            {
                wishlistRepo.Delete(wishList);
                _uow.SaveChanges();
                return new ApiResult<bool>(true, data: true);
            }
            return new ApiResult<bool>(false, errorCode: UserMessage.WishlistNotFound);
        }

    }
}
