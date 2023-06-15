namespace MissysPastrys.Models.OrderDetail
{
    public class OrderDetailResponseModel : BaseResponseModel
    {
        public OrderDetailViewModel OrderDetail { get; set; }
    }

    public class OrderDetailsViewModel : BaseResponseModel
    {
        public List<OrderDetailViewModel> OrderDetail { get; set; }
    }
}
