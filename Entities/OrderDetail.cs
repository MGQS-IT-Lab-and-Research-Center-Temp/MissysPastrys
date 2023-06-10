namespace MissysPastrys.Entities
{
    public class OrderDetail : BaseEntity
    {
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string PastryId { get; set; }
        public virtual Pastry Pastry { get; set; }
        public int Amount { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
