using MissysPastrys.Models.User;
using MissysPastrys.Models;
using MissysPastrys.Models.Auth;

namespace MissysPastrys.Service.Interfaces
{
    public interface IUserService
    {
        BaseResponseModel DeleteUser(string userName);
        UserResponseModel GetUser(string userId);
        BaseResponseModel Register(SignUpViewModel request, string roleName);
        UserResponseModel Login(LoginViewModel request);
    }
}
