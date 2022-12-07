using CinemaApp.Data.Base;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Services
{
    public class DirectorsService : EntityBaseRepository<Director>, IDirectorsService
    {
        public DirectorsService(AppDbContext context) : base(context) { }    
    }
}
