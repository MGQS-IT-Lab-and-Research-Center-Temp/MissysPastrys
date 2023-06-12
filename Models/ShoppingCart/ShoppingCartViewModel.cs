using MissysPastrys.Entities;

namespace MissysPastrys.Models.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public string Id { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
