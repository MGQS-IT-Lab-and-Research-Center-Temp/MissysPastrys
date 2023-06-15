namespace MissysPastrys.Models.Pastry
{
    public class PastryResponseModel : BaseResponseModel
    {
        public PastryViewModel Pastry { get; set; }
    }

    public class PastriesResponseModel : BaseResponseModel
    {
        public List<PastryViewModel> Pastry { get; set; }
    }
}
