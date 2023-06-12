using MissysPastrys.Entities;
using MissysPastrys.Models.Order;
using MissysPastrys.Models.Pastry;
using System.ComponentModel.DataAnnotations;

namespace MissysPastrys.Models.OrderDetail
{
    public class OrderDetailViewModel
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public OrderViewModel Order { get; set; }
        public string PastryId { get; set; }
        public PastryViewModel Pastry { get; set; }
        public int Amount { get; set; }

        [DataType(DataType.Currency)]
        public decimal SellingPrice { get; set; }
    }
}
