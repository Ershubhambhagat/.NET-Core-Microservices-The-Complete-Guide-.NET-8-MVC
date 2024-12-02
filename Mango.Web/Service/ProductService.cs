using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class ProductService : IProductService
    {
        #region CTOR

        private readonly IBaseService _baseClass;
        public ProductService(IBaseService baseService)
        {
            _baseClass = baseService;

        }
        #endregion

        #region Product Service Implemantion
        public async Task<ResponceDTOs> CreateProductsAsync(ProductDTOs ProductDTOs)
        {
            #region Create
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Post,
                Data = ProductDTOs,
                Url = SD.ProductAPIBase + "/api/Product"
            });
            #endregion
        }

        public async Task<ResponceDTOs> DeleteProductByIdAsync(int Id)
        {
            #region Delete
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Delete,
                Url = SD.ProductAPIBase + "/api/Product/" + Id
            });
            #endregion
        }

        public async Task<ResponceDTOs> GetAllProductsAsync()
        {
            #region Get All
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Get,
                Url = SD.ProductAPIBase + "/api/Product"
            });
            #endregion
        }

        public async Task<ResponceDTOs> GetProductAsync(string ProductCode)
        {
            #region Get By Product Code 
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Get,
                Url = SD.ProductAPIBase + "/api/Product/GetByCode/" + ProductCode
            });
            #endregion
        }

        public async Task<ResponceDTOs> GetProductByIdAsync(int Id)
        {
            #region Get By Id
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Get,
                Url = SD.ProductAPIBase + "/api/Product/" + Id
            });
            #endregion
        }


        public async Task<ResponceDTOs> UpdateProductsAsync(ProductDTOs ProductDTOs)
        {
            #region Update
            return await _baseClass.SendAsync(new RequestDTOs()
            {
                ApiType = SD.ApiType.Put,
                Url = SD.ProductAPIBase + "/api/Product/GetByCode"
            });
            #endregion
        } 
        #endregion
    }
}
