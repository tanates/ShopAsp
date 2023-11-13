namespace ExamAspPartTwo.Models.@interface
{
    public interface IProduct
    {
        IEnumerable<ProductModel> Products { get;}
         ProductModel GetProduct (int  id);
    }
}
