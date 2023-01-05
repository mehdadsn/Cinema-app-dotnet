using CinemaApp.Data.Base;

namespace CinemaApp.Models
{
    public class Cart : IEntityBase
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Ticket> Tickets { get; set; }
        public bool Paid { get; set; }
    }
}
