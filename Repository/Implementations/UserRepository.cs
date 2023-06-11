using Microsoft.EntityFrameworkCore;
using MissysPastrys.Context;
using MissysPastrys.Entities;
using MissysPastrys.Repository.Interfaces;
using System.Linq.Expressions;

namespace MissysPastrys.Repository.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MissysPastrysDbContext context) : base(context)
        {
        }

        public User GetByUsername(string username)
        {

            return _context.Users.SingleOrDefault(c => c.UserName == username);
        }

        public User GetUser(Expression<Func<User, bool>> expression)
        {
            return _context.Users
                .Include(u => u.Role)
                .SingleOrDefault(expression);
        }
    }
}
