using Common.Helper;
using Common.Messages;
using DataAccess.Entities;
using DataTransferObjects.DTOs.Categories;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;

        public CategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ApiResult<int> Create(CategoryDto dto)
        {
            try
            {
                var repoCate = _uow.GetRepository<Category>();

                var check = repoCate.Single(x => x.Name == dto.Name);
                if (check != null)
                {
                    return new ApiResult<int>(false, errorCode: CategoryMessage.ExistName);
                }

                var entity = new Category()
                {
                    Description = dto.Description,
                    Name = dto.Name,
                    IsActive = dto.IsActive,
                    ParentId = dto.ParentId,
                    Title = dto.Title,
                    SortOrder = dto.SortOrder,
                    DateCreated = DateTime.Now,
                    IsDelete = false,
                    MenuId = 2,// sản phẩm dto.MenuId,
                    SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias)
                };
                repoCate.Insert(entity);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: entity.Id);
            }
            catch (Exception)
            {
                return new ApiResult<int>(false, errorCode: CategoryMessage.CreateFailed);
            }
        }

        public ApiResult<bool> Delete(int id)
        {
            var cateRepo = _uow.GetRepository<Category>();
            var category = cateRepo.FindById(id);
            if (category != null)
            {
                category.DateModified = DateTime.Now;
                category.IsActive = false;
                category.IsDelete = true;

                cateRepo.Update(category);
                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false);
        }

        public ApiResult<List<CategoryDto>> GetAll(bool adminRole = false)
        {
            var categoryRepo = _uow.GetRepository<Category>().QueryConditionReadOnly(x => !x.IsDelete);
            var menuRepo = _uow.GetRepository<Menu>().QueryConditionReadOnly(x => x.IsActive);
            if (!adminRole)
            {
                categoryRepo = categoryRepo.Where(x => x.IsActive);
            }

            var result = categoryRepo.OrderBy(x => x.SortOrder)
                .ThenBy(x => x.Id)
                .Select(x => new CategoryDto()
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    DateCreated = x.DateCreated,
                    Description = x.Description,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    SortOrder = x.SortOrder,
                    Title = x.Title,
                    MenuId = x.MenuId,
                    MenuName = menuRepo.FirstOrDefault(y => y.Id == x.MenuId) != null ? menuRepo.FirstOrDefault(y => y.Id == x.MenuId).Name : "No"
                }).ToList();
            return new ApiResult<List<CategoryDto>>(true, data: result);
        }

        public ApiResult<CategoryDto> GetById(int id)
        {
            var cate = _uow.GetRepository<Category>().Single(x => x.Id == id && !x.IsDelete);
            if (cate != null)
            {
                var result = new CategoryDto()
                {
                    DateCreated = cate.DateCreated,
                    Description = cate.Description,
                    Id = cate.Id,
                    ParentId = cate.ParentId,
                    Title = cate.Title,
                    SortOrder = cate.SortOrder,
                    Name = cate.Name,
                    IsActive = cate.IsActive,
                    MenuId = cate.MenuId,
                    SeoAlias = cate.SeoAlias
                };
                return new ApiResult<CategoryDto>(true, data: result);
            }
            return new ApiResult<CategoryDto>(false, errorCode: CategoryMessage.NotFound);
        }

        public ApiResult<int> Update(int id, CategoryDto dto)
        {
            var categoryRepo = _uow.GetRepository<Category>();

            var cate = categoryRepo.Single(x => x.Id == id && !x.IsDelete);
            if (cate != null)
            {
                cate.Description = dto.Description;
                cate.ParentId = dto.ParentId;
                cate.Title = dto.Title;
                cate.SortOrder = dto.SortOrder;
                cate.Name = dto.Name;
                cate.IsActive = dto.IsActive;
                cate.DateModified = DateTime.Now;
                //cate.MenuId = dto.MenuId;
                cate.SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias);

                categoryRepo.Update(cate);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: cate.Id);
            }
            return new ApiResult<int>(false, errorCode: CategoryMessage.NotFound);
        }

    }
}
