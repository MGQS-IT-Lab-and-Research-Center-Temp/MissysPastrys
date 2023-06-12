using MissysPastrys.Enum;
using System.ComponentModel.DataAnnotations;

namespace MissysPastries.Models.Review
{
    public class CreateReviewViewModel
    {
        public string UserId { get; set; }
        public string PastryId { get; set; }
        public Ratings Rating { get; set; }

        [MinLength(20, ErrorMessage ="Minimum of 20 characters required")]
        [MaxLength(500, ErrorMessage = "Maximum of 500 characters required")]
        public string ReviewText { get; set; }
    }
}
