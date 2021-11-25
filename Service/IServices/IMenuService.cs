using DataTransferObjects.DTOs.Menus;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface IMenuService
    {
        ApiResult<List<MenuDto>> GetAll(bool adminRole = false);

        ApiResult<int> Create(MenuDto menu);

        ApiResult<int> Update(int id, MenuDto menu);

        ApiResult<bool> Delete(int id);

        ApiResult<MenuDto> GetById(int id);

    }
}
