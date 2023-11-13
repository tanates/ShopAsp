namespace ExamAspPartTwo.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<ProductModel> productModels { get; set; }
    }
}
