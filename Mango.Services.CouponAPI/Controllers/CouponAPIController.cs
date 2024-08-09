using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {

        #region CTOR

        private readonly AppDbContext _db;

        public CouponAPIController(AppDbContext db)
        {
            _db = db;
        }


        #endregion


        [HttpGet]
        public object Get()
        #region Get
        {
            try
            {
                IEnumerable<Coupon> couponList = _db.Coupons.ToList();
                return couponList;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        #endregion

        [HttpGet]
        [Route("{id=int}")]
        public object Get(int id)
        #region Get by id
        {
            try
            {
                Coupon Coupon = _db.Coupons.FirstOrDefault(a => a.CouponId == id);
                return Coupon;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        #endregion


    }
}
