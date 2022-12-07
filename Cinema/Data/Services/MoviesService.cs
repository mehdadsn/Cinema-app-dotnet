using CinemaApp.Data.Base;
using CinemaApp.Models;

namespace CinemaApp.Data.Services
{

    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context) { }

    }

}
