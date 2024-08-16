namespace Mango.Services.AuthAPI.Models.DTOs
{
    public class LoginResponceDTO
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }
    }
}
