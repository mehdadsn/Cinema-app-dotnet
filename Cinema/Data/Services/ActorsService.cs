using CinemaApp.Models;
using CinemaApp.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }    
    }
}
