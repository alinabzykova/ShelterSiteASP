using Microsoft.AspNetCore.Mvc;
using ShelterSiteNET.Models;
using System.Linq;

namespace ShelterSiteNET.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            var animals = new List<Animal>
            {
                new Animal
                {
                    Id = 1,
                    Name = "Бобик",
                    Age = 4,
                    Breed = "Лабрадор",
                    Size = "Большой",
                    Images = new List<string>
                    {
                        "/images/dogs/Бобик 1.jpg"
                    }
                },

                new Animal
                {
                    Id = 2,
                    Name = "Джек",
                    Age = 5,
                    Breed = "Корги",
                    Size = "Большой",
                    Images = new List<string>
                    {
                        "/images/dogs/Джек 1.jpg"
                    }
                },

                new Animal
                {
                    Id = 3,
                    Name = "Лайка",
                    Age = 5,
                    Breed = "Корги",
                    Size = "Средний",
                    Images = new List<string>
                    {
                        "/images/dogs/Лайка 1.jpg"
                    }
                },

                new Animal
                {
                    Id = 3,
                    Name = "Тузик",
                    Age = 5,
                    Breed = "Корги",
                    Size = "Средний",
                    Images = new List<string>
                    {
                        "/images/dogs/Тузик 1.jpg"
                    }
                }
            };

            return View(animals);
        }

        public IActionResult Details(int id)
        {
            var animals = new List<Animal>
            {
                new Animal
                {
                    Id = 1,
                    Name = "Бобик",
                    Age = 4,
                    Breed = "Лабрадор",
                    Size = "Большой",
                    Images = new List<string>
                    {
                        "/images/dogs/Бобик 1.jpg"
                    }
                },

                new Animal
                {
                    Id = 2,
                    Name = "Джек",
                    Age = 5,
                    Breed = "Корги",
                    Size = "Большой",
                    Images = new List<string>
                    {
                        "/images/dogs/Джек 1.jpg"
                    }
                },

                new Animal
                {
                    Id = 3,
                    Name = "Лайка",
                    Age = 5,
                    Breed = "Корги",
                    Size = "Средний",
                    Images = new List<string>
                    {
                        "/images/dogs/Лайка 1.jpg"
                    }
                },

                new Animal
                {
                    Id = 3,
                    Name = "Тузик",
                    Age = 5,
                    Breed = "Корги",
                    Size = "Средний",
                    Images = new List<string>
                    {
                        "/images/dogs/Тузик 1.jpg"
                    }
                }
            };

            var animal = animals.FirstOrDefault(a => a.Id == id);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}