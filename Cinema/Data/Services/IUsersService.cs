using CinemaApp.Data.Base;
using CinemaApp.Models;

namespace CinemaApp.Data.Services
{
    public interface IUsersService : IEntityBaseRepository<User>
    {
        User FindByEmail(string email);
    }
}
