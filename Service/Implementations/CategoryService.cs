using Microsoft.AspNetCore.Mvc.Rendering;
using MissysPastrys.Entities;
using MissysPastrys.Models;
using MissysPastrys.Models.Category;
using MissysPastrys.Repository.Interfaces;
using MissysPastrys.Service.Interfaces;

namespace MissysPastrys.Service.Implementations
{
    public class CategoryService : ICategoryService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public BaseResponseModel CreateCategory(CreateCategoryViewModel request)
        {
            var response = new BaseResponseModel();
            var createdBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var categoryExist = _unitOfWork.Categories.Exists(c => c.CategoryName == request.Name);

            if (categoryExist)
            {
                response.Message = "Category already exist!";
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                response.Message = "Category name is required!";
                return response;
            }

            var category = new Category
            {
                CategoryName = request.Name,
                Description = request.Description,
                CreatedBy = createdBy
            };

            try
            {
                _unitOfWork.Categories.Create(category);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Category created successfully...";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Failed to create category {ex.Message}";
                return response;
            }
        }

        public BaseResponseModel DeleteCategory(string categoryId)
        {

            var response = new BaseResponseModel();
            var categoryExist = _unitOfWork.Categories.Exists(c => c.Id == categoryId);

            if (!categoryExist)
            {
                response.Message = "Category does not exist!";
                return response;
            }

            var category = _unitOfWork.Categories.Get(categoryId);
            category.IsDeleted = true;

            try
            {
                _unitOfWork.Categories.Update(category);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Category deleted successfully...";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Cannot delete category{ex.Message}";
                return response;
            }
        }

        public CategoriesResponseModel GetAllCategory()
        {

            var response = new CategoriesResponseModel();

            try
            {
                var category = _unitOfWork.Categories.GetAll(c => c.IsDeleted == false);

                if (category is null || category.Count == 0)
                {
                    response.Message = "No categories found!";
                    return response;
                }

                response.Category = category.Select(
                    category => new CategoryViewModel
                    {
                        Id = category.Id,
                        Name = category.CategoryName,
                        Description = category.Description
                    }).ToList();
            }
            catch (Exception ex)
            {
                response.Message = $"An error occured {ex.Message}";
                return response;
            }

            response.Status = true;
            response.Message = "Success";

            return response;
        }

        public CategoryResponseModel GetCategory(string categoryId)
        {
            var response = new CategoryResponseModel();
            var categoryExist = _unitOfWork.Categories.Exists(c =>
                                (c.Id == categoryId)
                                && (c.Id == categoryId
                                && c.IsDeleted == false));

            if (!categoryExist)
            {
                response.Message = "Category does not exist!";
                return response;
            }

            var category = _unitOfWork.Categories.Get(categoryId);

            response.Message = "Success";
            response.Status = true;
            response.Category = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.CategoryName,
                Description = category.Description
            };

            return response;
        }

        public IEnumerable<SelectListItem> SelectCategories()
        {
            return _unitOfWork.Categories.SelectAll().Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.Id
            });
        }

        public BaseResponseModel UpdateCategory(string categoryId, UpdateCategoryViewModel request)
        {
            var response = new BaseResponseModel();
            var modifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var categoryExist = _unitOfWork.Categories.Exists(c => c.Id == categoryId);

            if (!categoryExist)
            {
                response.Message = "Category does not exist!";
                return response;
            }

            var category = _unitOfWork.Categories.Get(categoryId);
            category.Description = request.Description;
            category.ModifiedBy = modifiedBy;

            try
            {
                _unitOfWork.Categories.Update(category);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Category updated successfully...";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Could not update category: {ex.Message}";
                return response;
            }
        }
    }
}
