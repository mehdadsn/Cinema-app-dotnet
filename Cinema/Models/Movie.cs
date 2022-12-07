using CinemaApp.Data;
using CinemaApp.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace CinemaApp.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? BreifStory { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CinemaStart { get; set; }
        public DateTime CinemaEnd { get; set; }
        public MovieCategoy MovieCategoy { get; set; }
        public List<Actor>? Actors { get; set; }
        public Director? Director { get; set; }
        public Cinema? Cinema { get; set; }
    }
}
