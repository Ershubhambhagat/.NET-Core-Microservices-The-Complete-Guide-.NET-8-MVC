using AutoMapper;
using Azure;
using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/Product")]
    [ApiController]
  //  [Authorize]
    public class ProductAPIController : ControllerBase
    {

        #region CTOR

        private readonly AppDbContext _db;
        //private readonly IMapper _mapper;
        private ResponceDTOs _responce;

        public ProductAPIController(AppDbContext db)
        {
            _db = db;
            //_mapper = mapper;
            _responce = new ResponceDTOs();
        }


        #endregion


        [HttpGet]
        #region Get All Product
        public ResponceDTOs Get()


        {
            try
            {
                IEnumerable<Product> objList = _db.Products.ToList();
                //_responce.Result =_mapper.Map<IEnumerable<ProductDTO>>(objList);
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

        #region Get Product by id

        [Route("{id=int}")]
        public ResponceDTOs Get(int id)
        {
            try
            {
                Product obj = _db.Products.First(a => a.ProductId == id);
                //_responce.Result =_mapper.Map<ProductDTO>(obj);

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

        #region Create Product
        [HttpPost]
      //  [Authorize(Roles ="ADMIN")]
        public ResponceDTOs CreateProduct([FromBody] ProductDTO Product)
        {
            try
            {
                //Convert to DTO
                var Product2 = new Product
                {
                    Name = Product.Name,
                    Price = Product.Price,
                    Description = Product.Description,
                    CategoryName = Product.CategoryName,
                    ImageUrl = Product.ImageUrl,
                    ImageLocalPath = Product.ImageLocalPath,
                    //ProductId = Product.ProductId,
                    

            };

                _db.Products.Add(Product2);
                 _db.SaveChanges();

                _responce.IsSuccess=true;
                _responce.Result = Product;
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

        #region Update Product
        [HttpPut]
        //[Authorize(Roles = "ADMIN")]
        public ResponceDTOs UpdateProduct([FromBody] ProductDTO Product)
        {
            try
            {
                //Convert to DTO
                var Product2 = new Product
                {
                    Name = Product.Name,
                    Price = Product.Price,
                    Description = Product.Description,
                    CategoryName = Product.CategoryName,
                    ImageUrl= Product.ImageUrl,
                    ImageLocalPath=Product.ImageLocalPath,

                };

                _db.Products.Update(Product2);
                _db.SaveChanges();

                _responce.IsSuccess = true;
                _responce.Result = Product;
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

        #region Get Product by id
        [HttpDelete]
        [Route("{id=int}")]
       // [Authorize(Roles = "ADMIN")]

        public ResponceDTOs DeleteProduct(int id)
        {
            try
            {
                Product obj = _db.Products.First(a => a.ProductId == id);
                if (obj == null)
                {

                    _responce.IsSuccess = false;
                    _responce.Message = $"{id}  is not available i database";

                }
                _db.Products.Remove(obj);
                _db.SaveChanges();

                //_responce.Result =_mapper.Map<ProductDTO>(obj);

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
