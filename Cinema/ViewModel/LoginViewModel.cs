using System.ComponentModel.DataAnnotations;

namespace CinemaApp.ViewModel
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
