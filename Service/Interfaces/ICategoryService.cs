using Microsoft.AspNetCore.Mvc.Rendering;
using MissysPastries.Models.Category;
using MissysPastries.Models;

namespace MissysPastrys.Service.Interfaces
{
    public interface ICategoryService
    {
        BaseResponseModel CreateCategory(CreateCategoryViewModel request);
        BaseResponseModel DeleteCategory(string categoryId);
        BaseResponseModel UpdateCategory(string categoryId, UpdateCategoryViewModel request);
        CategoryResponseModel GetCategory(string categoryId);
        CategoriesResponseModel GetAllCategory();
        IEnumerable<SelectListItem> SelectCategories();
    }
}
