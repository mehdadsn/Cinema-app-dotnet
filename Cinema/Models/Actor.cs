using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public string? Bio { get; set; }
        public int? Age { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
