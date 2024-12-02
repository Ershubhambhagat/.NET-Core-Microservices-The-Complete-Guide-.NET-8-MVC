using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        #region CTOR
        private readonly IProductService _ProductService;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        #endregion

        #region Disply Product
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDTOs>? list = new();
            ResponceDTOs? responce = await _ProductService.GetAllProductsAsync();
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

        #region Create Product

        #region This is only for page Create Product Page Open
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDTOs model)
        {
            //Server side validation 
            if (ModelState.IsValid)
            {
                ResponceDTOs responce = await _ProductService.CreateProductsAsync(model);
                if (responce != null && responce.IsSuccess)
                {
                    TempData["success"] = $"{model.ProductId} Created Successfully ✔️"; 

                    return RedirectToAction(nameof(ProductIndex));

                }
                else
                {
                    TempData["error"] = responce?.Message;
                }
            }

            return View(model);
        }
        #endregion

        #region Delete Product

        #region This is only for page Open Delete Product Page Open
        public async Task<IActionResult> ProductDelete(int ProductId)
        {
            ResponceDTOs? responce = await _ProductService.GetProductByIdAsync(ProductId);
            if (responce != null && responce.IsSuccess)
            {
                ProductDTOs model = JsonConvert.DeserializeObject<ProductDTOs>(Convert.ToString(responce.Result));
                return View(model);

            }
            return NotFound();
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDTOs Product)
        {
            ResponceDTOs? responce = await _ProductService.DeleteProductByIdAsync(Product.ProductId);
            if (responce != null && responce.IsSuccess)
            {
                TempData["success"] = $"{Product.Name}  Delete Successfully";

                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = responce?.Message;

            }
            return View(Product);
        }

        #endregion
    }
}
