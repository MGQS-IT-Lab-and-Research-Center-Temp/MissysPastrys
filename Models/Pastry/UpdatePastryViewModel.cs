using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MissysPastrys.Models.Pastry
{
    public class UpdatePastryViewModel
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string LongDescription { get; set; }
        public IFormFile ImageThumbnail { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string ShortDescription { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }

        [DataType(DataType.Currency)]
        public decimal CostPrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal SellingPrice { get; set; }
    }
}
