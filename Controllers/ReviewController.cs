using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MissysPastrys.Models.Review;
using MissysPastrys.Service.Interfaces;
using Org.BouncyCastle.Asn1.Ocsp;

namespace MissysPastrys.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly INotyfService _notyf;

        public ReviewController(IReviewService reviewService, INotyfService notyf)
        {
            _reviewService = reviewService;
            _notyf = notyf;
        }


        //public IActionResult Index()
        //{
        //    var response = _reviewService.GetAllReview();
        //    ViewData["Message"] = response.Message;
        //    ViewData["Status"] = response.Status;

        //    return View(response.Review);
        //}
        public IActionResult GetReviewDetail(string id)
        {
            var response = _reviewService.GetReview(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Index", "Pastry");
            }

            return View(response.Review);
        }

        public IActionResult CreateReview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateReview(CreateReviewViewModel request)
        {
            var response = _reviewService.CreateReview(request);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View();
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Privacy", "Home");
        }


        public IActionResult UpdateReview(string id)
        {
            var response = _reviewService.GetReview(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Privacy", "Home");
            }

            return View(response.Review);
        }

        [HttpPost]
        public IActionResult UpdateReview(UpdateReviewViewModel request, string id )
        {
            var response = _reviewService.UpdateReview(request, id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Privacy", "Home");
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Privacy", "Home");
        }


        [HttpPost]
        public IActionResult DeleteReview([FromRoute] string id)
        {
            var response = _reviewService.DeleteReview(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Privacy", "Home");
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Privacy", "Home");
        }
    }
}

