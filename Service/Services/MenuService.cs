using Common.Helper;
using Common.Messages;
using DataAccess.Entities;
using DataAccess.Enums;
using DataTransferObjects.DTOs.Menus;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _uow;

        public MenuService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ApiResult<int> Create(MenuDto dto)
        {
            try
            {
                var menuRepo = _uow.GetRepository<Menu>();
                var check = menuRepo.Single(x => !x.IsDelete && x.Name.ToLower() == dto.Name.Trim().ToLower());
                if (check != null)
                {
                    return new ApiResult<int>(false, errorCode: MenuMessage.ExistName);
                }
                var entity = new Menu()
                {
                    DateCreated = DateTime.Now,
                    DisplayOrder = dto.DisplayOrder,
                    IsActive = dto.IsActive,
                    Link = dto.Link,
                    Name = dto.Name,
                    MenuType = MenuType.MainMenu,
                    IsDelete = false,
                    SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias)
                };
                menuRepo.Insert(entity);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: entity.Id);
            }
            catch
            {
                return new ApiResult<int>(false, errorCode: MenuMessage.CreateFailed);
            }
        }

        public ApiResult<bool> Delete(int id)
        {
            var menuRepo = _uow.GetRepository<Menu>();
            var menu = menuRepo.Single(x => x.Id == id && !x.IsDelete);
            if (menu != null)
            {
                menu.IsActive = false;
                menu.IsDelete = true;
                menu.DateModified = DateTime.Now;

                menuRepo.Update(menu);
                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false, errorCode: MenuMessage.NotFound);
        }

        public ApiResult<List<MenuDto>> GetAll(bool adminRole = false)
        {
            var menus = _uow.GetRepository<Menu>().QueryConditionReadOnly(x => !x.IsDelete);
            if (!adminRole)
            {
                menus = menus.Where(x => x.IsActive);
            }
            var result = menus.OrderBy(x => x.DisplayOrder)
                .ThenBy(x => x.Id)
                .Select(x => new MenuDto()
                {
                    Id = x.Id,
                    DisplayOrder = x.DisplayOrder,
                    IsActive = x.IsActive,
                    Link = x.Link,
                    Name = x.Name,
                    DateCreated = x.DateCreated
                }).ToList();
            return new ApiResult<List<MenuDto>>(true, data: result);
        }

        public ApiResult<MenuDto> GetById(int id)
        {
            var menu = _uow.GetRepository<Menu>().Single(x => x.Id == id && !x.IsDelete);
            if (menu != null)
            {
                var result = new MenuDto()
                {
                    DisplayOrder = menu.DisplayOrder,
                    IsActive = menu.IsActive,
                    Link = menu.Link,
                    Name = menu.Name,
                    Id = menu.Id,
                    DateCreated = menu.DateCreated
                };
                return new ApiResult<MenuDto>(true, data: result);
            }
            return new ApiResult<MenuDto>(false, errorCode: MenuMessage.NotFound);
        }

        public ApiResult<int> Update(int id, MenuDto dto)
        {
            var menuRepo = _uow.GetRepository<Menu>();
            var menu = menuRepo.Single(x => x.Id == id && !x.IsDelete);
            if (menu != null)
            {
                menu.DisplayOrder = dto.DisplayOrder;
                menu.IsActive = dto.IsActive;
                //menu.Link = dto.Link;
                menu.Name = dto.Name;
                menu.DateModified = DateTime.Now;
                menu.SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias);

                menuRepo.Update(menu);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: menu.Id);
            }
            return new ApiResult<int>(false, errorCode: MenuMessage.NotFound);
        }

    }
}
