namespace MissysPastrys.Entities
{
    public class Pastry : BaseEntity
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal CostPrice { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<PastryCategory> PastryCategories { get; set; } = new HashSet<PastryCategory>();
    }
}
