using CinemaApp.Data;
using CinemaApp.Data.Services;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly IDirectorsService _service;

        public DirectorsController(IDirectorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }
            else
            {
                await _service.AddAsync(director);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var director = await _service.GetByIdAsync(id);
            if (director == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(director);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var director = await _service.GetByIdAsync(id);

            if (director == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(director);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureUrl,Bio")] Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }
            else
            {
                await _service.UpdateAsync(director);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var director = await _service.GetByIdAsync(id);

            if (director == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(director);
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var director = await _service.GetByIdAsync(id);
            if (director == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
