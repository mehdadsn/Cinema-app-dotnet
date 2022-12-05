using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(new Actor
            {
                Id = 1,
                FullName = "mehrdad",
                Age = 23,
                ProfilePictureUrl = "noPic"
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<CinemaApp.Models.Cinema> Cinemas { get; set; }
    }
}
