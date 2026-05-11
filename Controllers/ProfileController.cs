using Microsoft.AspNetCore.Mvc;
using ShelterSiteNET.Models;

namespace ShelterSiteASP.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            var model = new UserProfileViewModel
            {
                User = new User(),
                FavoriteAnimals = new List<Animal>()
            };

            return View(model); //пустая чтоб загружать страниц у промтоиыгыгшдвпмлрым
        }
    }
}
