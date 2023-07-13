using Microsoft.CodeAnalysis;
using MissysPastrys.Entities;
using MissysPastrys.Models;
using MissysPastrys.Models.Pastry;
using MissysPastrys.Repository.Interfaces;
using MissysPastrys.Service.Interfaces;
using System.Linq.Expressions;
using System.Security.Claims;

namespace MissysPastrys.Service.Implementations
{
    public class PastryService : IPastryService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PastryService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public BaseResponseModel CreatePastry(CreatePastryViewModel request)
        {
            var response = new BaseResponseModel();
            var createdBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var pastryExist = _unitOfWork.Pastries.Exists(p => p.Name == request.Name);

            if (pastryExist)
            {
                response.Message = "Pastry already exist!";
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                response.Message = "Pastry name is required!";
                return response;
            }

            if (request.Image is not null)
            {
                string pastryFolder = "pastry/image/";
                request.ImageUrl = UploadImage(pastryFolder, request.Image);
            }

            var pastry = new Pastry
            {
                Name = request.Name,
                ShortDescription = request.ShortDescription,
                SellingPrice = request.SellingPrice,
                CostPrice = request.CostPrice,
                LongDescription = request.LongDescription,
                ImageUrl = request.ImageUrl,
                CreatedBy = createdBy
            };

            var categories = _unitOfWork.Categories.GetAllByIds(request.CategoryIds);

            var pastryCategories = new HashSet<PastryCategory>();

            foreach (var category in categories)
            {
                var pastryCategory = new PastryCategory
                {
                    CategoryId = category.Id,
                    PastryId = pastry.Id,
                    Category = category,
                    Pastry = pastry,
                    CreatedBy = createdBy
                };

                pastryCategories.Add(pastryCategory);
            }

            pastry.PastryCategories = pastryCategories;

            try
            {
                _unitOfWork.Pastries.Create(pastry);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Pastry added successfully...";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Failed to add pastry {ex.Message}";
                return response;
            }
        }

        public BaseResponseModel DeletePastry(string pastryId)
        {

            var response = new BaseResponseModel();
            var pastryExist = _unitOfWork.Pastries.Exists(p => p.Id == pastryId);

            if (!pastryExist)
            {
                response.Message = "Pastry does not exist!";
                return response;
            }

            var pastry = _unitOfWork.Pastries.Get(pastryId);
            pastry.IsDeleted = true;

            try
            {
                _unitOfWork.Pastries.Update(pastry);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Pastry deleted successfully...";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Cannot delete pastry: {ex.Message}";
                return response;
            }
        }

        public PastriesResponseModel DisplayPastry()
        {
            var response = new PastriesResponseModel();

            try
            {
                var pastries = _unitOfWork.Pastries.GetPastries();

                if (pastries.Count == 0)
                {
                    response.Message = "No pastry found";
                    return response;
                }

                response.Pastry = pastries
                    .Where(p => !p.IsDeleted)
                    .Select(pastry => new PastryViewModel
                    {
                        Id = pastry.Id,
                        Name = pastry.Name,
                        ShortDescription = pastry.ShortDescription,
                        ImageUrl = pastry.ImageUrl,
                        SellingPrice = pastry.SellingPrice
                    }).ToList();

                response.Status = true;
                response.Message = "Success";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public PastriesResponseModel GetAllPastry()
        {

            var response = new PastriesResponseModel();

            try
            {
                var IsInRole = _httpContextAccessor.HttpContext.User.IsInRole("Admin");
                var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                Expression<Func<Pastry, bool>> expression = p => p.Order.User.Orders.Where(o => o.User.Id == userIdClaim).Any(p => p.IsDeleted == false);

                var pastries = IsInRole ? _unitOfWork.Pastries.GetPastries() : _unitOfWork.Pastries.GetPastries(expression);

                if (pastries is null || pastries.Count == 0)
                {
                    response.Message = "No pastries found!";
                    return response;
                }

                response.Pastry = pastries
                    .Where(p => p.IsDeleted == false)
                    .Select(pastry => new PastryViewModel
                    {
                        Id = pastry.Id,
                        Name = pastry.Name,
                        ShortDescription = pastry.ShortDescription,
                        SellingPrice = pastry.SellingPrice,
                        ImageUrl = pastry.ImageUrl
                    }).ToList();
            }
            catch (Exception ex)
            {
                response.Message = $"An error occured {ex.StackTrace}";
                return response;
            }

            response.Status = true;
            response.Message = "Success";

            return response;
        }

        public PastriesResponseModel GetPastriesByCategoryId(string categoryId)
        {

            var response = new PastriesResponseModel();

            try
            {
                var pastries = _unitOfWork.Pastries.GetPastryByCategoryId(categoryId);

                if (pastries.Count == 0)
                {
                    response.Message = "No product found!";
                    return response;
                }

                response.Pastry = pastries
                                        .Select(pastry => new PastryViewModel
                                        {
                                            Id = pastry.Id,
                                            Name = pastry.Pastry.Name,
                                            ImageUrl = pastry.Pastry.ImageUrl,
                                            SellingPrice = pastry.Pastry.SellingPrice,
                                            ShortDescription = pastry.Pastry.ShortDescription
                                        }).ToList();

                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Message = $"An error occured: {ex.StackTrace}";
                return response;
            }

            return response;
        }

        public PastryResponseModel GetPastry(string pastryId)
        {
            var response = new PastryResponseModel();
            var pastryExist = _unitOfWork.Categories.Exists(p =>
                                (p.Id == pastryId)
                                && (p.Id == pastryId
                                && p.IsDeleted == false));

            if (!pastryExist)
            {
                response.Message = "Pastry does not exist!";
                return response;
            }

            var pastry = _unitOfWork.Pastries.Get(pastryId);

            response.Message = "Success";
            response.Status = true;
            response.Pastry = new PastryViewModel
            {
                Id = pastry.Id,
                Name = pastry.Name,
                LongDescription = pastry.LongDescription,
                SellingPrice = pastry.SellingPrice,
                ImageUrl = pastry.ImageUrl
            };

            return response;
        }

        public BaseResponseModel UpdatePastry(UpdatePastryViewModel request, string pastryId)
        {
            var response = new BaseResponseModel();
            var modifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var pastryExist = _unitOfWork.Pastries.Exists(p => p.Id == pastryId);

            if (!pastryExist)
            {
                response.Message = "Pastry does not exist!";
                return response;
            }

            var pastry = _unitOfWork.Pastries.Get(pastryId);
            pastry.LongDescription = request.LongDescription;
            pastry.ImageUrl = request.ImageUrl;
            pastry.ShortDescription = request.ShortDescription;
            pastry.CostPrice = request.CostPrice;
            pastry.SellingPrice = request.SellingPrice;
            pastry.ModifiedBy = modifiedBy;

            try
            {
                _unitOfWork.Pastries.Update(pastry);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Pastry updated successfully...";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Could not update pastry: {ex.Message}";
                return response;
            }
        }

        private string UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
