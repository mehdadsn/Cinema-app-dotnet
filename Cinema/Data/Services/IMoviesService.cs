using CinemaApp.Data.Base;
using CinemaApp.Models;

namespace CinemaApp.Data.Services
{

    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        List<Cinema> GetCinemas();
        List<Actor> GetActors();
        List<Director> GetDerectors();
        Cinema GetCinema(int id);
        List<Actor> GetActors(List<int> ids);
        Director GetDirector(int id);
    }

}
