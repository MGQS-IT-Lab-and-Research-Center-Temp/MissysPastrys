﻿using MissysPastrys.Enum;
using MissysPastrys.Models.ShoppingCartItem;

namespace MissysPastrys.Models.Delivery
{
    public class DeliveryViewModel
    {
        public string Id { get; set; }
        public string ShoppingCartItemId { get; set; }
        public ShoppingCartItemViewModel ShoppingCartItem { get; set; }
        public string DeliveryGroup { get; set; }
        public DeliveryStatus Status { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
