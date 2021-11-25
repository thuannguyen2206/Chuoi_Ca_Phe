using Common.Helper;
using Common.Messages;
using DataAccess.Entities;
using DataAccess.Enums;
using DataTransferObjects.DTOs.Options;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class OptionService : IOptionService
    {
        private readonly IUnitOfWork _uow;

        public OptionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ApiResult<int> Create(OptionDto dto)
        {
            var optionRepo = _uow.GetRepository<Option>();
            var option = optionRepo.Single(x => !x.IsDelete && x.NameOption.ToLower() == dto.NameOption.Trim().ToLower());
            if (option != null)
            {
                return new ApiResult<int>(false, errorCode: OptionMessage.ExistName);
            }
            var entity = new Option()
            {
                DateCreated = DateTime.Now,
                IsActive = dto.IsActive,
                NameOption = dto.NameOption,
                OptionGroup = dto.OptionGroup,
                IsDelete = false,
                SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias)
            };
            optionRepo.Insert(entity);
            _uow.SaveChanges();
            return new ApiResult<int>(true, data: entity.Id);
        }

        public ApiResult<bool> Delete(int id)
        {
            var optionRepo = _uow.GetRepository<Option>();
            var option = optionRepo.FindById(id);
            if (option != null)
            {
                option.IsActive = false;
                option.IsDelete = true;
                option.DateModified = DateTime.Now;

                optionRepo.Update(option);
                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false, errorCode: OptionMessage.NotFound);
        }

        public ApiResult<OptionDto> GetById(int id)
        {
            var option = _uow.GetRepository<Option>().Single(x => x.Id == id && !x.IsDelete);
            if (option != null)
            {
                var dto = new OptionDto()
                {
                    Id = option.Id,
                    DateCreated = option.DateCreated,
                    IsActive = option.IsActive,
                    NameOption = option.NameOption,
                    OptionGroup = option.OptionGroup
                };
                return new ApiResult<OptionDto>(true, data:dto);
            }
            return new ApiResult<OptionDto>(false, errorCode: OptionMessage.NotFound);
        }

        public ApiResult<List<OptionDto>> GetOptions(bool adminRole = false)
        {
            var optionRepo = _uow.GetRepository<Option>().QueryConditionReadOnly(x => !x.IsDelete);

            if (!adminRole)
            {
                optionRepo = optionRepo.Where(x => x.IsActive);
            }
            var result = optionRepo.Select(x => new OptionDto()
            {
                Id = x.Id,
                IsActive = x.IsActive,
                DateCreated = x.DateCreated,
                NameOption = x.NameOption,
                OptionGroup = x.OptionGroup
            }).ToList();

            var sizeOptions = _uow.GetRepository<ProductOption>().QueryAllReadOnly();
            var colorOptions = _uow.GetRepository<Product>().QueryConditionReadOnly(x => !x.IsDelete)
                .GroupBy(x => x.ColorId).Select(x => new { ColorId = x.Key, Count = x.Count() }).ToList();

            foreach (var item in result ?? Enumerable.Empty<OptionDto>())
            {
                switch (item.OptionGroup)
                {
                    case ProductOptionGroup.Size:
                        item.ProductQuantity = sizeOptions.Where(y => y.OptionId == item.Id).Select(y => y.ProductId).Count();
                        break;
                    case ProductOptionGroup.Color:
                        item.ProductQuantity = colorOptions.Where(x => x.ColorId == item.Id).Select(x => x.Count).FirstOrDefault();
                        break;
                    default:
                        break;
                }
            }
            return new ApiResult<List<OptionDto>>(true, data: result);
        }

        public ApiResult<OptionDto> GetProductDefaultOption(int productId, ProductOptionGroup group)
        {
            var product = _uow.GetRepository<Product>().Single(x => x.Id == productId && x.IsActive && !x.IsDelete);
            if (product == null)
            {
                return new ApiResult<OptionDto>(false, errorCode: OptionMessage.ProductNotFound);
            }

            var option = _uow.GetRepository<Option>().QueryConditionReadOnly(x => !x.IsDelete && x.IsActive && x.OptionGroup == group);
            var productOption = _uow.GetRepository<ProductOption>()
                .QueryConditionReadOnly(x => x.ProductId == productId)
                .Select(x => x.OptionId).AsEnumerable();

            var result = option.Where(x => productOption.Contains(x.Id))
                .Select(x => new OptionDto()
                {
                    Id = x.Id,
                    DateCreated = x.DateCreated,
                    IsActive = x.IsActive,
                    NameOption = x.NameOption,
                    OptionGroup = x.OptionGroup
                }).FirstOrDefault();
            return new ApiResult<OptionDto>(true, data: result);
        }

        public ApiResult<List<OptionDto>> GetProductOption(int productId)
        {
            var optionRepo = _uow.GetRepository<Option>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productOptionRepo = _uow.GetRepository<ProductOption>().QueryAllReadOnly();

            var product = _uow.GetRepository<Product>().Single(x => x.Id == productId && !x.IsDelete);
            if (product == null)
            {
                return new ApiResult<List<OptionDto>>(false, errorCode: ProductMessage.NotFound);
            }
            var result = (from a in optionRepo
                         join b in productOptionRepo on a.Id equals b.OptionId
                         where b.ProductId == productId
                         select new OptionDto()
                         {
                             Id = a.Id,
                             DateCreated = a.DateCreated,
                             IsActive = a.IsActive,
                             NameOption = a.NameOption,
                             OptionGroup = a.OptionGroup
                         }).ToList();

            return new ApiResult<List<OptionDto>>(true, data: result);
        }

        public ApiResult<List<RelatedColorDto>> GetProductRelatedColor(int productId)
        {
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
           
            var product = productRepo.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                return new ApiResult<List<RelatedColorDto>>(false, errorCode: ProductMessage.NotFound);
            }

            var optionRepo = _uow.GetRepository<Option>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productDetailRepo = _uow.GetRepository<ProductDetail>().QueryAllReadOnly();

            var result = (from a in optionRepo
                          join b in productRepo on a.Id equals b.ColorId
                          join c in productDetailRepo on b.Id equals c.ProductId
                          where b.CodeProduct == product.CodeProduct
                          select new RelatedColorDto()
                          {
                              ColorName = a.NameOption,
                              CodeProduct = b.CodeProduct,
                              ColorId = b.ColorId,
                              ProductId = b.Id,
                              SeoAlias = c.SeoAlias
                          }).ToList();

            return new ApiResult<List<RelatedColorDto>>(true, data: result);
        }

        public ApiResult<int> Update(int optionId, OptionDto dto)
        {
            var optionRepo = _uow.GetRepository<Option>();
            var option = optionRepo.Single(x => x.Id == optionId && !x.IsDelete);
            if (option != null)
            {
                option.IsActive = dto.IsActive;
                option.NameOption = dto.NameOption;
                option.OptionGroup = dto.OptionGroup;
                option.DateModified = DateTime.Now;
                option.SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias);

                optionRepo.Update(option);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: option.Id);
            }
            return new ApiResult<int>(false, errorCode: OptionMessage.NotFound);
        }

    }
}
