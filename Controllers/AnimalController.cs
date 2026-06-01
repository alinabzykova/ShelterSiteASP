using Microsoft.AspNetCore.Mvc;
using ShelterSiteNET.Models;
using System.Linq; 
using ShelterSiteASP.Data;

namespace ShelterSiteNET.Controllers
{
    public class AnimalController : Controller
    {   private readonly AnimalRepository _animalRepo;
        private readonly FavoriteRepository _favoriteRepo;
        private readonly UserRepository _userRepo;

        public AnimalController(
            AnimalRepository animalRepo,
            FavoriteRepository favoriteRepo,
            UserRepository userRepo)
        {
            _animalRepo = animalRepo;
            _favoriteRepo = favoriteRepo;
            _userRepo = userRepo;
        }

        private bool IsAdmin()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return false;
             
            return _userRepo.IsAdmin(userId.Value);
        }

        public IActionResult Index()
        {
            var animals = _animalRepo.GetAll();
            return View(animals);
        }

        public IActionResult Details(int id)
        {
            var animal = _animalRepo.GetById(id);

            if (animal == null)
                return NotFound();

            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId != null)
            {
                ViewBag.IsFavorite =
                    _favoriteRepo.IsFavorite(userId.Value, id);
            }
            else
            {
                ViewBag.IsFavorite = false;
            }

            return View(animal);
        }

        public IActionResult Create()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            if (ModelState.IsValid)
            {
                _animalRepo.Add(animal);
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        public IActionResult Edit(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var animal = _animalRepo.GetById(id);
            if (animal == null)
                return NotFound();
            return View(animal);
        }

        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            if (ModelState.IsValid)
            {
                _animalRepo.Update(animal);
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var animal = _animalRepo.GetById(id);

            if (animal == null)
                return NotFound();

            _animalRepo.Delete(id); 
            return RedirectToAction("Index");
        } 
    }
}