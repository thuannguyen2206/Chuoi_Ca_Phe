using DataAccess.Entities;
using DataTransferObjects.DTOs.Roles;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _uow;

        public RoleService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ApiResult<bool> CheckAdminRole(Guid userId)
        {
            var userRepo = _uow.GetRepository<User>().QueryConditionReadOnly(x => !x.IsDelete && x.IsActive && x.EmailConfirmed);
            var roleRepo = _uow.GetRepository<Role>().QueryAllReadOnly();
            var userRoleRepo = _uow.GetRepository<UserRole>().QueryAllReadOnly();

            var user = userRepo.FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                return new ApiResult<bool>(false, errorCode: "UserNotFound");
            }
            var roles = (from a in roleRepo
                         join b in userRoleRepo on a.Id equals b.RoleId
                         where b.UserId == userId
                         select a.Name).ToList();

            if (roles.Contains("ADMIN"))
            {
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false, errorCode: "NotAdmin");
        }

        public List<RoleDto> GetAll()
        {
            var roles = _uow.GetRepository<Role>().QueryAllReadOnly()
                .Select(x => new RoleDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description=x.Description
                }).ToList();
            return roles;
        }

        public List<RoleDto> GetUserRoles(Guid userId)
        {
            var roleRepo = _uow.GetRepository<Role>().QueryAllReadOnly();
            var userRoleRepo = _uow.GetRepository<UserRole>().QueryConditionReadOnly(x => x.UserId == userId);
            var roles = (from a in roleRepo
                         join b in userRoleRepo on a.Id equals b.RoleId
                         select new RoleDto()
                         {
                             Id = a.Id,
                             Name = a.Name
                         }).ToList();
            return roles;
        }

    }
}
