using Mango.Services.AuthAPI.Models.DTOs;
using Mango.Services.AuthAPI.Service;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        private ResponceDTO _responce;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _responce = new();
        }

        #region register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            var res=await _authService.Register(model);
            //check res is not null or Empty
            if (!string.IsNullOrEmpty(res))
            {
                _responce.IsSuccess=false;
                _responce.Message = res;
                return BadRequest(_responce);
            }
            return Ok($"Name : {_responce.Result= model.Name} Added Successfully");
        }
        #endregion
        #region Login
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        } 
        #endregion
    }
}
