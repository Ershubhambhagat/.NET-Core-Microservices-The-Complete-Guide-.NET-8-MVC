using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICartService
    {
        Task<ResponceDTOs> GetCartByUserIdAsync(string UserId);

        Task<ResponceDTOs> UpsertCartAsync(CartDTO cartDTO);
        Task<ResponceDTOs> RemoveFromCart(int cartDetailsId);
        Task<ResponceDTOs> ApplyCouponAsync(CartDTO cartDTO);
    }
}
