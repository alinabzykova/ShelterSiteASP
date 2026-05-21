using System.ComponentModel.DataAnnotations;

namespace ShelterSiteASP.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите email")]
        [EmailAddress(ErrorMessage = "Неверный формат email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен быть не менее 6 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
