using MissysPastrys.Models;
using MissysPastrys.Models.Review;

namespace MissysPastrys.Service.Interfaces
{
    public interface IReviewService
    {

        BaseResponseModel CreateReview(CreateReviewViewModel request);
        BaseResponseModel DeleteReview(string reviewId);
        BaseResponseModel UpdateReview(UpdateReviewViewModel request, string reviewId);
        ReviewResponseModel GetReview(string reviewId);
        ReviewsResponseModel GetAllReview();
    }
}
