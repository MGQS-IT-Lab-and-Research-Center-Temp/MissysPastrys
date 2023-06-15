namespace MissysPastrys.Models.Delivery
{
    public class DeliveryResponseModel : BaseResponseModel
    {
        public DeliveryViewModel Delivery { get; set; }
    }

    public class DeliveriesResponseModel : BaseResponseModel
    {
        public List<DeliveryViewModel> Delivery { get; set; }
    }
}
