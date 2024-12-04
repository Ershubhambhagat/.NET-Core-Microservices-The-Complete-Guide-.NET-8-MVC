﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.ShoppingCartAPI.Models.DTOs
{
    public class CartHeaderDTO
    {
        public int CartHeaerId { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }
        public string? Discount { get; set; }
        public int CartTotal { get; set; }
    }
}