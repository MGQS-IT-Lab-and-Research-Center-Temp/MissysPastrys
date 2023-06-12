using System.ComponentModel.DataAnnotations;

namespace MissysPastrys.Models.User
{
    public class CreateUserViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
