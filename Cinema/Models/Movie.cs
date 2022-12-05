using CinemaApp.Data;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class Movie
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
        public Producer? Producer { get; set; }
        public Cinema? Cinema { get; set; }
    }
}
