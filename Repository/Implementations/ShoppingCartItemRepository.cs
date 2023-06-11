using MissysPastrys.Context;
using MissysPastrys.Entities;
using MissysPastrys.Repository.Interfaces;

namespace MissysPastrys.Repository.Implementations
{
    public class ShoppingCartItemRepository : BaseRepository<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(MissysPastrysDbContext context) : base(context)
        {
        }
    }
}
