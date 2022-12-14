using CinemaApp.Data;
using CinemaApp.Data.Services;
using CinemaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        [Authorize(policy: "IsAdmin")]
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        [Authorize(policy: "IsAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(policy: "IsAdmin")]
        public async Task<IActionResult> Create([Bind("Name,LogoUrl,About")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            else
            {
                await _service.AddAsync(cinema);
                return RedirectToAction("Index");
            }
        }

        [Authorize(policy: "IsAdmin")]
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(cinema);
            }
        }

        [Authorize(policy: "IsAdmin")]
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _service.GetByIdAsync(id);

            if (cinema == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(cinema);
            }
        }

        [HttpPost]
        [Authorize(policy: "IsAdmin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LogoUrl,About")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            else
            {
                await _service.UpdateAsync(cinema);
                return RedirectToAction("Index");
            }
        }

        [Authorize(policy: "IsAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _service.GetByIdAsync(id);

            if (cinema == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(cinema);
            }
        }

        [Authorize(policy: "IsAdmin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
