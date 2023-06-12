using MissysPastries.Models;
using MissysPastrys.Entities;
using MissysPastrys.Models.ShoppingCartItem;

namespace MissysPastrys.Service.Interfaces
{
    public interface IShoppingCartService
    {
        BaseResponseModel GetCart(IServiceProvider services);
        BaseResponseModel AddToCart(Pastry pastry, int amount);
        BaseResponseModel RemoveFromCart(Pastry pastry);
        ShoppingCartItemsResponseModel GetShoppingCartItems();
        BaseResponseModel ClearCart();
        public decimal GetShoppingCartTotal();
    }
}

