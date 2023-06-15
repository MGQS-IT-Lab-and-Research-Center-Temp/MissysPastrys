using MissysPastrys.Enum;

namespace MissysPastrys.Models.Review
{
    public class ReviewViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PastryId { get; set; }
        public string ReviewText { get; set; }
        public Ratings Rating { get; set; }
    }
}
