using Microsoft.AspNetCore.Mvc;
using ShelterSiteASP.Data;
using ShelterSiteNET.Models;

namespace ShelterSiteNET.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserRepository _userRepo;
        private readonly AnimalRepository _animalRepo;
        private readonly FavoriteRepository _favoriteRepo;

        public ProfileController(
            UserRepository userRepo,
            AnimalRepository animalRepo,
            FavoriteRepository favoriteRepo)
        {
            _userRepo = userRepo;
            _animalRepo = animalRepo;
            _favoriteRepo = favoriteRepo;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = _userRepo.GetById(userId.Value);

            if (user == null)
                return RedirectToAction("Login", "Account");

            var favorites = _favoriteRepo.GetByUserId(userId.Value);

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
        public IActionResult ToggleFavorite(int animalId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var favorites = _favoriteRepo.GetByUserId(userId.Value);

            var existingFavorite = favorites
                .FirstOrDefault(f => f.AnimalId == animalId);

            if (existingFavorite == null)
            {
                _favoriteRepo.Add(userId.Value, animalId);
            }
            else
            {
                _favoriteRepo.Remove(userId.Value, animalId);
            }

            return RedirectToAction(
                "Details",
                "Animal",
                new { id = animalId });
        }

        [HttpPost]
        public IActionResult RemoveFromFavorites(int animalId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            _favoriteRepo.Remove(userId.Value, animalId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateDescription(string description)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = _userRepo.GetById(userId.Value);

            if (user == null)
                return RedirectToAction("Login", "Account");

            user.Description = description.Trim();

            _userRepo.Update(user);

            return RedirectToAction("Index");
        }
    }
}