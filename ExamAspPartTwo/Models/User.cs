using System.Data;

namespace ExamAspPartTwo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string  Password { get; set; }
        public  ICollection< Role >role { get; set; }

    }
}
