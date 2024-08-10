using Mango.Web.Models;
using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseClass;
        public CouponService(IBaseService baseService)
        {
            _baseClass = baseService;
                
        }
        public Task<ResponceDTOs> CreateCouponsAsync(CouponDTOs CouponDTOs)
        {
            throw new NotImplementedException();
        }

        public Task<ResponceDTOs> DeleteCouponByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponceDTOs> GetAllCouponsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponceDTOs> GetCouponAsync(string CouponCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponceDTOs> GetCouponByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponceDTOs> UpdateCouponsAsync(CouponDTOs CouponDTOs)
        {
            throw new NotImplementedException();
        }
    }
}
