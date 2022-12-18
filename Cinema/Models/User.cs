using CinemaApp.Data.Base;

namespace CinemaApp.Models
{
    public class User : IEntityBase
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; }
        public DateTime SignUpDate {get; set; }
    }
}
