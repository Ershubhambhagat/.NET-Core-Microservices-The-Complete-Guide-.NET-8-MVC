using Microsoft.AspNetCore.SignalR;

namespace Mango.Web.Utility
{
    public class SD
    {
        //Its populate in Programe.cs file
        public static string CouponAPIBase { get; set; }
        public enum ApiType
        {
            Get, Post, Put, Delete
        }
    }
}
