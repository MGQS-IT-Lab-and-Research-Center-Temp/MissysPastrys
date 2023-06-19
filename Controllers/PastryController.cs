using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissysPastrys.Models.Pastry;
using MissysPastrys.Service.Interfaces;

namespace MissysPastrys.Controllers
{
    public class PastryController : Controller
    {
        private readonly IPastryService _pastryService;
        private readonly INotyfService _notyf;
        private readonly ICategoryService _categoryService;

        public PastryController(IPastryService pastryService,
            INotyfService notyfService,
            ICategoryService categoryService)
        {
            _pastryService = pastryService;
            _notyf = notyfService;
            _categoryService = categoryService;
        }

        //[Route("allPastries")]
        public IActionResult Index()
        {
            var response = _pastryService.GetAllPastry();
            ViewData["Message"] = response.Message;
            ViewData["Status"] = response.Status;

            return View(response.Pastry);
        }

        public IActionResult GetPastry(string id)
        {
            var response = _pastryService.GetPastry(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Index", "Pastry");
            }

            _notyf.Success(response.Message);

            return View(response.Pastry);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreatePastry()
        {
            ViewBag.Categories = _categoryService.SelectCategories();
            ViewData["Message"] = "";
            ViewData["Status"] = false;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePastry(CreatePastryViewModel request)
        {
            var response = _pastryService.CreatePastry(request);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View(request);
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Pastry");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult UpdatePastry(string id)
        {
            var response = _pastryService.GetPastry(id);

            return View(response.Pastry);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdatePastry(UpdatePastryViewModel request, string id)
        {
            var response = _pastryService.UpdatePastry(request, id);
            
            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Index", "Home");
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Pastry");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeletePastry([FromRoute] string id)
        {
            var response = _pastryService.DeletePastry(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View();
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Pastry");
        }
    }
}
