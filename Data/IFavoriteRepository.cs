using ShelterSiteNET.Models;

namespace ShelterSiteASP.Data
{
    public interface IFavoriteRepository
    {
        List<Favorite> GetByUserId(int userId);
        void Add(int userId, int animalId);
        void Remove(int userId, int animalId);
        bool IsFavorite(int userId, int animalId);
    }
}
