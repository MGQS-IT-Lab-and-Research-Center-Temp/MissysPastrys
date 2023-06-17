using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissysPastrys.Models.Role;
using MissysPastrys.Service.Interfaces;

namespace MissysPastrys.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly INotyfService _notyf;

        public RoleController(IRoleService roleService, INotyfService notyf)
        {
            _roleService = roleService;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            var roles = _roleService.GetAllRole();

            ViewData["Message"] = roles.Message;
            ViewData["Status"] = roles.Status;

            return View(roles.Role);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRole(CreateRoleViewModel request)
        {
            var response = _roleService.CreateRole(request);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);

                return View(request);
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Role");
        }

        public IActionResult GetRoleDetail(string id)
        {
            var response = _roleService.GetRole(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Index", "Role");
            }

            return View(response.Role);
        }

        public IActionResult UpdateRole(string id)
        {
            var response = _roleService.GetRole(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Index", "Role");
            }

            var viewModel = new UpdateRoleViewModel
            {
                Id = response.Role.Id,
                RoleName = response.Role.RoleName,
                Description = response.Role.Description
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateRole(string id, UpdateRoleViewModel request)
        {
            var response = _roleService.UpdateRole(id, request);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View(request);
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Role");
        }

        [HttpPost]
        public IActionResult DeleteRole([FromRoute] string id)
        {
            var response = _roleService.DeleteRole(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Index", "Role"); ;
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Role");
        }
    }
}
