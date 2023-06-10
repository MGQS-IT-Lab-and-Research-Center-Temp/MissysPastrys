namespace MissysPastrys.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItem>();
    }
}
