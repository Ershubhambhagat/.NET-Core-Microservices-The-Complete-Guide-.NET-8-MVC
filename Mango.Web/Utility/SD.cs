﻿using Microsoft.AspNetCore.SignalR;

namespace Mango.Web.Utility
{
    public class SD
    {
        //Its populate in Programe.cs file
        public static string CouponAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }
        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public enum ApiType
        {
            Get, Post, Put, Delete
        }
    }
}
