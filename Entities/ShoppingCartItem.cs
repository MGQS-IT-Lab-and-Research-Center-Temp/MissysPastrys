namespace MissysPastrys.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
        public Pastry Pastry { get; set; }
        public int Amount { get; set; }
        public  string ShoppingCartId { get; set; }
    }
}
