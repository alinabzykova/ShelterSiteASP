using ShelterSiteNET.Models;
using System.Text.Json;
using System.Xml.Linq;

namespace ShelterSiteASP.Data
{
    public class AnimalRepository : IAnimalRepository
    {
        private static List<Animal> animals = new List<Animal>();

        public AnimalRepository()
        {
            string jsonString = File.ReadAllText("Data/animals.json");
            animals = JsonSerializer.Deserialize<List<Animal>>(jsonString);
        }

        public List<Animal> GetAll()
        {
            return animals;
        }

        public Animal? GetById(int id)
        {
            return animals.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Animal animal)
        {
            animal.Id = animals.Max(a => a.Id) + 1;
            animals.Add(animal);
            SaveChanges();
        }

        public void Update(Animal animal)
        {
            var existing = GetById(animal.Id);
            if (existing != null)
            {
                existing.Name = animal.Name;
                existing.Type = animal.Type;
                existing.Breed = animal.Breed;
                existing.Age = animal.Age;
                existing.Gender = animal.Gender;
                existing.Size = animal.Size;
                existing.Status = animal.Status;
                existing.Description = animal.Description;
                existing.Images = animal.Images;
                SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var animal = GetById(id);
            if (animal != null)
            {
                animals.Remove(animal);
                SaveChanges();
            }
        }

        private void SaveChanges()
        {
            string jsonString = JsonSerializer.Serialize(animals);
            File.WriteAllText("Data/animals.json", jsonString);
        }
    }
}
