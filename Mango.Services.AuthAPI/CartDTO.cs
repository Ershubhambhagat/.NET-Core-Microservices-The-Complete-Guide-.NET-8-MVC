using Mango.Services.ShoppingCartAPI.Models.DTOs;

namespace Mango.Services.AuthAPI
{
    public class CartDTO
    {
        public CartHeaderDTO CartHeader { get; set; }
        public IEnumerable<CartDetailsDTO>? CartDetails { get; set; }

    }
}
