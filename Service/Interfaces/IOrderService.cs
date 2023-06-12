using MissysPastries.Models;
using MissysPastrys.Models.Order;

namespace MissysPastrys.Service.Interfaces
{
    public interface IOrderService
    {
        BaseResponseModel CreateOrder(CreateOrderViewModel request);
        BaseResponseModel DeleteOrder(string orderId);
        BaseResponseModel UpdateOrder(UpdateOrderViewModel request, string orderId);
        OrderResponseModel GetOrder(string orderId);
        OrdersResponseModel GetAllOrder();
    }
}
