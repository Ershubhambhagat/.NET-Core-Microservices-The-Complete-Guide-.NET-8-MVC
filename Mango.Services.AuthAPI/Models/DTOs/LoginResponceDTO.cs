namespace Mango.Services.AuthAPI.Models.DTOs
{
    public class LoginResponceDTO
    {
        public UserDTO User { get; set; }
        public string Tocken { get; set; }
    }
}
