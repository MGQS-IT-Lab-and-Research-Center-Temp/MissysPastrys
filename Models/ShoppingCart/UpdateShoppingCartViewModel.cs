using MissysPastrys.Models.ShoppingCartItem;

namespace MissysPastrys.Models.ShoppingCart
{
    public class UpdateShoppingCartViewModel
    {
        public string Id { get; set; }
        public List<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }
    }
}
