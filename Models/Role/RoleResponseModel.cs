namespace MissysPastrys.Models.Role
{
    public class RoleResponseModel : BaseResponseModel
    {
        public RoleViewModel Role { get; set; }
    }

    public class RolesResponseModel : BaseResponseModel
    {
        public List<RoleViewModel> Role { get; set; }
    }
}
