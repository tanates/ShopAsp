using ExamAspPartTwo.Models.@interface;
using Microsoft.EntityFrameworkCore;

namespace ExamAspPartTwo.Models
{
    public class ShopCart
    {
        public readonly ApplicationDbContext _context;

        public ShopCart(ApplicationDbContext context)
        {
            this._context = context;
        }
        public string  ShopCartID { get; set; }
        public List<ShopCartItem> LisShopItems { get; set; }

        public static ShopCart GetProduct(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var contextService = service.GetService<ApplicationDbContext>();
            string shopCardId = session.GetString("CardId")??Guid.NewGuid().ToString();

            session.SetString("CardId", shopCardId);

            return new ShopCart(contextService) { ShopCartID= shopCardId };
        }


        public void AddToCart(ProductModel product )
        {
            _context.ShopCartItems.Add(new ShopCartItem
            {
                ShopCardId = ShopCartID,
                Product=product
            });

            _context.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return _context.ShopCartItems.Where(c => c.ShopCardId == ShopCartID).Include(c=>c.Product).ToList();
        }
        
    }
}
