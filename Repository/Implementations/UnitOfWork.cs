using MissysPastrys.Context;
using MissysPastrys.Repository.Interfaces;

namespace MissysPastrys.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MissysPastrysDbContext _context;
        private bool _disposed = false;

        public IUserRepository Users { get; }
        public IPastryRepository Pastries { get; }
        public IRoleRepository Roles { get; }
        public ICategoryRepository Categories { get; }
        public IDeliveryRepository Deliveries { get; }
        public IOrderRepository Orders { get; }
        public IOrderDetailRepository OrderDetails { get; }
        public IReviewRepository Reviews { get; }

        public UnitOfWork(
            MissysPastrysDbContext context,
            IUserRepository userRepository,
            IPastryRepository pastryRepository,
            IRoleRepository roleRepository,
            ICategoryRepository categoryRepository,
            IDeliveryRepository deliveryRepository,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IReviewRepository reviewRepository)
        {
            _context = context;
            Users = userRepository;
            Pastries = pastryRepository;
            Roles = roleRepository;
            Categories = categoryRepository;
            Deliveries = deliveryRepository;
            Orders = orderRepository;
            OrderDetails = orderDetailRepository;
            Reviews = reviewRepository;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
