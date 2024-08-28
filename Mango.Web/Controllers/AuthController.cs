using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        #region CTOR
        private readonly IAuthService _authService;
        private readonly ITokenProvider _token;

        public AuthController(IAuthService authService, ITokenProvider token)
        {
            _authService = authService;
            _token = token;
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

                await SignInUser(loginResponceDTO);
                _token.SetToken(loginResponceDTO.Token);
                return RedirectToAction("Index","Home");

            }
            else
            {
                TempData["error"]=responceDTOs.Message;
                //ModelState.AddModelError("CustomError", responceDTOs.Message);
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

            if (result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(registration.Role))
                {
                    registration.Role = SD.RoleCustomer;
                }
                assignRole = await _authService.AssignRoleAsync(registration);

                if (assignRole != null && assignRole.IsSuccess)
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

        #region LogOut
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _token.ClearToken();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region SignInUser
        //this method say thay user login 
        private async Task SignInUser(LoginResponceDTO model)
        {

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(model.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                          jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));


            identity.AddClaim(new Claim(ClaimTypes.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

            identity.AddClaim(new Claim(ClaimTypes.Role,
               jwt.Claims.FirstOrDefault(u => u.Type =="role").Value));



            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            #endregion
        }
    }
}
