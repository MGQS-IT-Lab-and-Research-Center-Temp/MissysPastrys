using System.ComponentModel.DataAnnotations;

namespace MissysPastrys.Models.Pastry
{
    public class CreatePastryViewModel
    {

        [Required(ErrorMessage = "Pastry name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pastry short description is required!")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Cost price is required!")]
        [DataType(DataType.Currency)]
        public decimal CostPrice { get; set; }

        [Required(ErrorMessage = "Selling price is required!")]
        [DataType(DataType.Currency)]
        public decimal SellingPrice { get; set; }

        [Required(ErrorMessage = "Pastry long description is required!")]
        public string LongDescription { get; set; }

        [Required]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "One or more categories need to be selected")]
        public List<string> CategoryIds { get; set; }
    }
}
