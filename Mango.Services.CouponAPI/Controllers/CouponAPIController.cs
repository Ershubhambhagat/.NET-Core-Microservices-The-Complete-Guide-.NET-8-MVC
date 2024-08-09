using AutoMapper;
using Azure;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {

        #region CTOR

        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private ResponceDTOs _responce;

        public CouponAPIController(AppDbContext db,IMapper mapper)
        {
            _db = db;
          _mapper = mapper;
            _responce =new ResponceDTOs();
        }


        #endregion


        [HttpGet]
        public ResponceDTOs Get()
        #region Get
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                //_responce.Result =_mapper.Map<IEnumerable<CouponDTOs>>(objList);
                _responce.Result = objList;

            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.Result= ex.Message;
            }
            return _responce;
        }
        #endregion

        [HttpGet]
        [Route("{id=int}")]
        public ResponceDTOs Get(int id)
        #region Get by id
        {
            try
            {
                Coupon obj = _db.Coupons.First(a => a.CouponId == id);
                //_responce.Result =_mapper.Map<CouponDTOs>(obj);

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
