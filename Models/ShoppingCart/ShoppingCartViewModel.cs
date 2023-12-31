﻿using MissysPastrys.Models.ShoppingCartItem;

namespace MissysPastrys.Models.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public ShoppingCartViewModel ShoppingCart { get; set; }
    }
}
