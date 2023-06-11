﻿namespace MissysPastrys.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IPastryRepository Pastries { get; }
        IRoleRepository Roles { get; }
        ICategoryRepository Categories { get; }
        IDeliveryRepository Deliveries { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get; }
        IShoppingCartItemRepository ShoppingCartItems { get; }
        IShoppingCartRepository ShoppingCarts { get; }
        IReviewRepository Reviews { get; }
        int SaveChanges();
    }
}
