using MissysPastrys.Enum;

namespace MissysPastrys.Entities
{
    public class Delivery : BaseEntity
    {
        public string ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public string DeliveryGroup { get; set; }
        public DeliveryStatus Status { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
