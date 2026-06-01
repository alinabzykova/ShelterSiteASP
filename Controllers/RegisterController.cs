using Microsoft.AspNetCore.Mvc;
using ShelterSiteASP.Models;

namespace ShelterSiteASP.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(model);
        }
    }
}
