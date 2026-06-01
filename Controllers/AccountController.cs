using Microsoft.AspNetCore.Mvc;
using ShelterSiteASP.Data;
using ShelterSiteASP.Models;
using ShelterSiteNET.Models;
namespace ShelterSiteNET.Controllers
{
    public class AccountController : Controller
    { 

        private readonly UserRepository _userRepo;
         

        public AccountController(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepo.ValidateUser(model.Login, model.Password);

                if (user != null)
                { 
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("UserLogin", user.Login);
                    HttpContext.Session.SetString("UserRole", user.Role);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Неверный логин или пароль");
            }

            return View(model);
        }

        [HttpGet]   
        public IActionResult Register()
        {
            return View();
        }
         
            [HttpPost]
            public IActionResult Register(string Login, string Password, string ConfirmPassword)
            { 
                if (Password != ConfirmPassword)
                {
                    ModelState.AddModelError("", "Пароли не совпадают!");
                    return View();
                }
                 
                if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
                {
                    ModelState.AddModelError("", "Логин и пароль обязательны!");
                    return View();
                }
                 
                if (_userRepo.UserExists(Login))
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует!");
                    return View();
                }
                 
                var user = new User
                {
                    Login = Login,
                    Password = Password,
                    Description = "Любитель животных",
                    Role = "User"
                };

                _userRepo.AddUser(user);

                return RedirectToAction("Login");
            } 
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}