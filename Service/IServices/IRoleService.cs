using DataTransferObjects.DTOs.Roles;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface IRoleService
    {
        /// <summary>
        /// Get all roles of application
        /// </summary>
        /// <returns></returns>
        List<RoleDto> GetAll();

        /// <summary>
        /// Get list roles of user by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List roles</returns>
        List<RoleDto> GetUserRoles(Guid userId);

        /// <summary>
        /// Check is admin role
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ApiResult<bool> CheckAdminRole(Guid userId);

    }
}
