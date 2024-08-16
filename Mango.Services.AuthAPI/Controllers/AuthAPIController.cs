using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly DbContext _dbContext;

        public AuthAPIController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region register
        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
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
