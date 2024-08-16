using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
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
            else
            {
                TempData["error"] = responce?.Message;
            }
            return View(list);
        }
        #endregion

        #region Create Coupon

        #region This is only for page Create Coupon Page Open
        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDTOs model)
        {
            //Server side validation 
            if (ModelState.IsValid)
            {
                ResponceDTOs responce = await _couponService.CreateCouponsAsync(model);
                if (responce != null && responce.IsSuccess)
                {
                    TempData["success"] = $"{model.CouponCode} Created Successfully ✔️"; 

                    return RedirectToAction(nameof(CouponIndex));

                }
                else
                {
                    TempData["error"] = responce?.Message;
                }
            }

            return View(model);
        }
        #endregion

        #region Delete Coupon

        #region This is only for page Open Delete Coupon Page Open
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponceDTOs? responce = await _couponService.GetCouponByIdAsync(couponId);
            if (responce != null && responce.IsSuccess)
            {
                CouponDTOs model = JsonConvert.DeserializeObject<CouponDTOs>(Convert.ToString(responce.Result));
                return View(model);

            }
            return NotFound();
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDTOs coupon)
        {
            ResponceDTOs? responce = await _couponService.DeleteCouponByIdAsync(coupon.CouponId);
            if (responce != null && responce.IsSuccess)
            {
                TempData["success"] = $"{coupon.CouponCode}  Delete Successfully";

                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = responce?.Message;

            }
            return View(coupon);
        }

        #endregion
    }
}
