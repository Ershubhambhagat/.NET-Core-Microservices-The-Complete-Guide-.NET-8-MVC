using Mango.Services.ShoppingCartAPI.Models.DTOs;
using Mango.Services.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartAPI.Service
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CouponService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<CouponDTO> GetCoupon(string CouponCode)
        {
            var client = _httpClientFactory.CreateClient("Coupon");// base of the name its will check Program.cs and fetch Url form there 

            var responce = await client.GetAsync($"/api/coupon/GetByCode/{CouponCode}");// here we are passing rought to get 

            var apiContent = await responce.Content.ReadAsStringAsync();// now we are getting api containt 
            var apiResponce = JsonConvert.DeserializeObject<ResponceDTOs>(apiContent);
            if (apiResponce.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDTO> (Convert.ToString(apiResponce.Result));
            }
            return new CouponDTO();
        }
    }
}
