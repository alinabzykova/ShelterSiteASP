using System.ComponentModel.DataAnnotations;

namespace ShelterSiteNET.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Логин слишком длинный")]
        public string Login { get; set; } = "";

        [Required]
        [StringLength(100, ErrorMessage = "Пароль слишком длинный")]
        public string Password { get; set; } = "";

        [StringLength(200)]
        public string? Description { get; set; } = "Любитель животных 🐶";
    }
}