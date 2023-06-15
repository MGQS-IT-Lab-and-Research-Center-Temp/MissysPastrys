namespace MissysPastrys.Models.User
{
    public class UserResponseModel : BaseResponseModel 
    {
        public UserViewModel User { get; set; }
    }

    public class UsersResponseModel : BaseResponseModel
    {
        public List<UserViewModel> User { get; set; }
    }
}
