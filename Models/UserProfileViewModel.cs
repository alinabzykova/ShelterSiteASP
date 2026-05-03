using System.Collections.Generic;

namespace ShelterSiteNET.Models
{
    public class UserProfileViewModel
    {
        public User User { get; set; } = new User();

        public List<Animal> FavoriteAnimals { get; set; } = new List<Animal>();
    }
}