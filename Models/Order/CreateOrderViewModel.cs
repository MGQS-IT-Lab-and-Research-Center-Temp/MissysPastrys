using Microsoft.AspNetCore.Mvc.ModelBinding;
using MissysPastrys.Models.OrderDetail;
using System.ComponentModel.DataAnnotations;

namespace MissysPastrys.Models.Order
{
    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your state of residence")]
        [Display(Name = "State of residence")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlacedDate { get; set; }
        public List<OrderDetailViewModel> OrderLine { get; set; }
    }
}
