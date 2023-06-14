using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MissysPastrys.Entities;

namespace MissysPastrys.Context.EntityConfiguration
{
    public class PastryCategoryEntityTypeConfiguration : IEntityTypeConfiguration<PastryCategory>
    {
        public void Configure(EntityTypeBuilder<PastryCategory> builder)
        {
            builder.ToTable("PastryCategories");

            builder.Ignore(pc => pc.Id);

            builder.HasKey(pc => new { pc.PastryId, pc.CategoryId });

            builder.HasOne(p => p.Pastry)
                .WithMany(pc => pc.PastryCategories)
                .HasForeignKey(p => p.PastryId)
                .IsRequired();

            builder.HasOne(c => c.Category)
                .WithMany(pc => pc.PastryCategories)
                .HasForeignKey(c => c.CategoryId)
                .IsRequired();
        }
    }
}
