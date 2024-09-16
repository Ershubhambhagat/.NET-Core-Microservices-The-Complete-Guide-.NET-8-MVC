using AutoMapper;
using Azure;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    [Authorize]
    public class CouponAPIController : ControllerBase
    {

        #region CTOR

        private readonly AppDbContext _db;
        //private readonly IMapper _mapper;
        private ResponceDTOs _responce;

        public CouponAPIController(AppDbContext db)
        {
            _db = db;
            //_mapper = mapper;
            _responce = new ResponceDTOs();
        }


        #endregion


        [HttpGet]
        #region Get All Coupon
        public ResponceDTOs Get()


        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                //_responce.Result =_mapper.Map<IEnumerable<CouponDTOs>>(objList);
                _responce.Result = objList;

            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.Result = ex.Message;
            }
            return _responce;
        }
        #endregion

        [HttpGet]

        #region Get Coupon by id

        [Route("{id=int}")]
        public ResponceDTOs Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(a => a.CouponId == id);
                //_responce.Result =_mapper.Map<CouponDTOs>(obj);

                _responce.Result = obj;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.Result = ex.Message;
            }
            return _responce;

        }
        #endregion

        [HttpGet]

        #region Get Coupon by Code

        [Route("GetByCode/{Code}")]
        public ResponceDTOs Get(string Code)
        {
            try
            {
                Coupon obj = _db.Coupons.FirstOrDefault(a => a.CouponCode.ToLower() == Code.ToLower());
                if (obj is null)
                {
                    _responce.IsSuccess = false;
                    _responce.Message = $"CouponCode > {Code.ToUpper()}  not found";
                }
                //_responce.Result =_mapper.Map<CouponDTOs>(obj);

                _responce.Result = obj;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.Result = ex.Message;
            }
            return _responce;

        }
        #endregion

        #region Create Coupon
        [HttpPost]
        [Authorize(Roles ="ADMIN")]
        public ResponceDTOs CreateCoupon([FromBody] CouponDTOs coupon)
        {
            try
            {
                //Convert to DTO
                var Coupon = new Coupon
                {
                    CouponCode = coupon.CouponCode,
                    //CouponId = coupon.CouponId,
                    DiscountAmount = coupon.DiscountAmount,
                    MinAmount = coupon.MinAmount,

                };

                _db.Coupons.Add(Coupon);
                 _db.SaveChanges();

                _responce.IsSuccess=true;
                _responce.Result = coupon;
                _responce.Message = "Save Sucessfully";
                return _responce;


            }
            catch (Exception)
            {
                _responce.Message = "Something went wronge ";
                _responce.IsSuccess = false;
                return _responce;
            }
        }

        #endregion

        #region Update Coupon
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponceDTOs UpdateCoupon([FromBody] CouponDTOs coupon)
        {
            try
            {
                //Convert to DTO
                var Coupon = new Coupon
                {
                    CouponCode = coupon.CouponCode,
                    CouponId = coupon.CouponId,
                    DiscountAmount = coupon.DiscountAmount,
                    MinAmount = coupon.MinAmount,

                };

                _db.Coupons.Update(Coupon);
                _db.SaveChanges();

                _responce.IsSuccess = true;
                _responce.Result = coupon;
                _responce.Message = "Save Sucessfully";
                return _responce;


            }
            catch (Exception)
            {
                _responce.Message = "Something went wronge ";
                _responce.IsSuccess = false;
                return _responce;
            }
        }

        #endregion

        #region Get Coupon by id
        [HttpDelete]
        [Route("{id=int}")]
        [Authorize(Roles = "ADMIN")]

        public ResponceDTOs DeleteCoupon(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(a => a.CouponId == id);
                if (obj == null)
                {

                    _responce.IsSuccess = false;
                    _responce.Message = $"{id}  is not available i database";

                }
                _db.Coupons.Remove(obj);
                _db.SaveChanges();

                //_responce.Result =_mapper.Map<CouponDTOs>(obj);

                _responce.Result = obj;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.Result = ex.Message;
            }
            return _responce;

        }
        #endregion


    }
}
