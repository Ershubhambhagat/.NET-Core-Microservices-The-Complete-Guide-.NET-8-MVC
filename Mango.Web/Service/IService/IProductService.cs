using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponceDTOs> GetProductAsync(string ProductCode);
        Task<ResponceDTOs> GetAllProductsAsync();
        Task<ResponceDTOs> GetProductByIdAsync(int Id);
        Task<ResponceDTOs> CreateProductsAsync(ProductDTOs ProductDTOs);
        Task<ResponceDTOs> UpdateProductsAsync(ProductDTOs ProductDTOs);
        Task<ResponceDTOs> DeleteProductByIdAsync(int Id);
    }
}
