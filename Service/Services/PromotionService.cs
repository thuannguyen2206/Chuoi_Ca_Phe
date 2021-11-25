using Common.Messages;
using DataAccess.Entities;
using DataTransferObjects.DTOs.Promotions;
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
    public class PromotionService : IPromotionService
    {
        private readonly IUnitOfWork _uow;

        public PromotionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ApiResult<PromotionDto> GetById(int id)
        {
            var promotion = _uow.GetRepository<Promotion>().FindById(id);
            if (promotion != null)
            {
                var result = new PromotionDto()
                {
                    Description = promotion.Description,
                    DiscountCode = promotion.DiscountCode,
                    DiscountPercent = promotion.DiscountPercent,
                    ExpireTime = promotion.ExpireTime,
                    Id = promotion.Id,
                    IsShow = promotion.IsShow,
                    IsValid = promotion.IsValid,
                    StartTime = promotion.StartTime,
                    MaxValueDiscount = promotion.MaxValueDiscount
                };
                return new ApiResult<PromotionDto>(true, data: result);
            }
            return new ApiResult<PromotionDto>(false, errorCode: PromotionMessage.NotFound);
        }

        public ApiResult<int> Update(int id, PromotionDto dto)
        {
            var promotionRepo = _uow.GetRepository<Promotion>();
            var promotion = promotionRepo.FindById(id);
            if (promotion == null)
            {
                return new ApiResult<int>(false, errorCode: PromotionMessage.NotFound);
            }

            promotion.DateModified = DateTime.Now;
            promotion.Description = dto.Description;
            promotion.DiscountCode = dto.DiscountCode;
            promotion.DiscountPercent = dto.DiscountPercent;
            promotion.IsShow = dto.IsShow;
            promotion.IsValid = dto.IsValid;
            promotion.MaxValueDiscount = dto.MaxValueDiscount;
            if (dto.ExpireTime != null && dto.ExpireTime != DateTime.MinValue)
            {
                promotion.ExpireTime = dto.ExpireTime;
            }
            if (dto.StartTime != null && dto.StartTime != DateTime.MinValue)
            {
                promotion.StartTime = dto.StartTime;
            }

            promotionRepo.Update(promotion);
            _uow.SaveChanges();
            return new ApiResult<int>(true, data: promotion.Id);
        }

        public ApiResult<int> Create(PromotionDto dto)
        {
            var promotionRepo = _uow.GetRepository<Promotion>();
            var promotion = promotionRepo.Single(x => x.IsValid && x.DiscountCode == dto.DiscountCode);
            if (promotion != null)
            {
                return new ApiResult<int>(false, errorCode: PromotionMessage.ExistCode);
            }

            var entity = new Promotion()
            {
                DateCreated = DateTime.Now,
                Description = dto.Description,
                DiscountCode = dto.DiscountCode,
                DiscountPercent = dto.DiscountPercent,
                IsShow = dto.IsShow,
                IsValid = dto.IsValid,
                MaxValueDiscount = dto.MaxValueDiscount,
                ExpireTime = dto.ExpireTime != null && dto.ExpireTime != DateTime.MinValue ? dto.ExpireTime : DateTime.Now.AddDays(3),
                StartTime = dto.StartTime != null && dto.StartTime != DateTime.MinValue ? dto.StartTime : DateTime.Now
            };
            promotionRepo.Insert(entity);
            _uow.SaveChanges();
            return new ApiResult<int>(true, data: entity.Id);
        }

        public ApiResult<bool> Delete(int id)
        {
            var promotionRepo = _uow.GetRepository<Promotion>();
            var promotion = promotionRepo.FindById(id);
            if (promotion != null)
            {
                promotionRepo.Delete(promotion);
                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false, errorCode: PromotionMessage.NotFound);
        }

        public PageResult<List<PromotionDto>> GetPagings(PagingDto paging)
        {
            var promotionRepo = _uow.GetRepository<Promotion>().QueryAllReadOnly();


            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                paging.Keyword = paging.Keyword.Trim().ToLower();
                promotionRepo = promotionRepo.Where(x => x.DiscountCode.ToLower().Contains(paging.Keyword));
            }
            int totalRecord = promotionRepo.Count();
            var promotions = promotionRepo.OrderByDescending(x => x.Id)
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .Select(x => new PromotionDto()
                {
                    Id = x.Id,
                    Description = x.Description,
                    DiscountCode = x.DiscountCode,
                    DiscountPercent = x.DiscountPercent,
                    IsShow = x.IsShow,
                    IsValid = x.IsValid,
                    MaxValueDiscount = x.MaxValueDiscount,
                    ExpireTime = x.ExpireTime,
                    StartTime = x.StartTime
                }).ToList();

            var result = new PageResult<List<PromotionDto>>()
            {
                Items = promotions,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                TotalRecords = totalRecord
            };
            return result;
        }

        public ApiResult<PromotionDto> GetOnShowPromotion()
        {
            var now = DateTime.Now;
            var promotion = _uow.GetRepository<Promotion>().Single(x => x.IsValid && x.IsShow && x.StartTime <= now && x.ExpireTime > now);
            if (promotion != null)
            {
                var result = new PromotionDto()
                {
                    DiscountCode = promotion.DiscountCode,
                    DiscountPercent = promotion.DiscountPercent,
                    ExpireTime = promotion.ExpireTime,
                    Id = promotion.Id,
                    IsShow = promotion.IsShow,
                    IsValid = promotion.IsValid,
                    StartTime = promotion.StartTime,
                    Description = promotion.Description,
                    MaxValueDiscount = promotion.MaxValueDiscount
                };
                return new ApiResult<PromotionDto>(true, data: result);
            }
            return new ApiResult<PromotionDto>(false, errorCode: PromotionMessage.NotFound);
        }

    }
}
