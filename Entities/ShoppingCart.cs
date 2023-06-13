using MissysPastrys.Context;

namespace MissysPastrys.Entities
{
    public class ShoppingCart
    {
        private readonly MissysPastrysDbContext _missysPastrysDbContext;
        public ShoppingCart(MissysPastrysDbContext missysPastrysDbContext)
        {
            _missysPastrysDbContext = missysPastrysDbContext;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
