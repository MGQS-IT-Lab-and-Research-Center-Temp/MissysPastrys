﻿using MissysPastrys.Entities;
using MissysPastrys.Models;
using MissysPastrys.Models.Role;
using MissysPastrys.Repository.Interfaces;
using MissysPastrys.Service.Interfaces;

namespace MissysPastrys.Service.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public BaseResponseModel CreateRole(CreateRoleViewModel request)
        {

            var response = new BaseResponseModel();
            var createdBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var roleExist = _unitOfWork.Roles.Exists(r => r.RoleName == request.RoleName);

            if (roleExist)
            {
                response.Message = $"{request.RoleName} role already exist!";
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.RoleName))
            {
                response.Message = "Role name is required!";
                return response;
            }

            var role = new Role
            {
                RoleName = request.RoleName,
                Description = request.Description,
                CreatedBy = createdBy
            };

            try
            {
                _unitOfWork.Roles.Create(role);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Role created successfully";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Failed to create role: {ex.Message}";
                return response;
            }
        }

        public BaseResponseModel DeleteRole(string roleId)
        {
            var response = new BaseResponseModel();
            var roleIdExist = _unitOfWork.Roles.Exists(r => r.Id == roleId);
            var role = _unitOfWork.Roles.Get(roleId);

            if (!roleIdExist)
            {
                response.Message = "Role does not exist!";
                return response;
            }

            if (role.RoleName == "Admin" || role.RoleName == "Pastry Shopper")
            {
                response.Message = "Role cannot be deleted!";
                return response;
            }

            role.IsDeleted = true;

            try
            {
                _unitOfWork.Roles.Update(role);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Role deleted successfully";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Failed to delete role: {ex.Message}";
                return response;
            }
        }

        public RolesResponseModel GetAllRole()
        {
            var response = new RolesResponseModel();

            try
            {
                var role = _unitOfWork.Roles.GetAll(r => r.IsDeleted == false);

                if (role is null || role.Count == 0)
                {
                    response.Message = "You have not created a role!";
                    return response;
                }

                response.Role = role
                    .Select(r => new RoleViewModel
                    {
                        Id = r.Id,
                        RoleName = r.RoleName,
                        Description = r.Description
                    }).ToList();

                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
            return response;
        }

        public RoleResponseModel GetRole(string roleId)
        {

            var response = new RoleResponseModel();
            var roleExist = _unitOfWork.Roles.Exists(r =>
                                (r.Id == roleId)
                                && (r.Id == roleId
                                && r.IsDeleted == false));

            if (!roleExist)
            {
                response.Message = "Role does not exist!";
                return response;
            }

            var role = _unitOfWork.Roles.Get(roleId);

            response.Role = new RoleViewModel
            {
                Id = roleId,
                RoleName = role.RoleName,
                Description = role.Description
            };
            response.Message = "Success";
            response.Status = true;

            return response;
        }

        public BaseResponseModel UpdateRole(string roleId, UpdateRoleViewModel request)
        {
            var response = new BaseResponseModel();
            var modifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var roleIdExist = _unitOfWork.Roles.Exists(r => r.Id == roleId);

            if (!roleIdExist)
            {
                response.Message = "Role does not exist!";
                return response;
            }

            var role = _unitOfWork.Roles.Get(roleId);

            role.Description = request.Description;
            role.ModifiedBy = modifiedBy;

            try
            {
                _unitOfWork.Roles.Update(role);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Role updated successfully";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Failed to update role: {ex.Message}";
                return response;
            }
        }
    }
}
