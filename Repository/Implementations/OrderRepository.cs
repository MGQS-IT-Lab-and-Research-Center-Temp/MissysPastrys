using MissysPastrys.Context;
using MissysPastrys.Entities;
using MissysPastrys.Repository.Interfaces;

namespace MissysPastrys.Repository.Implementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(MissysPastrysDbContext context) : base(context)
        {
        }
    }
}
