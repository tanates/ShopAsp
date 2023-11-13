using Microsoft.EntityFrameworkCore;

namespace ExamAspPartTwo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders {  get; set; }
        public DbSet<OrderDetail>OrderDetails  { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
    }
}
