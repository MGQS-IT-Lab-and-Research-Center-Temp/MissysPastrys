using Microsoft.EntityFrameworkCore;
using MissysPastrys.Context;
using MissysPastrys.Entities;
using MissysPastrys.Repository.Interfaces;
using System.Linq.Expressions;

namespace MissysPastrys.Repository.Implementations
{
    public class PastryRepository : BaseRepository<Pastry>, IPastryRepository
    {
        public PastryRepository(MissysPastrysDbContext context) : base(context)
        {
        }

        public List<Pastry> GetPastries()
        {
            var pastries = _context.Pastries
                .Include(p => p.Reviews)
                .ThenInclude(r => r.User)
                .Include(p => p.ImageUrl)
                .ToList();

            return pastries;
        }

        public List<Pastry> GetPastries(Expression<Func<Pastry, bool>> expression)
        {

            var pastries = _context.Pastries
               .Where(expression)
               .Include(p => p.ImageUrl)
               .Include(p => p.Reviews)
               .ThenInclude(r => r.User)
               .ToList();

            return pastries;
        }

        public Pastry GetPastry(Expression<Func<Pastry, bool>> expression)
        {
            var pastry = _context.Pastries
                .Include(p => p.Reviews)
                .ThenInclude(c => c.User)
                .Include(p => p.ImageUrl)
                .SingleOrDefault(expression);

            return pastry;
        }

        public List<PastryCategory> GetPastryByCategoryId(string categoryId)
        {

            var pastries = _context.PastryCategories
                .Include(c => c.Category)
                .Include(p => p.Pastry)
                .Where(p => p.CategoryId.Equals(categoryId))
                .ToList();

            return pastries;
        }

        public List<PastryCategory> SelectPastryByCategory()
        {
            var pastries = _context.PastryCategories
                .Include(p => p.Category)
                .Include(c => c.Pastry)
                .ToList();

            return pastries;
        }
    }
}
