namespace ExamAspPartTwo.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City {  get; set; }
        public string Adress{ get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
