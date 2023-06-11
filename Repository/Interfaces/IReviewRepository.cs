using MissysPastrys.Entities;

namespace MissysPastrys.Repository.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        List<Review> GetReviewsByProductId(string productId);
    }
}
