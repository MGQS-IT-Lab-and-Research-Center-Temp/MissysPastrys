using MissysPastries.Models;

namespace MissysPastrys.Models.Order
{
    public class OrderResponseModel : BaseResponseModel
    {
        public OrderViewModel Order { get; set; }
    }

    public class OrdersResponseModel : BaseResponseModel
    {
        public List<OrderViewModel> Order { get; set; }
    }
}
