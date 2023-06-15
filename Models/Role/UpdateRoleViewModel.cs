using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MissysPastrys.Models.Role
{
    public class UpdateRoleViewModel
    {
        public string Id { get; set; }

        [ReadOnly(true)]
        public string RoleName { get; set; }

        [MinLength(3, ErrorMessage = "The minimum length of description you can enter is 5")]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
