using System.ComponentModel.DataAnnotations;

namespace MissysPastries.Models.Category
{
    public class UpdateCategoryViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Category name is required!")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
