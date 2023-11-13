using ExamAspPartTwo.Models;
using ExamAspPartTwo.Models.@interface;
using ExamAspPartTwo.Models.Repository;
using ExamAspPartTwo.ViewsModel;
using Microsoft.AspNetCore.Mvc;

namespace ExamAspPartTwo.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IProduct _productRepository;
        private readonly ShopCart _shopCart;
        private readonly ApplicationDbContext _db;

        public ShopCartController(IProduct productRepository, ShopCart shopCart, ApplicationDbContext context)
        {
            _productRepository = productRepository;
            this._shopCart = shopCart;
            _db = context;
        }

        public IActionResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.LisShopItems = items;

            var obj = new ShopCartVIewModel
            {
                ShopCart = _shopCart
            };
            return View(obj);
        }
       
        public RedirectToActionResult AddToCart(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var item = _productRepository.Products.FirstOrDefault(x => x.Id == id);
                if (item != null)
                {
                    _shopCart.AddToCart(item);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Account");
           
        }
    }
}
