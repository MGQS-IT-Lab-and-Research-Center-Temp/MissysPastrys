using MissysPastrys.Context;
using MissysPastrys.Entities;
using MissysPastrys.Repository.Interfaces;

namespace MissysPastrys.Repository.Implementations
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(MissysPastrysDbContext context) : base(context)
        {
        }
    }
}
