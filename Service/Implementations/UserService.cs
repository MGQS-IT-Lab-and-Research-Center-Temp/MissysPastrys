using MissysPastries.Helper;
using MissysPastrys.Entities;
using MissysPastrys.Models;
using MissysPastrys.Models.Auth;
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
            var response = new UserResponseModel();

            try
            {
                var user = _unitOfWork.Users.GetUser(c => c.UserName.ToLower() == request.UserName.ToLower());

                if (user is null)
                {
                    response.Message = "User account does not exist!";
                    return response;
                }

                string hashedPassword = HashingHelper.HashPassword(request.Password, user.HashSalt);

                if (!user.PasswordHash.Equals(hashedPassword))
                {
                    response.Message = "Incorrect username or password!";
                    return response;
                }

                response.User = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    RoleName = user.Role.RoleName
                };
                response.Message = $"Welcome {user.UserName}";
                response.Status = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public BaseResponseModel Register(SignUpViewModel request, string roleName)
        {

            var response = new BaseResponseModel();
            string saltString = HashingHelper.GenerateSalt();
            string hashedPassword = HashingHelper.HashPassword(request.Password, saltString);
            var createdBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var userExist = _unitOfWork.Users.Exists(c => c.UserName == request.UserName);

            if (userExist)
            {
                response.Message = $"User with username {request.UserName} already exists!";
                return response;
            }

            roleName ??= "Pastry Shopper";

            var role = _unitOfWork.Roles.Get(r => r.RoleName == roleName);

            if (role is null)
            {
                response.Message = "Role does not exist!";
                return response;
            }

            var user = new User
            {
                UserName = request.UserName,
                HashSalt = saltString,
                PasswordHash = hashedPassword,
                RoleId = role.Id,
                CreatedBy = createdBy
            };

            try
            {
                _unitOfWork.Users.Create(user);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "You have successfully signed up on Missy's Pastrys";

                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponseModel
                {
                    Message = $"Unable to signup, an error occurred: {ex.Message}"
                };
            }
        }
    }
}
