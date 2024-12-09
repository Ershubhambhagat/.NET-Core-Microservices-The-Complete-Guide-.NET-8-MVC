using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.ShoppingCartAPI.Models.DTOs
{
    public class CartHeaderDTO
    {
        public int CartHeaerId { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }
        public double? Discount { get; set; }
        public double CartTotal { get; set; }
    }
}
