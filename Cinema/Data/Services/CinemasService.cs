using CinemaApp.Data.Base;
using CinemaApp.Models;

namespace CinemaApp.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context) { }
    }
}
