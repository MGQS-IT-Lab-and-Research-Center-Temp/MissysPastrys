using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MissysPastrys.Entities;

namespace MissysPastrys.Context.EntityConfiguration
{
    public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {

            builder.ToTable("Reviews");

            builder.HasKey(re => re.Id);

            builder.Property(re => re.ReviewText)
                .HasColumnType("text")
                .HasMaxLength(500);

            builder.HasOne(re => re.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(re => re.UserId)
                .IsRequired();

            builder.HasOne(re => re.Pastry)
                .WithMany(p => p.Reviews)
                .HasForeignKey(re => re.PastryId)
                .IsRequired();

            builder.Property(re => re.Rating)
                .HasConversion<short>();
        }
    }
}
