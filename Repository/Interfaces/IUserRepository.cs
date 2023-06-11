using MissysPastrys.Entities;
using MissysPastrys.Repository.Interfaces;
using System.Linq.Expressions;

namespace MissysPastrys.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUser(Expression<Func<User, bool>> expression);
        User GetByUsername(string username);
    }
}