using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponceDTOs?> RegisterAsync(RegistrationRequestDTO registrationRequestDTO);
        Task<ResponceDTOs?> LoginAsync(LoginRequestDTO loginRequestDTO);
        Task<ResponceDTOs?> AssignRoleAsync(RegistrationRequestDTO registrationRequestDTO);
    }
}
