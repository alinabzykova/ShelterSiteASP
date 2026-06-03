using Microsoft.AspNetCore.Mvc;

namespace ShelterSiteNET.Controllers
{
    public class DonationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string donorName, decimal amount)
        {
            ViewBag.Success = true;
            ViewBag.Name = donorName;
            ViewBag.Amount = amount;

            return View();
        }
    }
}