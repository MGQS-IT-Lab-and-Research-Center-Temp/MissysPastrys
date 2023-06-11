using MissysPastrys.Context;
using MissysPastrys.Entities;
using MissysPastrys.Repository.Interfaces;

namespace MissysPastrys.Repository.Implementations
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(MissysPastrysDbContext context) : base(context)
        {
        }
    }
}
