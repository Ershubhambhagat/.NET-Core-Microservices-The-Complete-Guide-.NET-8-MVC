using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        #region CTOR

        private readonly IBaseService _baseClass;
        public CouponService(IBaseService baseService)
        {
            _baseClass = baseService;

        }
        #endregion

        #region Coupon Service Implemantion
        public async Task<ResponceDTOs> CreateCouponsAsync(CouponDTOs CouponDTOs)
        {
            #region Create
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Post,
                Data = CouponDTOs,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
            #endregion
        }

        public async Task<ResponceDTOs> DeleteCouponByIdAsync(int Id)
        {
            #region Delete
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Delete,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + Id
            });
            #endregion
        }

        public async Task<ResponceDTOs> GetAllCouponsAsync()
        {
            #region Get All
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Get,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
            #endregion
        }

        public async Task<ResponceDTOs> GetCouponAsync(string CouponCode)
        {
            #region Get By Coupon Code 
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Get,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + CouponCode
            });
            #endregion
        }

        public async Task<ResponceDTOs> GetCouponByIdAsync(int Id)
        {
            #region Get By Id
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Get,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + Id
            });
            #endregion
        }


        public async Task<ResponceDTOs> UpdateCouponsAsync(CouponDTOs CouponDTOs)
        {
            #region Update
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Put,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode"
            });
            #endregion
        } 
        #endregion
    }
}
