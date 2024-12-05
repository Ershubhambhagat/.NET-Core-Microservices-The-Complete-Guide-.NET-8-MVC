﻿using AutoMapper;
using Mango.Services.ShoppingCartAPI.Data;
using Mango.Services.ShoppingCartAPI.Models;
using Mango.Services.ShoppingCartAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace Mango.Services.ShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartAPIController : ControllerBase
    {
        #region CTOR
        private readonly AppDbContext _db;
        private ResponceDTOs _response;
        private readonly IMapper _mapper; // Adding here but this is not working 

        public ShoppingCartAPIController(AppDbContext db, IMapper mapper)//IMapper mapper
        {
            _db = db;
            this._response = new ResponceDTOs();
            _mapper = mapper;

        }

        #endregion


        [HttpPost("CartUpsert")]

        #region CartUpsert
        public async Task<ResponceDTOs> CartUpsert(CartDTO cartDTO)
        {
            try
            {
                //Retrive if any data is their or not 
                var cartHeaderFromDB = await _db.CartHeaders.AsNoTracking()
                    .FirstOrDefaultAsync(u => u.UserId == cartDTO.CartHeader.UserId);
                if (cartHeaderFromDB == null)
                {
                    //Create CartHeader and details

                    #region Mapping cartHeaderDTOs
                    CartHeader cartHeader = _mapper.Map<CartHeader>(cartDTO.CartHeader);
                    #endregion

                    _db.CartHeaders.Add(cartHeader);
                    await _db.SaveChangesAsync();

                    cartDTO.CartDetails.First().CartHeaderId = cartHeader.CartHeaerId;

                    #region CartDetails Mapping 
                    _db.CardDetails.Add(_mapper.Map<CardDetails>(cartDTO.CartDetails.First()));
                    #endregion

                    await _db.SaveChangesAsync();

                }
                else
                {
                    //if Header is not null
                    // Check if detaiils has same product
                    var cartDetailsFromDB = await _db.CardDetails.AsNoTracking().FirstOrDefaultAsync
                        (u => u.ProductId == cartDTO.CartDetails.First().ProductId &&
                    u.CartHeaderId == cartHeaderFromDB.CartHeaerId);

                    if (cartDetailsFromDB == null)
                    {
                        //Create CartDetails
                        cartDTO.CartDetails.First().CartHeaderId = cartHeaderFromDB.CartHeaerId;

                        #region CartDetails Mapping 
                        _db.CardDetails.Add(_mapper.Map<CardDetails>(cartDTO.CartDetails.First()));
                        #endregion
                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        // Update Count in Cart Details
                        cartDTO.CartDetails.First().Count += cartDetailsFromDB.Count;
                        cartDTO.CartDetails.First().CartHeaderId = cartDetailsFromDB.CartHeaderId;
                        cartDTO.CartDetails.First().CartDetailsId = cartDetailsFromDB.CartDetailsId;
                        #region CartDetails Mapping 

                        _db.CardDetails.Update(_mapper.Map<CardDetails>(cartDTO.CartDetails.First()));
                        #endregion

                        await _db.SaveChangesAsync();


                    }
                    _response.Result = cartDTO;
                }
            }
            catch (Exception ex)
            {

                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return _response;
        }
        #endregion


        [HttpPost("RemoveCart")]

        #region RemoveCart
        public async Task<ResponceDTOs> RemoveCart([FromBody] int CartDeatisId)
        {
            try
            {
                //Retrive CartDetails Form Database 
                CardDetails cardDetails = _db.CardDetails.First(u => u.CartDetailsId == CartDeatisId);

                //Check Total CartItem if only one is there then remove header as well 
                int totalCountOfCartItem = _db.CardDetails.Where(v => v.CartHeaderId == cardDetails.CartHeaderId).Count();
                // remove cart Details Before Cart Header
                _db.CardDetails.Remove(cardDetails);

                //if 1 item is left then this is the last item in cart so removing header as well 
                if (totalCountOfCartItem == 1)
                {
                    var cartHeaderToRemove = await _db.CartHeaders.FirstOrDefaultAsync
                        (c => c.CartHeaerId == cardDetails.CartHeaderId);
                    _db.CartHeaders.Remove(cartHeaderToRemove);

                }
                await _db.SaveChangesAsync();

                _response.Result = true;

            }
            catch (Exception ex)
            {

                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return _response;
        }
        #endregion


     
    }
}
