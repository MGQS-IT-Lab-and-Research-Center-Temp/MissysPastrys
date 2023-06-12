using MissysPastrys.Entities;

namespace MissysPastrys.Models.ShoppingCart
{
    public class UpdateShoppingCartViewModel
    {
        public string Id { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
