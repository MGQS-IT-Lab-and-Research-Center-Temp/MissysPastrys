using MissysPastrys.Enum;

namespace MissysPastrys.Entities
{
    public class Delivery : BaseEntity
    {
        public string ShoppingCartItemId { get; set; }
        public ShoppingCartItem ShoppingCartItem { get; set; }
        public string DeliveryGroup { get; set; }
        public DeliveryStatus Status { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
