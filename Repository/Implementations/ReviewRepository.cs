using Microsoft.EntityFrameworkCore;
using MissysPastrys.Context;
using MissysPastrys.Entities;
using MissysPastrys.Repository.Interfaces;

namespace MissysPastrys.Repository.Implementations
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MissysPastrysDbContext context) : base(context)
        {
        }

        public List<Review> GetReviewsByProductId(string productId)
        {

            var reviews = _context.Reviews
                .Include(r => r.User)
                .Where(r => r.UserId.Equals(productId))
                .ToList();

            return reviews;
        }
    }
}
