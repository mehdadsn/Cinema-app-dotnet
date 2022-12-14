using CinemaApp.Data;
using CinemaApp.Data.Services;
using CinemaApp.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(policy: "IsAdmin")]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(policy: "IsAdmin")]
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

        [Authorize(policy: "IsAdmin")]
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

        [Authorize(policy: "IsAdmin")]
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
        [Authorize(policy: "IsAdmin")]
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

        [Authorize(policy: "IsAdmin")]
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

        [Authorize(policy: "IsAdmin")]
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
