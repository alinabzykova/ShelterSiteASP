using Microsoft.AspNetCore.Mvc;
using ShelterSiteASP.Data;
using ShelterSiteNET.Models;

namespace ShelterSiteNET.Controllers
{
    public class ProfileController : Controller
    {  private readonly UserRepository _userRepo;
        private readonly AnimalRepository _animalRepo;
        private readonly FavoriteRepository _favoriteRepo;

        public ProfileController(UserRepository userRepo, AnimalRepository animalRepo, FavoriteRepository favoriteRepo)
        {
            _userRepo = userRepo;
            _animalRepo = animalRepo;
            _favoriteRepo = favoriteRepo;
        }

        public IActionResult Index(int userId = 1)  
        {
            var user = _userRepo.GetById(userId);
            if (user == null)
            { 
                user = new User { Login = "Гость", Description = "Добро пожаловать!" };
            }

            var favorites = _favoriteRepo.GetByUserId(userId);
            var favoriteAnimals = new List<Animal>();
            
            foreach (var fav in favorites)
            {
                var animal = _animalRepo.GetById(fav.AnimalId);
                if (animal != null)
                    favoriteAnimals.Add(animal);
            }

            var model = new UserProfileViewModel
            {
                User = user,
                FavoriteAnimals = favoriteAnimals
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddToFavorites(int userId, int animalId)
        {
            _favoriteRepo.Add(userId, animalId);
            return RedirectToAction("Details", "Animal", new { id = animalId });
        }

        [HttpPost]
        public IActionResult RemoveFromFavorites(int userId, int animalId)
        {
            _favoriteRepo.Remove(userId, animalId);
            return RedirectToAction("Index");
        } 
    }
}