using MissysPastries.Models;

namespace MissysPastrys.Models.ShoppingCart
{
    public class ShoppingCartResponseModel : BaseResponseModel
    {
        public ShoppingCartViewModel ShoppingCart { get; set; }
    }

    public class ShoppingCartsResponseModel : BaseResponseModel
    {
        public List<ShoppingCartViewModel> ShoppingCart { get; set; }
    }
}
