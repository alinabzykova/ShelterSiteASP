using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShelterSiteNET.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Слишком длинное имя")]
        public string Name { get; set; } = "Неназванный";

        [Required]
        public string Type { get; set; } = "Собака";

        [StringLength(30)]
        public string Breed { get; set; } = "Дворняжка";

        [Required]
        [Range(0, 50)]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; } = "Не указан";

        public string Size { get; set; } = "Medium";

        public string Status { get; set; } = "Available";

        public string Description { get; set; } =
            "Питомец ищет друга!";

        public List<string> Images { get; set; } = new List<string>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
    }
}