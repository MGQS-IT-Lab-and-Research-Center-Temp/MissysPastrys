using MissysPastrys.Context;
using MissysPastrys.Entities;
using MissysPastrys.Service.Interfaces;

namespace MissysPastrys.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly MissysPastrysDbContext _missysPastrysDbContext;

        public OrderService(ShoppingCart shoppingCart, MissysPastrysDbContext missysPastrysDbContext)
        {
            _shoppingCart = shoppingCart;
            _missysPastrysDbContext = missysPastrysDbContext;
        }

        public void CreateOrder(Order order)
        {

            order.OrderPlacedDate = DateTime.Now;
            _missysPastrysDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    PastryId = shoppingCartItem.Pastry.Id,
                    OrderId = order.Id,
                    SellingPrice = shoppingCartItem.Pastry.SellingPrice
                };

                _missysPastrysDbContext.OrderDetails.Add(orderDetail);
            }

            _missysPastrysDbContext.SaveChanges();
        }
    }
}
