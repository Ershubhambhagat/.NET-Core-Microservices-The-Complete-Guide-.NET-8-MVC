using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Web.Models
{
    public class CartDetailsDTO
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public CartHeaderDTO? CartHeader { get; set; }
        public int ProductId { get; set; }
        public ProductDTOs? Product { get; set; }// all microservises are Isolated so we copy ProductDTOs
        public int Count { get; set; }
    }
}
