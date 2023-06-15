using MissysPastrys.Models;
using MissysPastrys.Models.Role;

namespace MissysPastrys.Service.Interfaces
{
    public interface IRoleService
    {

        BaseResponseModel CreateRole(CreateRoleViewModel request);
        BaseResponseModel DeleteRole(string roleId);
        BaseResponseModel UpdateRole(string roleId, UpdateRoleViewModel request);
        RoleResponseModel GetRole(string roleId);
        RolesResponseModel GetAllRole();
    }
}
