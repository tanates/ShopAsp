﻿namespace ExamAspPartTwo.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Price { get; set; }
        public virtual ProductModel Product { get; set; }
        public virtual Order Order { get; set;}
        
    }
}