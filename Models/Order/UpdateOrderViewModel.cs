using MissysPastrys.Models.OrderDetail;

namespace MissysPastrys.Models.Order
{
    public class UpdateOrderViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlacedDate { get; set; }
        public List<OrderDetailViewModel> OrderLine { get; set; }
    }
}
