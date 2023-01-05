using CinemaApp.Models;
using CinemaApp.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Services
{
    public class CartService : EntityBaseRepository<Cart>, ICartService
    {
        private readonly AppDbContext _context;
        public CartService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void addMovieToCart(int movieId, int userId)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == movieId);
            var cart = new Cart();
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            cart = _context.Carts.Include(m => m.Tickets).Where(c => c.User.Id == userId && c.Paid == false).FirstOrDefault();
            if (cart != null)
            {
                var ticket = new Ticket
                {
                    User = user,
                    Movie = movie,
                    Time = movie.CinemaEnd,
                };
                cart.Tickets.Add(ticket);
                _context.SaveChanges();
            }
            else
            {
                cart = new Cart();
                cart.User = user;
                var ticket = new Ticket
                {
                    User = user,
                    Movie = movie,
                    Time = movie.CinemaEnd,
                };
                var tickets = new List<Ticket>();
                tickets.Add(ticket);
                cart.Tickets = tickets;
                _context.AddAsync(cart);
                _context.SaveChanges();
            }
        }

        public Cart getUserCart(int id)
        {
            var cart = new Cart();

            cart = _context.Carts.FirstOrDefault( c => c.User.Id == id);

            return cart;
        }
    }
}
