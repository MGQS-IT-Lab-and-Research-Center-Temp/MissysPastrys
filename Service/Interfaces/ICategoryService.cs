using Microsoft.AspNetCore.Mvc.Rendering;
using MissysPastrys.Models;
using MissysPastrys.Models.Category;

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
