using ExamAspPartTwo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamAspPartTwo.Controllers
{
    public class OrderController : Controller
    {

        public readonly IAllOrders _allOrders;
        public readonly ShopCart _shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            _allOrders = allOrders;
            _shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }
    }
}
