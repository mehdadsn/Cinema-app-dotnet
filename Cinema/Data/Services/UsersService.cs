using CinemaApp.Data.Base;
using CinemaApp.Models;

namespace CinemaApp.Data.Services
{
    public class UsersService : EntityBaseRepository<User>, IUsersService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public User FindByEmail(string email) => _context.Users.FirstOrDefault(u => u.Email.Equals(email));
    }
}
