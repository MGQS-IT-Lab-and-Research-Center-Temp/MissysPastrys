using System.ComponentModel.DataAnnotations;

namespace MissysPastrys.Models.Role
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage ="Role name is required!")]
        [MinLength(3, ErrorMessage = "The minimum length you can enter is 3")]
        [MaxLength(30, ErrorMessage = "The maximum length you can enter is 30")]
        public string RoleName { get; set; }

        [MinLength(3, ErrorMessage = "The minimum length of description you can enter is 5")]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
