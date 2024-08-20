using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;

        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        #region AssignRoleAsync
        public async Task<ResponceDTOs?> AssignRoleAsync(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTOs
            {
                ApiType = SD.ApiType.Post,
                Data = registrationRequestDTO,
                Url = SD.AuthAPIBase + "/api/AssignRole"
            });
        }
        #endregion

        #region LoginAsync
        public async Task<ResponceDTOs?> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTOs
            {
                ApiType = SD.ApiType.Post,
                Data = loginRequestDTO,
                Url = SD.AuthAPIBase + "/api/login"
            });
        }
        #endregion

        #region RegisterAsync

        public async Task<ResponceDTOs?> RegisterAsync(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTOs
            {
                ApiType = SD.ApiType.Post,
                Data = registrationRequestDTO,
                Url = SD.AuthAPIBase + "/api/register"
            });
        } 
        #endregion
    }
}
