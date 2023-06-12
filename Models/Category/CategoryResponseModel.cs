namespace MissysPastries.Models.Category
{
    public class CategoryResponseModel : BaseResponseModel
    {
        public CategoryViewModel Category { get; set; }
    }

    public class CategoriesResponseModel : BaseResponseModel
    {
        public List<CategoryViewModel> Category { get; set; }
    }
}
