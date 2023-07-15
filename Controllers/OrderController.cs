using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissysPastrys.Entities;
using MissysPastrys.Models.Order;
using MissysPastrys.Service.Interfaces;

namespace MissysPastrys.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly INotyfService _notyf;

        public OrderController(IOrderService orderService, IShoppingCartService shoppingCartService, INotyfService notyfService)
        {
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
            _notyf = notyfService;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCartService.GetShoppingCartItems();
            _shoppingCartService.ShoppingCartItems = items;

            if (_shoppingCartService.ShoppingCartItems.Count == 0)
            {
                _notyf.Error("Your cart is empty, add some pastries first");
                return View();
            }

            if (ModelState.IsValid)
            {
                _orderService.CreateOrder(order);
                _shoppingCartService.ClearCart();

                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order!";
            return View();
        }
    }
}
