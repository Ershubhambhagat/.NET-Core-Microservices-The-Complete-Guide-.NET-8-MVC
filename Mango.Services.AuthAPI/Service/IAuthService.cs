using Mango.Services.AuthAPI.Models.DTOs;

namespace Mango.Services.AuthAPI.Service
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<LoginResponceDTO>Login(LoginRequestDTO loginRequestDTO);
        Task<bool> AssignRole(string email, string roleName);
    }
}
