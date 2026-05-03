using System;

namespace ShelterSiteNET.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int AnimalId { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.Now;
    }
}