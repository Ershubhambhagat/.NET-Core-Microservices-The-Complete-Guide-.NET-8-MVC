using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        #region CTOR
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        #endregion

        #region Disply Coupon
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDTOs>? list = new();

            ResponceDTOs? responce = await _couponService.GetAllCouponsAsync();
            if (responce != null && responce.IsSuccess)
            {

                list = JsonConvert.DeserializeObject<List<CouponDTOs>>(Convert.ToString(responce.Result));

            }
            return View(list);
        } 
        #endregion

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

	}
}
