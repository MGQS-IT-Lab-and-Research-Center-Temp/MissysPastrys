namespace MissysPastrys.Models.Review
{
    public class ReviewResponseModel : BaseResponseModel
    {
        public ReviewViewModel Review { get; set; }
    }

    public class ReviewsResponseModel : BaseResponseModel
    {
        public List<ReviewViewModel> Review { get; set; }
    }
}
