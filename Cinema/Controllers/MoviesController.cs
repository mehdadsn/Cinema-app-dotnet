using CinemaApp.Data;
using CinemaApp.Data.Services;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CinemaApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(m => m.Cinema);         
            return View(data);
        }

        public IActionResult Create()
        {
            var cinemas = _service.GetCinemas();
            var actors = _service.GetActors();
            var directors = _service.GetDerectors();
            ViewData["Cinemas"] = cinemas;
            ViewData["Actors"] = actors;
            ViewData["Directors"] = directors;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int cinemaId, List<int> actorIds, int directorId, [Bind("Title,BreifStory,ImageUrl,CinemaStart,CinemaEnd,MovieCategoy")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var cinemas = _service.GetCinemas();
                var actors = _service.GetActors();
                var directors = _service.GetDerectors();
                ViewData["Cinemas"] = cinemas;
                ViewData["Actors"] = actors;
                ViewData["Directors"] = directors;
                return View(movie);
            }
            else
            {
                movie.Cinema = _service.GetCinema(cinemaId);
                movie.Actors = _service.GetActors(actorIds);
                movie.Director = _service.GetDirector(directorId);

                await _service.AddAsync(movie);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            if (movie == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(movie);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _service.GetByIdAsync(id);

            if (movie == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(movie);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Title,BreifStory,ImageUrl,CinemaStart,CinemaEnd,MovieCategoy")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            else
            {
                await _service.UpdateAsync(movie);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _service.GetByIdAsync(id);

            if (movie == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(movie);
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            if (movie == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
