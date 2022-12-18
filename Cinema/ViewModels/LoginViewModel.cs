using System.ComponentModel.DataAnnotations;

namespace CinemaApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "user not found")]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
