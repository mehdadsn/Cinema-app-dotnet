using CinemaApp.Data.Base;

namespace CinemaApp.Models
{
    public class Ticket : IEntityBase
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public DateTime Time { get; set; }
        public User User { get; set; }
        public bool Expired { get; set; }
    }
}
