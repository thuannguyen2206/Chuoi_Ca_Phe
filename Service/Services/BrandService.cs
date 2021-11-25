using Common.Constants;
using Common.Helper;
using Common.Messages;
using DataAccess.Entities;
using DataTransferObjects.DTOs.Brands;
using DataTransferObjects.DTOs.Utilities;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUtilityService _utilityService;

        public BrandService(IUnitOfWork uow, IUtilityService utilityService)
        {
            _uow = uow;
            _utilityService = utilityService;
        }

        public ApiResult<int> Create(BrandDto dto)
        {
            var brandRepo = _uow.GetRepository<Brand>();
            var checkBrand = brandRepo.Single(x => !x.IsDelete && x.BrandName.ToLower() == dto.BrandName.Trim().ToLower());
            if (checkBrand != null)
            {
                return new ApiResult<int>(false, errorCode: BrandMessage.ExistName);
            }
            string image = "";
            if (dto.BrandFile != null)
            {
                image = _utilityService.SaveFile(dto.BrandFile, "images/brands/");
            }

            var entity = new Brand()
            {
                BrandName = dto.BrandName,
                IsActive = dto.IsActive,
                DateCreated = DateTime.Now,
                IsDelete = false,
                BrandLogo = image,
                SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias)
            };

            brandRepo.Insert(entity);
            _uow.SaveChanges();

            if (entity.Id > 0)
            {
                return new ApiResult<int>(true, data: entity.Id);
            }
            return new ApiResult<int>(false, errorCode: BrandMessage.CreateFailed);
        }

        public ApiResult<bool> Delete(int id)
        {
            var brandRepo = _uow.GetRepository<Brand>();
            var brand = brandRepo.FindById(id);
            if (brand != null)
            {
                brand.IsActive = false;
                brand.IsDelete = true;
                brandRepo.Update(brand);
                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false);
        }

        public ApiResult<List<BrandDto>> GetAll(bool adminRole = false)
        {
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => !x.IsDelete);
            var brandRepo = _uow.GetRepository<Brand>().QueryConditionReadOnly(x => !x.IsDelete);
            if (!adminRole)
            {
                brandRepo = brandRepo.Where(x => x.IsActive);
            }
            var brands = brandRepo.OrderByDescending(x => x.Id)
                .Select(x => new BrandDto()
                {
                    BrandName = x.BrandName,
                    DateCreated = x.DateCreated,
                    Id = x.Id,
                    IsActive = x.IsActive,
                    BrandLogo = x.BrandLogo,
                    TotalProducts = productRepo.Count(y => y.BrandId == x.Id)
                }).ToList();
            return new ApiResult<List<BrandDto>>(true, data: brands);
        }

        public ApiResult<BrandDto> GetById(int id)
        {
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => !x.IsDelete);
            var brand = _uow.GetRepository<Brand>().FindById(id);
            if (brand != null)
            {
                var result = new BrandDto()
                {
                    BrandName = brand.BrandName,
                    DateCreated = brand.DateCreated,
                    Id = brand.Id,
                    IsActive = brand.IsActive,
                    TotalProducts = productRepo.Count(x => x.BrandId == id)
                };

                return new ApiResult<BrandDto>(true, data: result);
            }
            return new ApiResult<BrandDto>(false, errorCode: BrandMessage.NotFound);
        }

        public ApiResult<List<BrandDto>> GetPaging(PagingDto paging)
        {
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => !x.IsDelete && x.IsActive);
            var brandRepo = _uow.GetRepository<Brand>().QueryConditionReadOnly(x => !x.IsDelete);
            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                paging.Keyword = paging.Keyword.Trim().ToLower();
                brandRepo = brandRepo.Where(x => x.BrandName.ToLower().Contains(paging.Keyword));
            }
            var result = brandRepo.OrderByDescending(x => x.Id)
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .Select(x => new BrandDto()
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    BrandName = x.BrandName,
                    DateCreated = x.DateCreated,
                    TotalProducts = productRepo.Count(x => x.BrandId == x.Id)
                }).ToList();

            return new ApiResult<List<BrandDto>>(true, data: result);
        }

        public ApiResult<List<BrandDto>> GetTopBrands()
        {
            var queryProduct = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var brands = _uow.GetRepository<Brand>().QueryConditionReadOnly(x => !x.IsDelete && x.IsActive)
                 .OrderByDescending(x => x.Id)
                 .Take(SystemConstants.TopBrands)
                 .Select(x => new BrandDto()
                 {
                     BrandName = x.BrandName,
                     DateCreated = x.DateCreated,
                     Id = x.Id,
                     BrandLogo = x.BrandLogo,
                     IsActive = x.IsActive,
                     TotalProducts = queryProduct.Count(y => y.BrandId == x.Id)
                 }).OrderBy(x => x.Id).ToList();
            return new ApiResult<List<BrandDto>>(true, data: brands);
        }

        public ApiResult<int> Update(int id, BrandDto dto)
        {
            var brandRepo = _uow.GetRepository<Brand>();
            var brand = brandRepo.FindById(id);
            if (brand != null)
            {
                brand.IsActive = dto.IsActive;
                brand.DateModified = DateTime.Now;
                brand.BrandName = dto.BrandName;
                brand.SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias);
                if (dto.BrandFile != null)
                {
                    string logo = _utilityService.SaveFile(dto.BrandFile, "images/brands/");
                    brand.BrandLogo = logo;
                }

                brandRepo.Update(brand);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: brand.Id);
            }
            return new ApiResult<int>(false, errorCode: BrandMessage.NotFound);
        }

    }
}
