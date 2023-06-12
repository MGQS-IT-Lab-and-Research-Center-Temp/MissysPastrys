using MissysPastrys.Enum;
using MissysPastrys.Models.ShoppingCartItem;

namespace MissysPastrys.Models.Delivery
{
    public class CreateDeliveryViewModel
    {
        public string ShoppingCartItemId { get; set; }
        public ShoppingCartItemViewModel ShoppingCartItem { get; set; }
        public string DeliveryGroup { get; set; }
        public DeliveryStatus Status { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
