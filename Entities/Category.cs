namespace MissysPastrys.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<PastryCategory> PastryCategories { get; set; } = new HashSet<PastryCategory>();
    }
}
