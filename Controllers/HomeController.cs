using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MissysPastrys.Models.Auth;
using MissysPastrys.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using MissysPastrys.ActionFilters;

namespace MissysPastrys.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly INotyfService _notyf;
        private readonly IPastryService _pastryService;

        public HomeController(IUserService userService, INotyfService notyf, IPastryService pastryService)
        {
            _userService = userService;
            _notyf = notyf;
            _pastryService = pastryService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var pastries = _pastryService.DisplayPastry();
            ViewData["Message"] = pastries.Message;
            ViewData["Status"] = pastries.Status;

            return View(pastries.Pastry);
        }
        
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model)
        {
            var response = _userService.Register(model);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View(response);
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Home");
        }

        [RedirectIfAuthenticated]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel request)
        {
            var response = _userService.Login(request);
            var user = response.User;

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, user.RoleName),
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authenticationProperties = new AuthenticationProperties();

            var principal = new ClaimsPrincipal(claimIdentity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

            _notyf.Success(response.Message);

            if (user.RoleName == "Admin")
            {
                return RedirectToAction("AdminDashboard", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _notyf.Success("You have successfully signed out!");
            return RedirectToAction("Login", "Home");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashBoard()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}