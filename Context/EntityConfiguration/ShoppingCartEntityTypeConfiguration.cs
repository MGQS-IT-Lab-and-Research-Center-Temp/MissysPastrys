using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MissysPastrys.Entities;

namespace MissysPastrys.Context.EntityConfiguration
{
    public class ShoppingCartEntityTypeConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCart");

            builder.HasKey(sc => sc.ShoppingCartId);

            builder.HasMany(sc => sc.ShoppingCartItems)
                    .WithOne(sci => sci.ShoppingCart)
                    .IsRequired();
        }
    }
}
