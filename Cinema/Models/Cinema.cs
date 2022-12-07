using CinemaApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class Cinema : IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Picture")]
        public string? LogoUrl { get; set; }
        [Display(Name = "About")]
        public string? About { get; set; }
    }
}
