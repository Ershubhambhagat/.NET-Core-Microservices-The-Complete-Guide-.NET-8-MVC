using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CartService : ICartService
    {
        #region CTOR

        private readonly IBaseService _baseClass;
        public CartService(IBaseService baseService)
        {
            _baseClass = baseService;

        }
        #endregion

        #region ApplyCouponAsync
        public async Task<ResponceDTOs> ApplyCouponAsync(CartDTO cartDTO)
        {
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Post,
                Data = cartDTO,
                Url = SD.ShoppingCartAPIBase + "/api/ShoppingCart/ApplyCoupon"
            });
        }

        #endregion

        #region GetCartByUserIdAsync
        public async Task<ResponceDTOs> GetCartByUserIdAsync(string UserId)
        {

            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Get,
                Url = SD.CouponAPIBase + "/api/GetCart/" + UserId
            });

        }
        #endregion

        #region RemoveFromCart
        public async Task<ResponceDTOs> RemoveFromCart(int cartDetailsId)
        {
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Post,
                Data = cartDetailsId,
                Url = SD.ShoppingCartAPIBase + "/api/ShoppingCart/RemoveCart" + cartDetailsId
            });
        }

        #endregion

        #region UpsertCartAsync
        public async Task<ResponceDTOs> UpsertCartAsync(CartDTO cartDTO)
        {
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Post,
                Data = cartDTO,
                Url = SD.ShoppingCartAPIBase + "/api/ShoppingCart/CartUpsert"
            });
        } 
        #endregion
    }
}
