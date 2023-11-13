namespace ExamAspPartTwo.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public string NameProduct { get; set; }
        public string Price { get; set; }

        public  virtual Category Category { get; set; }
    }
}
