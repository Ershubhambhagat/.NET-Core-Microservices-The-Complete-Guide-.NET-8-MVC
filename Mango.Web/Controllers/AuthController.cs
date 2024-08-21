using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }




        #endregion


        public IActionResult Logout()
        {
            return View();
        }
    }
}
