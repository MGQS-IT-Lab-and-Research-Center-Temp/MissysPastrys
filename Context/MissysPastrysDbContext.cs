using Microsoft.EntityFrameworkCore;
using MissysPastrys.Entities;
using System.Reflection;

namespace MissysPastrys.Context
{
    public class MissysPastrysDbContext : DbContext
    {
        public MissysPastrysDbContext(DbContextOptions<MissysPastrysDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) => builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        public DbSet<Category> Categories { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Pastry> Pastries { get; set; }
        public DbSet<PastryCategory> PastryCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
