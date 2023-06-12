using System.ComponentModel.DataAnnotations;

namespace MissysPastrys.Models.User
{
    public class UpdateUserViewModel
    {

        [MinLength(5)]
        [MaxLength(15)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
