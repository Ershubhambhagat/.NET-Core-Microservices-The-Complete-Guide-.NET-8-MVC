using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponceDTOs> GetCouponAsync(string CouponCode);
        Task<ResponceDTOs> GetAllCouponsAsync();
        Task<ResponceDTOs> GetCouponByIdAsync(int Id);
        Task<ResponceDTOs> CreateCouponsAsync(CouponDTOs CouponDTOs);
        Task<ResponceDTOs> UpdateCouponsAsync(CouponDTOs CouponDTOs);
        Task<ResponceDTOs> DeleteCouponByIdAsync(int Id);
    }
}
