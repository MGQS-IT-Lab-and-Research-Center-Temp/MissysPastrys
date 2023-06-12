using MissysPastries.Models;
using MissysPastrys.Models.Pastry;

namespace MissysPastrys.Service.Interfaces
{
    public interface IPastryService
    {
        BaseResponseModel CreatePastry(CreatePastryViewModel request);
        BaseResponseModel DeletePastry(string pastryId);
        BaseResponseModel UpdatePastry(UpdatePastryViewModel request, string pastryId);
        PastryResponseModel GetPastry(string pastryId);
        PastriesResponseModel GetAllPastry();
        PastriesResponseModel GetPastriesByCategoryId(string categoryId);
        PastriesResponseModel DisplayPastry();
    }
}
