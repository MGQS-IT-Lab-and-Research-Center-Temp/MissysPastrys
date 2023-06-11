using MissysPastrys.Context;
using MissysPastrys.Entities;
using MissysPastrys.Repository.Interfaces;

namespace MissysPastrys.Repository.Implementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MissysPastrysDbContext context) : base(context)
        {
        }
    }
}
