using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MissysPastrys.Entities;

namespace MissysPastrys.Context.EntityConfiguration
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CategoryName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(c => c.CategoryName)
                .IsUnique();

            builder.Property(c => c.Description)
                .HasMaxLength(500);

            builder.HasMany(c => c.PastryCategories)
                .WithOne(pc => pc.Category)
                .IsRequired();
        }
    }
}
