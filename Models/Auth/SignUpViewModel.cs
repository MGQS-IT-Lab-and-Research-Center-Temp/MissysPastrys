using System.ComponentModel.DataAnnotations;

namespace MissysPastrys.Models.Auth
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(5, ErrorMessage = "The minimum length is 5")]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
