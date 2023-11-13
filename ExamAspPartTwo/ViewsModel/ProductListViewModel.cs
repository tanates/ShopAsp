using ExamAspPartTwo.Models;

namespace ExamAspPartTwo.ViewsModel
{
    public class ProductListViewModel
    {
        public IEnumerable <ProductModel> ProductModels { get; set; }
        public string ProductCategory {  get; set; }
    }
}
