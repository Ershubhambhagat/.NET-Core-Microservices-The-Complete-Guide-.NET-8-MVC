using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        #region CTOR
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        } 
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO login = new();
            return View(login);
        }
        #endregion

        #region Register
        [HttpGet]

        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer,Value=SD.RoleCustomer}
            };
            ViewBag.RoleList = roleList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDTO registration)
        {
            ResponceDTOs result = await _authService.RegisterAsync(registration);
            ResponceDTOs assignRole;

            if(result!=null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(registration.Role))
                {
                    registration.Role = SD.RoleCustomer;
                }
                assignRole = await _authService.AssignRoleAsync(registration);

                if(assignRole!=null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registation Successfully";
                    return RedirectToAction(nameof(Login));

                }

            }
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer,Value=SD.RoleCustomer}
            };
            ViewBag.RoleList = roleList;
            return View(registration);

        }



        #endregion


        public IActionResult Logout()
        {
            return View();
        }
    }
}
