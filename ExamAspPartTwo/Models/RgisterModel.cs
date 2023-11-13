using System.ComponentModel.DataAnnotations;

namespace ExamAspPartTwo.Models
{
    public class RgisterModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя ")]
        [EmailAddress]
        public string Name { get; set; }


        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress]
        public string Email{ get; set; }

        [Required(ErrorMessage = "Не указан пороль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пороль не совпадает")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
    }
}
