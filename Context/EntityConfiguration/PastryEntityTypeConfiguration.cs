using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MissysPastrys.Entities;

namespace MissysPastrys.Context.EntityConfiguration
{
    public class PastryEntityTypeConfiguration : IEntityTypeConfiguration<Pastry>
    {
        public void Configure(EntityTypeBuilder<Pastry> builder)
        {

            builder.ToTable("Pastries");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(p => p.Name)
                .IsUnique();

            builder.Property(p => p.SellingPrice)
                .IsRequired();

            builder.Property(p => p.CostPrice)
                .IsRequired();

            builder.Property(p => p.LongDescription)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.ImageUrl)
                .HasColumnType("varchar(255)");

            builder.Property(p => p.ShortDescription)
                .HasColumnType("text")
                .IsRequired();

            builder.HasMany(p => p.Reviews)
                .WithOne(r => r.Pastry)
                .IsRequired();

            builder.HasMany(p => p.PastryCategories)
                .WithOne(pc => pc.Pastry)
                .IsRequired();

            builder.HasOne(p => p.Order)
                .WithMany(o => o.Pastries)
                .HasForeignKey(p => p.OrderId)
                .IsRequired();
        }
    }
}
