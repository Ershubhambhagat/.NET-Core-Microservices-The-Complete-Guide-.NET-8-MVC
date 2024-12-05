using Mango.Services.ShoppingCartAPI.Models.DTOs;
using Mango.Services.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;
using System.Collections.Immutable;

namespace Mango.Services.ShoppingCartAPI.Service
{
    public class ProductServices : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        //for Making Call 
        public ProductServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var client= _httpClientFactory.CreateClient("Product");// base of the name its will check Program.cs and fetch Url form there 

            var responce = await client.GetAsync($"/api/product");// here we are passing rought to get 

            var apiContent = await responce.Content.ReadAsStringAsync();// now we are getting api containt 
            var apiResponce = JsonConvert.DeserializeObject<ResponceDTOs>(apiContent);
            if (apiResponce.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(Convert.ToString(apiResponce.Result));
            }
            return new List<ProductDTO>();
        }
    }
}
