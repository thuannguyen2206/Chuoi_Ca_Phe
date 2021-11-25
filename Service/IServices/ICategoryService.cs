using DataTransferObjects.DTOs.Categories;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface ICategoryService
    {
        /// <summary>
        /// Get all category
        /// </summary>
        /// <param name="adminRole"></param>
        /// if adminRole is false then get categoties with attribute active is true, ortherwise get all
        /// <returns></returns>
        ApiResult<List<CategoryDto>> GetAll(bool adminRole = false);

        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResult<CategoryDto> GetById(int id);

        /// <summary>
        /// Create new category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResult<int> Create(CategoryDto dto);

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResult<int> Update(int id, CategoryDto dto);

        /// <summary>
        /// Delete a category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       ApiResult<bool> Delete(int id);

    }
}
