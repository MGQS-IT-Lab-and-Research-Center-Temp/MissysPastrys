namespace MissysPastrys.Entities
{
    public class PastryCategory : BaseEntity
    {
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string PastryId { get; set; }
        public Pastry Pastry { get; set; }
    }
}
