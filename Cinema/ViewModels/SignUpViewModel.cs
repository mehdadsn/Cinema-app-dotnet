using System.ComponentModel.DataAnnotations;

namespace CinemaApp.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Required(ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        public string? Phone { get; set; }
    }
}
