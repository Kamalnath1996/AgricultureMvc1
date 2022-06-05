using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgricultureMvc1.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public int productWeight { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public string productUnit { get; set; }
        public string productimage { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}