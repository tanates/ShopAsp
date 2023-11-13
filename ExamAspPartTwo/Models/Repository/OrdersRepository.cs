namespace ExamAspPartTwo.Models.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly  ApplicationDbContext _context;
        private readonly ShopCart _shopCart;

        public OrdersRepository(ApplicationDbContext context, ShopCart shopCart)
        {
            _context = context;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _context.Orders.Add(order);

            var items = _shopCart.LisShopItems;
            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductId = item.Product.Id,
                    OrderId = order.Id,
                    Price = item.Product.Price,
                };
                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();
        }

    }
}
