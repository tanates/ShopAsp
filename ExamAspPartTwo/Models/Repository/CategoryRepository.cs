namespace ExamAspPartTwo.Models.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            this._context = context;
        } 
        public IEnumerable<Category> AllCategories => _context.Categories ;
    }
}
