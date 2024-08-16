namespace Mango.Services.AuthAPI.Models.DTOs
{
    public class ResponceDTO
    {

        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
