using System.ComponentModel.DataAnnotations;

namespace ExamAspPartTwo.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Не указан пороль")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
