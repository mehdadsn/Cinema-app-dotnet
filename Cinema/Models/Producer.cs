namespace CinemaApp.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string Name { get; set; }
        public string? About { get; set; }
        public List<Movie>? MyProperty { get; set; }
    }
}
