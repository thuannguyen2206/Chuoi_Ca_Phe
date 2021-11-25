using Common.Constants;
using Common.Helper;
using Common.Messages;
using DataAccess.Entities;
using DataTransferObjects.DTOs.Tags;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _uow;

        public TagService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ApiResult<int> Create(TagDto dto)
        {
            var tagRepo = _uow.GetRepository<Tag>();
            var checkName = tagRepo.Single(x => x.TagName.ToLower() == dto.TagName.Trim().ToLower());
            if (checkName != null)
            {
                return new ApiResult<int>(false, errorCode: TagMessage.ExistName);
            }
            var entity = new Tag()
            {
                DateCreated = DateTime.Now,
                IsActive = dto.IsActive,
                SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias),
                TagName = dto.TagName
            };
            tagRepo.Insert(entity);
            _uow.SaveChanges();
            return new ApiResult<int>(true, data: entity.Id);
        }

        public ApiResult<List<TagDto>> GetAll(bool adminRole = false)
        {
            var tagRepo = _uow.GetRepository<Tag>().QueryAllReadOnly();
            if (!adminRole)
            {
                tagRepo = tagRepo.Where(x => x.IsActive);
            }

            var result = tagRepo.OrderByDescending(x => x.Id)
                .Select(x => new TagDto()
                {
                    Id = x.Id,
                    DateCreated = x.DateCreated,
                    IsActive = x.IsActive,
                    SeoAlias = x.SeoAlias,
                    TagName = x.TagName
                }).ToList();
            return new ApiResult<List<TagDto>>(true, data: result);
        }

        public ApiResult<TagDto> GetById(int id)
        {
            var tag = _uow.GetRepository<Tag>().FindById(id);
            if (tag != null)
            {
                var result = new TagDto()
                {
                    Id = tag.Id,
                    DateCreated = tag.DateCreated,
                    IsActive = tag.IsActive,
                    SeoAlias = tag.SeoAlias,
                    TagName = tag.TagName
                };
                return new ApiResult<TagDto>(true, data: result);
            }
            return new ApiResult<TagDto>(false, errorCode: TagMessage.NotFound);
        }

        public ApiResult<List<TagDto>> GetTagOfPost(int postId)
        {
            var product = _uow.GetRepository<PostReview>().FindById(postId);
            if (product == null)
            {
                return new ApiResult<List<TagDto>>(false, errorCode: TagMessage.PostNotFound);
            }
            var tagRepo = _uow.GetRepository<Tag>().QueryConditionReadOnly(x => x.IsActive);
            var tagInPostRepo = _uow.GetRepository<TagInPost>().QueryConditionReadOnly(x => x.PostId == postId);
            var result = (from a in tagRepo
                          join b in tagInPostRepo on a.Id equals b.TagId
                          select new TagDto()
                          {
                              Id = a.Id,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              SeoAlias = a.SeoAlias,
                              TagName = a.TagName
                          }).ToList();

            return new ApiResult<List<TagDto>>(true, data: result);
        }

        public ApiResult<List<TagDto>> GetTagOfProduct(int productId)
        {
            var product = _uow.GetRepository<Product>().Single(x => x.Id == productId && !x.IsDelete);
            if (product == null)
            {
                return new ApiResult<List<TagDto>>(false, errorCode: TagMessage.ProductNotFound);
            }
            var tagRepo = _uow.GetRepository<Tag>().QueryConditionReadOnly(x => x.IsActive);
            var productTagRepo = _uow.GetRepository<TagInProduct>().QueryConditionReadOnly(x => x.ProductId == productId);
            var result = (from a in tagRepo
                          join b in productTagRepo on a.Id equals b.TagId
                          select new TagDto()
                          {
                              Id = a.Id,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              SeoAlias = a.SeoAlias,
                              TagName = a.TagName
                          }).ToList();

            return new ApiResult<List<TagDto>>(true, data: result);
        }

        public ApiResult<List<TagDto>> GetTopPostTags()
        {
            var tagRepo = _uow.GetRepository<Tag>().QueryConditionReadOnly(x => x.IsActive);
            var tagInPostRepo = _uow.GetRepository<TagInPost>().QueryAllReadOnly();

            var tagIds = (from a in tagRepo
                          join b in tagInPostRepo on a.Id equals b.TagId
                          select new
                          {
                              b.TagId,
                              b.PostId
                          }).AsEnumerable()
                     .GroupBy(x => x.TagId)
                     .OrderByDescending(x => x.Count())
                     .Take(SystemConstants.TopPostTag)
                     .Select(x => x.Key);

            var result = tagRepo.Where(x => tagIds.Contains(x.Id))
                .Select(x => new TagDto()
                {
                    Id = x.Id,
                    DateCreated = x.DateCreated,
                    IsActive = x.IsActive,
                    SeoAlias = x.SeoAlias,
                    TagName = x.TagName
                }).ToList();
            return new ApiResult<List<TagDto>>(true, data: result);
        }

        // Get list tag id with the most products, then get information from that tag id list 
        public ApiResult<List<TagDto>> GetTopProductTags()
        {
            var tagRepo = _uow.GetRepository<Tag>().QueryConditionReadOnly(x => x.IsActive);
            var tagInProductRepo = _uow.GetRepository<TagInProduct>().QueryAllReadOnly();

            var tagIds = (from a in tagRepo
                          join b in tagInProductRepo on a.Id equals b.TagId
                          select new
                          {
                              b.TagId,
                              b.ProductId
                          }).AsEnumerable()
                     .GroupBy(x => x.TagId)
                     .OrderByDescending(x => x.Count())
                     .Take(SystemConstants.TopProductTag)
                     .Select(x => x.Key);

            var result = tagRepo.Where(x => tagIds.Contains(x.Id))
                .Select(x => new TagDto()
                {
                    Id = x.Id,
                    DateCreated = x.DateCreated,
                    IsActive = x.IsActive,
                    SeoAlias = x.SeoAlias,
                    TagName = x.TagName
                }).ToList();
            return new ApiResult<List<TagDto>>(true, data: result);
        }

        public ApiResult<int> Update(int id, TagDto dto)
        {
            var tagRepo = _uow.GetRepository<Tag>();
            var tag = tagRepo.FindById(id);
            if (tag != null)
            {
                tag.DateModified = DateTime.Now;
                tag.IsActive = dto.IsActive;
                tag.SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias);
                tag.TagName = dto.TagName;

                tagRepo.Update(tag);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: tag.Id);
            }
            return new ApiResult<int>(false, errorCode: TagMessage.NotFound);
        }
    }
}
