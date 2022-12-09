using CinemaApp.Data.Base;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Services
{

    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Actor> GetActors() => _context.Actors.ToList();
        public List<Actor> GetActors(List<int> ids)
        {
            var actors = new List<Actor>();
            foreach (var id in ids)
            {
                actors.Add(_context.Actors.FirstOrDefault(a => a.Id == id));
            }
            return actors;
        }

        public List<Cinema> GetCinemas() => _context.Cinemas.ToList();
        public Cinema GetCinema(int id) => _context.Cinemas.FirstOrDefault(a => a.Id == id);

        public List<Director> GetDerectors() => _context.Directors.ToList();
        public Director GetDirector(int id) => _context.Directors.FirstOrDefault(a => a.Id == id);
    }

}
