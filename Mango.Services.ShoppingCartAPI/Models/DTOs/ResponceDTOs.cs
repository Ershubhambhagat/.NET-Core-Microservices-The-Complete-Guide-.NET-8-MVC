﻿namespace Mango.Services.ShoppingCartAPI.Models.DTOs
{
    public class ResponceDTOs
    {

        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
