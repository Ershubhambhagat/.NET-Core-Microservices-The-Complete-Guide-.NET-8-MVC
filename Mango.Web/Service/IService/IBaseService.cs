using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponceDTOs?> SendAsync(RequestDTOs requestDTOs);
    }
}
