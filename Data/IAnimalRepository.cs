using ShelterSiteNET.Models;

namespace ShelterSiteASP.Data
{
    public interface IAnimalRepository
    {
        List<Animal> GetAll();
        Animal? GetById(int id);
        void Add(Animal animal);
        void Update(Animal animal);
        void Delete(int id);
    }
}
