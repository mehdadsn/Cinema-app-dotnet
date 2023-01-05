namespace CinemaApp.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Ticket> Tickets { get; set; }
        public bool Paid { get; set; }
    }
}
