using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

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

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
        {
            ResponceDTOs responceDTOs = await _authService.LoginAsync(loginRequestDTO);

            if (responceDTOs != null && responceDTOs.IsSuccess)
            {
                LoginResponceDTO loginResponceDTO = JsonConvert.
                     DeserializeObject<LoginResponceDTO>(Convert.ToString(responceDTOs.Result));
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("CustomError", responceDTOs.Message);
                return View(loginRequestDTO);
            }
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
            else
            {
                TempData["error"] = result.Message;
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
