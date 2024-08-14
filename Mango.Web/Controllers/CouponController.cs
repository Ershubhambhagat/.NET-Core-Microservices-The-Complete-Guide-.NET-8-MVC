using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDTOs>? list = new ();

            ResponceDTOs? responce = await _couponService.GetAllCouponsAsync();
            if (responce != null && responce.IsSuccess)
            {

                list = JsonConvert.DeserializeObject<List<CouponDTOs>>(Convert.ToString(responce.Result));

            }
            return View(list);
        }
    }
}
