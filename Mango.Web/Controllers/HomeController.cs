using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Mango.Web.Controllers
{
    public class HomeController : Controller
    {
        #region CTOR
        private readonly IProductService _ProductService;
        public HomeController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        #endregion

        #region IndexAsync
        public async Task<IActionResult> IndexAsync()
        {

            List<ProductDTOs>? list = new();
            ResponceDTOs? responce=await _ProductService.GetAllProductsAsync();
            if (responce != null && responce.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDTOs>>(Convert.ToString(responce.Result));
            }
            else
            {
                TempData["error"] = responce?.Message;
            }
            return View(list);
        }
        #endregion

        #region Details
        [Authorize]
        public async Task<IActionResult> ProductDetails(int productId)
        {

            ProductDTOs? model=new();
            ResponceDTOs? responce = await _ProductService.GetProductByIdAsync(productId);
            if (responce != null && responce.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<ProductDTOs>(Convert.ToString(responce.Result));
            }
            else
            {
                TempData["error"] = responce?.Message;
            }
            return View(model);
        }
        #endregion

        #region Privacy
        public IActionResult Privacy()
        {
            return View();
        }
        #endregion

        #region Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 
        #endregion
    }
}
