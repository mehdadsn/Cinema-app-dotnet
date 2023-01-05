using CinemaApp.Data.Base;
using CinemaApp.Models;

namespace CinemaApp.Data.Services
{
    public interface ICartService : IEntityBaseRepository<Cart>
    {
        public Cart getUserCart(int id);
        public void addMovieToCart(int movieId, int userId);
    }
}
