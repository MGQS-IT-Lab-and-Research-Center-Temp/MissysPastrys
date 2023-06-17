using MissysPastrys.Models.Review;

namespace MissysPastrys.Models.Pastry
{
    public class PastryViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
        public string ShortDescription { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public decimal SellingPrice { get; set; }
        //public List<string> Categories { get; set; } = new List<string>();
        public List<ReviewViewModel> Reviews { get; set; }
    }
}
