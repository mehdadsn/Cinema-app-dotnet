using CinemaApp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CinemaApp.Controllers
{
    public class CartController : Controller
    {
        readonly ICartService _service;
        public CartController(ICartService service)
        {
            _service= service;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var data = _service.getUserCart(int.Parse(User.FindFirstValue("Id")));
                return View(data);
            }
            return RedirectToAction("Users", "Login");
        }
        public void AddToCart(int movieId)
        {
            _service.addMovieToCart(movieId, int.Parse(User.FindFirstValue("Id")));
        }
    }
}
