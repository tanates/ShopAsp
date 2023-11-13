using ExamAspPartTwo.Models.@interface;
using Microsoft.EntityFrameworkCore;

namespace ExamAspPartTwo.Models.Repository
{
    public class ProductRepository : IProduct

    {
        public readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductModel> Products => context.Products.Include(c=>c.Category);
  
        ProductModel IProduct.GetProduct(int id) => context.Products.FirstOrDefault(c => c.Id == id);

    }
}
