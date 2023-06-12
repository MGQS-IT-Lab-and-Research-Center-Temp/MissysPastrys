using MissysPastries.Models.Auth;
using MissysPastries.Models;
using MissysPastrys.Models.User;

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
