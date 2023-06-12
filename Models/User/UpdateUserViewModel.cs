using System.ComponentModel.DataAnnotations;

namespace MissysPastrys.Models.User
{
    public class UpdateUserViewModel
    {

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
