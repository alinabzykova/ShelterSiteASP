using ShelterSiteNET.Models;
using System.Text;
using System.Text.Json;

namespace ShelterSiteASP.Data
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private static List<Favorite> favorites = new List<Favorite>();

        public FavoriteRepository()
        {
            if (File.Exists("Data/favorites.json"))
            {
                string jsonString = File.ReadAllText("Data/favorites.json");
                favorites = JsonSerializer.Deserialize<List<Favorite>>(jsonString) ?? new List<Favorite>();
            }
        }

        public List<Favorite> GetAll()
        {
            return favorites;
        }

        public List<Favorite> GetByUserId(int userId)
        {
            return favorites.Where(f => f.UserId == userId).ToList();
        }

        public void Add(int userId, int animalId)
        {
            if (!favorites.Any(f => f.UserId == userId && f.AnimalId == animalId))
            {
                var favorite = new Favorite
                {
                    Id = favorites.Any() ? favorites.Max(f => f.Id) + 1 : 1,
                    UserId = userId,
                    AnimalId = animalId,
                    AddedAt = DateTime.Now
                };
                favorites.Add(favorite);
                SaveChanges();
            }
        }

        public void Remove(int userId, int animalId)
        {
            var favorite = favorites.FirstOrDefault(f => f.UserId == userId && f.AnimalId == animalId);
            if (favorite != null)
            {
                favorites.Remove(favorite);
                SaveChanges();
            }
        }

        public bool IsFavorite(int userId, int animalId)
        {
            return favorites.Any(f => f.UserId == userId && f.AnimalId == animalId);
        }

        private void SaveChanges()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            string jsonString = JsonSerializer.Serialize(favorites);
            File.WriteAllText("Data/favorites.json", jsonString);
        }
    }
}
