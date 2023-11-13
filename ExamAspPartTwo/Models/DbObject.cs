namespace ExamAspPartTwo.Models
{
    public class DbObject
    {
        public static void Initial(ApplicationDbContext context) 
        {
            if (!context.Categories.Any())
                context.Categories.AddRange(Categories.Select(c => c.Value));
            if (!context.Products.Any())
            {
                context.AddRange(
                       new ProductModel
                       {
                           NameProduct="Tesla Model S",
                           Img="/img/tesla.jpg",
                           Price ="45000",
                           Category = Categories["Электоромобиль"]

                       },
                       new ProductModel
                       {
                           NameProduct = " Toyota Camry",
                           Img = "/img/ToyotaCamry.jpg",
                           Price = "45000",
                           Category = Categories["Классичиский автомабиль"]

                       },
                       new ProductModel
                       {
                           NameProduct = "BMW M6",
                           Img = "/img/BMWM6.jpg",
                           Price = "45000",
                           Category = Categories["Классичиский автомабиль"]

                       }

                    );
                context.SaveChanges();
            }

        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string,Category> Categories
        {
            get
            {
                if (category==null)
                {
                    var list = new Category[]
                    {
                        new Category  {CategoryName="Электоромобиль"},
                        new Category  {CategoryName="Классичиский автомабиль"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (var item in list)
                    {
                        category.Add(item.CategoryName, item);
                    }
                }
                return category;
            }
        }
    }
}
