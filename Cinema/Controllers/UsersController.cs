
using CinemaApp.Data.Services;
using CinemaApp.Models;
using CinemaApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CinemaApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _service;
        public UsersController(IUsersService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid) return View(login);

            var user = _service.FindByEmail(login.Email);

            if (user == null || login.Password != user.Password)
            {
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(login);
            }


            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Role", user.Role)
                };

            var identity = new ClaimsIdentity(claims, "CinemaAppCookie");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            await HttpContext.SignInAsync("CinemaAppCookie", claimsPrincipal, authProperties);
            return RedirectToAction("Index", "Movies");

            //return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CinemaAppCookie");
            return RedirectToAction("Index", "Movies");
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel newUser)
        {
            if (!ModelState.IsValid)
            {
                return View(newUser);
            }
            if (newUser.Password != newUser.ConfirmPassword)
            {
                return View(newUser);
            }
            var user = new User()
            {
                FullName = newUser.FullName,
                Email = newUser.Email,
                Password = newUser.Password,
                Phone = newUser.Phone,
                SignUpDate = DateTime.Now,
                Role = "User"
            };
            _service.AddAsync(user);
            return RedirectToAction("Login");
        }
    }
}
