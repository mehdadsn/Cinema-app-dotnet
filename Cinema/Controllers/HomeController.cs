using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}
