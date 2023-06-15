using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MissysPastrys.Entities;

namespace MissysPastrys.Context.EntityConfiguration
{
    public class DeliveryEntityTypeConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {

            builder.ToTable("Deliveries");

            builder.HasKey(d => d.Id);

            //builder.Property(d => d.ShoppingCart)
            //    .IsRequired();

            builder.Property(d => d.DeliveryGroup)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(d => d.Status)
                .HasConversion<short>();

            builder.Property(d => d.DeliveryAddress)
                .IsRequired();
        }
    }
}
