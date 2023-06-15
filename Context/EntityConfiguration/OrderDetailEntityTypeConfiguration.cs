using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MissysPastrys.Entities;

namespace MissysPastrys.Context.EntityConfiguration
{
    public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {

            builder.ToTable("OrderDetailss");

            builder.HasKey(od => od.Id);

            //builder.Property(od => od.Pastry)
            //    .IsRequired();

            builder.Property(od => od.Amount)
                .IsRequired();

            //builder.Property(od => od.Order)
            //    .IsRequired();

            builder.Property(od => od.SellingPrice)
                .IsRequired();

            builder.Property(od => od.CostPrice)
                .IsRequired();
        }
    }
}
