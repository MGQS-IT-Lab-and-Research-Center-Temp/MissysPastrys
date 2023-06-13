﻿using Microsoft.CodeAnalysis;
using MissysPastries.Models;
using MissysPastrys.Entities;
using MissysPastrys.Models.Pastry;
using MissysPastrys.Repository.Interfaces;
using MissysPastrys.Service.Interfaces;

namespace MissysPastrys.Service.Implementations
{
    public class PastryService : IPastryService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public PastryService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
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

            var pastry = new Pastry
            {
                Name = request.Name,
                ShortDescription = request.ShortDescription,
                ImageThumbnailUrl = request.ImageThumbUrl,
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
                        ImageThumbUrl = pastry.ImageThumbnailUrl,
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
                var pastries = _unitOfWork.Pastries.GetAll(p => p.IsDeleted == false);

                if (pastries is null || pastries.Count == 0)
                {
                    response.Message = "No pastries found!";
                    return response;
                }

                response.Pastry = pastries.Select(
                    pastry => new PastryViewModel
                    {
                        Id = pastry.Id,
                        Name = pastry.Name,
                        ShortDescription = pastry.ShortDescription,
                        SellingPrice = pastry.SellingPrice,
                        ImageThumbUrl = pastry.ImageThumbUrl
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
                                            ImageThumbnailUrl = pastry.Pastry.ImageThumbnailUrl,
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
            pastry.ImageThumbnailUrl = request.ImageThumbnailUrl;
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
    }
}
