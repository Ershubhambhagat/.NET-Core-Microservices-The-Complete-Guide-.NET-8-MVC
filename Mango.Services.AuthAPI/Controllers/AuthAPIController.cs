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

        #region CTOR
        private readonly IAuthService _authService;
        private ResponceDTO _responce;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _responce = new();
        } 
        #endregion

        #region Auth Register
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

        #region Auth Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponce = await _authService.Login(model);
                if (loginResponce.User == null)
            {
                _responce.IsSuccess = false;
                _responce.Message = "UserName or Password is Incorrect";
                return BadRequest(_responce);
            }
            _responce.Result=loginResponce;
            return Ok(_responce);
        }
        #endregion

        #region Auth Login
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDTO model)
        {
            var assignRoleSuccess = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccess)
            {
                _responce.IsSuccess = false;
                _responce.Message = $"Error Enconter , Something Went Wronge with {model.Name}";
                return BadRequest(_responce);
            }
            _responce.Result = assignRoleSuccess;
            return Ok(_responce);
        }
        #endregion
    }
}
