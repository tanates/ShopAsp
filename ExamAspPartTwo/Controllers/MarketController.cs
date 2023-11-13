using ExamAspPartTwo.Models;
using ExamAspPartTwo.Models.@interface;
using ExamAspPartTwo.ViewsModel;
using Microsoft.AspNetCore.Mvc;

namespace ExamAspPartTwo.Controllers
{
    public class MarketController : Controller
    {
        private ApplicationDbContext db;
        private readonly IProduct _product;
        private readonly ICategory _category;
        public MarketController(  ApplicationDbContext context , IProduct product,ICategory category)
        {
            this.db = context;
            this._category= category;
            this._product = product; 
        }

        public IActionResult Product()
        {
            ProductListViewModel obj = new ProductListViewModel();
            obj.ProductModels = this._product.Products;
            obj.ProductCategory = "продукты";
            return View(obj);
        }

      
    }
}
