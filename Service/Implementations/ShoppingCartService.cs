using Microsoft.EntityFrameworkCore;
using MissysPastrys.Context;
using MissysPastrys.Entities;
using MissysPastrys.Models.ShoppingCartItem;
using MissysPastrys.Service.Interfaces;

namespace MissysPastrys.Service.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly MissysPastrysDbContext _missysPastrysDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCartService(MissysPastrysDbContext missysPastrysDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _missysPastrysDbContext = missysPastrysDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public void AddToCart(Pastry pastry, int amount)
        {
            var shoppingCartItem = _missysPastrysDbContext.ShoppingCartItems.SingleOrDefault(s => s.Pastry.Id == pastry.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem is null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pastry = pastry,
                    Amount = 1
                };

                _missysPastrysDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }

            shoppingCartItem.Amount++;
            _missysPastrysDbContext.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = _missysPastrysDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _missysPastrysDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _missysPastrysDbContext.SaveChanges();
        }

        public ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = _httpContextAccessor.HttpContext.Session;
            var context = services.GetRequiredService<MissysPastrysDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _missysPastrysDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Pastry)
                .ToList());
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _missysPastrysDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Pastry.SellingPrice * c.Amount).Sum();

            return total;
        }

        public int RemoveFromCart(Pastry pastry)
        {
            var shoppingCartItem = _missysPastrysDbContext.ShoppingCartItems.SingleOrDefault(s => s.Pastry.Id == pastry.Id && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }

                _missysPastrysDbContext.ShoppingCartItems.Remove(shoppingCartItem);
            }

            _missysPastrysDbContext.SaveChanges();
            return localAmount;
        }
    }
}
