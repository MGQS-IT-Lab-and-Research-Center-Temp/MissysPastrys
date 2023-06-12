using MissysPastries.Models;
using MissysPastries.Models.Auth;
using MissysPastrys.Models.User;
using MissysPastrys.Repository.Interfaces;
using MissysPastrys.Service.Interfaces;

namespace MissysPastrys.Service.Implementations
{
    public class UserService : IUserService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public BaseResponseModel DeleteUser(string userName)
        {
            var response = new BaseResponseModel();
            var userExist = _unitOfWork.Users.Exists(c => c.UserName == userName);
            var customer = _unitOfWork.Users.Get(userName);

            if (!userExist)
            {
                response.Message = "User does not exist!";
                return response;
            }

            customer.IsDeleted = true;

            try
            {
                _unitOfWork.Users.Update(customer);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "User deleted successfully";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Failed to delete user: {ex.Message}";
                return response;
            }
        }

        public UserResponseModel GetUser(string userId)
        {
            var response = new UserResponseModel();
            var user = _unitOfWork.Users.GetUser(c => c.Id == userId);

            if (user is null)
            {
                response.Message = $"User with {userId} does not exist!";
                return response;
            }

            response.User = new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName
            };
            response.Message = "User detail successfully retrieved...";
            response.Status = true;

            return response;
        }

        public UserResponseModel Login(LoginViewModel request)
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel Register(SignUpViewModel request, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
