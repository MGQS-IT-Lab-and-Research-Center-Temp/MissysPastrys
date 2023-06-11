using MissysPastrys.Entities;
using System.Linq.Expressions;

namespace MissysPastrys.Repository.Interfaces
{
    public interface IPastryRepository : IBaseRepository<Pastry>
    {
        List<Pastry> GetPastries();
        List<Pastry> GetPastries(Expression<Func<Pastry, bool>> expression);
        Pastry GetPastry(Expression<Func<Pastry, bool>> expression);
        List<PastryCategory> GetPastryByCategoryId(string categoryId);
        List<PastryCategory> SelectPastryByCategory();
    }
}

