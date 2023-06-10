using MassTransit;
using MissysPastrys.Enum;

namespace MissysPastrys.Entities
{
    public class Order : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlacedDate { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public string ReferenceNumber { get; set; } = NewId.Next().ToSequentialGuid().ToString();
        public ICollection<Pastry> Pastries { get; set; } = new HashSet<Pastry>();
    }
}
