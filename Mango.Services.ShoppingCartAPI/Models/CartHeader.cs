using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.ShoppingCartAPI.Models
{
    public class CartHeader
    {
        [Key]
        public int CartHeaerId { get; set; }
        public string? UsetId { get; set; }
        public string? CouponCode { get; set; }
        [NotMapped]
        public string? Discount { get; set; }
        [NotMapped]
        public int CartTotal { get; set; }


    }
}
