﻿namespace ExamAspPartTwo.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int User_Id { get; set; }
        public User User { get; set; }
    }
}