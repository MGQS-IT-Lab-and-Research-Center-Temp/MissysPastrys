using MissysPastries.Helper;
using MissysPastrys.Entities;

namespace MissysPastrys.Context
{
    internal class DbInitializer
    {
        internal static void Initialize(MissysPastrysDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            context.Database.EnsureCreated();

            if (context.Roles.Any())
            {
                return;
            }

            var roles = new Role[]
            {
                new Role()
                {
                    RoleName = "Admin",
                    Description = "Role for site administrator",
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                    ModifiedBy = "",
                    LastModified = new DateTime()
                },
                new Role()
                {
                    RoleName = "Pastry Shopper",
                    Description = "Role for site user",
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                    ModifiedBy = "",
                    LastModified = new DateTime()
                }
            };

            foreach (var role in roles)
            {
                context.Roles.Add(role);
            }

            context.SaveChanges();

            var password = "password@1";
            var salt = HashingHelper.GenerateSalt();
            var admin = context.Roles.Where(r => r.RoleName == "Admin").SingleOrDefault();

            var users = new User[]
            {
                new User()
                {
                    UserName = "Admin",
                    HashSalt = salt,
                    PasswordHash = HashingHelper.HashPassword(password, salt),
                    RoleId = admin.Id,
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                    ModifiedBy = "",
                    LastModified = new DateTime()
                }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
