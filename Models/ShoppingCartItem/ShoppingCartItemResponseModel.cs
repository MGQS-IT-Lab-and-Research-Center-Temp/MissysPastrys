using MissysPastries.Models;

namespace MissysPastrys.Models.ShoppingCartItem
{
    public class ShoppingCartItemResponseModel : BaseResponseModel
    {
        public ShoppingCartItemViewModel ShoppingCartItem { get; set; }
    }

    public class ShoppingCartItemsResponseModel : BaseResponseModel
    {
        public List<ShoppingCartItemViewModel> ShoppingCartItem { get; set; }
    }
}
