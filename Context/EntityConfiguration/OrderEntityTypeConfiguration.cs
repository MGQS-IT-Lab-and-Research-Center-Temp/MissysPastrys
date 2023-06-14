using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MissysPastrys.Entities;

namespace MissysPastrys.Context.EntityConfiguration
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);


            builder.Property(o => o.FirstName)
                .IsRequired();

            builder.Property(o => o.LastName)
                .IsRequired();

            builder.Property(o => o.Email)
                .IsRequired();

            builder.Property(o => o.Address)
                .IsRequired();

            builder.Property(o => o.State)
                .IsRequired();

            builder.Property(o => o.PhoneNumber)
                .IsRequired();

            builder.Property(o => o.OrderTotal)
                .IsRequired();

            builder.HasOne(o => o.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder.Property(o => o.OrderPlacedDate)
                .IsRequired();

            builder.Property(o => o.OrderDeliveryDate)
                .IsRequired();

            builder.Property(o => o.Status)
                .IsRequired();

            builder.Property(o => o.ReferenceNumber)
                .IsRequired();

            builder.HasMany(o => o.Pastries)
                .WithOne(p => p.Order)
                .IsRequired();
        }
    }
}
