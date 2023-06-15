using MissysPastrys.Enum;
using System.ComponentModel.DataAnnotations;

namespace MissysPastrys.Models.Review
{
    public class UpdateReviewViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PastryId { get; set; }

        [Required(ErrorMessage ="Review text is required")]
        [MinLength(20, ErrorMessage ="You are only allowed to enter a minimum of 20 characters")]
        [MaxLength(500, ErrorMessage ="You cannot enter more than 500 characters")]
        public string ReviewText { get; set; }
        public Ratings Rating { get; set; }
    }
}
