namespace MissysPastrys.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string HashSalt { get; set; }
        public string PasswordHash { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
