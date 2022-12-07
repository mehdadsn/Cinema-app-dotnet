using CinemaApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class Director : IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string? ProfilePictureUrl { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string? Bio { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
