using MissysPastries.Models.Role;
using MissysPastries.Models;

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
