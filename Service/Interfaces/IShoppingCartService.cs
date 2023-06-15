using MissysPastrys.Entities;

namespace MissysPastrys.Service.Interfaces
{
    public interface IShoppingCartService
    {
        public abstract ShoppingCart GetCart(IServiceProvider services);
        public void AddToCart(Pastry pastry, int amount);
        public int RemoveFromCart(Pastry pastry);
        public List<ShoppingCartItem> GetShoppingCartItems();
        public void ClearCart();
        public decimal GetShoppingCartTotal();
    }
}

