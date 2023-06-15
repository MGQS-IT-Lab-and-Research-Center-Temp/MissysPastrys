using MissysPastrys.Entities;
using MissysPastrys.Models;
using MissysPastrys.Models.Review;
using MissysPastrys.Repository.Interfaces;
using MissysPastrys.Service.Interfaces;
using System.Security.Claims;

namespace MissysPastrys.Service.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }
        public BaseResponseModel CreateReview(CreateReviewViewModel request)
        {

            var response = new BaseResponseModel();
            var createdBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var customerIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = _unitOfWork.Users.Get(customerIdClaim);

            if (user is null)
            {
                response.Message = "User not found!";
                return response;
            }

            var pastry = _unitOfWork.Pastries.Get(request.PastryId);

            if (pastry is null)
            {
                response.Message = "Pastry not found";
                return response;
            }

            var review = new Review
            {
                UserId = user.Id,
                User = user,
                PastryId = pastry.Id,
                Pastry = pastry,
                ReviewText = request.ReviewText,
                Rating = request.Rating
            };

            try
            {
                _unitOfWork.Reviews.Create(review);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Review created successfully...";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Could not create review: {ex.Message}";
                return response;
            }
        }

        public BaseResponseModel DeleteReview(string reviewId)
        {
            var response = new BaseResponseModel();
            var reviewExist = _unitOfWork.Reviews.Exists(r => r.Id == reviewId);
            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var customer = _unitOfWork.Users.Get(userIdClaim);

            if (!reviewExist)
            {
                response.Message = "Review does not exist!";
                return response;
            }

            var review = _unitOfWork.Reviews.Get(reviewId);

            if (review.UserId != userIdClaim)
            {
                response.Message = "You cannot delete this review!";
                return response;
            }

            review.IsDeleted = true;

            try
            {
                _unitOfWork.Reviews.Update(review);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Review deleted successfully...";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Failed to delete review: {ex.Message}";
                return response;
            }
        }

        public ReviewsResponseModel GetAllReview()
        {
            var response = new ReviewsResponseModel();
            var review = _unitOfWork.Reviews.GetAll(r => r.IsDeleted == false);

            if (review.Count == 0)
            {
                response.Message = "Be the first to review this pastry";
                return response;
            }

            response.Review = review
                    .Select(review => new ReviewViewModel
                    {
                        Id = review.Id,
                        PastryId = review.PastryId,
                        UserId = review.UserId,
                        ReviewText = review.ReviewText,
                        Rating = review.Rating
                    }).ToList();

            response.Status = true;
            response.Message = "Success";

            return response;
        }

        public ReviewResponseModel GetReview(string reviewId)
        {

            var response = new ReviewResponseModel();
            var reviewExist = _unitOfWork.Reviews.Exists(r =>
                                (r.Id == reviewId)
                                && (r.Id == reviewId
                                && r.IsDeleted == false));

            if (!reviewExist)
            {
                response.Message = "Review does not exist!";
                return response;
            }

            var review = _unitOfWork.Reviews.Get(reviewId);

            response.Review = new ReviewViewModel
            {
                Id = review.Id,
                PastryId = review.PastryId,
                UserId = review.UserId,
                ReviewText = review.ReviewText,
                Rating = review.Rating
            };
            response.Message = "Success";
            response.Status = true;

            return response;
        }

        public BaseResponseModel UpdateReview(UpdateReviewViewModel request, string reviewId)
        {
            var response = new BaseResponseModel();
            var modifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var reviewExist = _unitOfWork.Reviews.Exists(r => r.Id == reviewId);
            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var customer = _unitOfWork.Users.Get(userIdClaim);

            if (!reviewExist)
            {
                response.Message = "Review does not exist!";
                return response;
            }

            var review = _unitOfWork.Reviews.Get(reviewId);

            if (review.UserId != userIdClaim)
            {
                response.Message = "You cannot update this review!";
                return response;
            }

            review.ReviewText = request.ReviewText;
            review.Rating = request.Rating;
            review.ModifiedBy = modifiedBy;

            try
            {
                _unitOfWork.Reviews.Update(review);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = $"Review updated successfully";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Could not update this review: {ex.Message}";
                return response;
            }
        }
    }
}
