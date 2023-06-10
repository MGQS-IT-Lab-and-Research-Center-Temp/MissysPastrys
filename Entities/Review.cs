using MissysPastrys.Enum;

namespace MissysPastrys.Entities
{
    public class Review : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string PastryId { get; set; }
        public Pastry Pastry { get; set; }
        public string ReviewText { get; set; }
        public Ratings Rating { get; set; }
    }
}
