using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgricultureMvc1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public string productImage { get; set; }
        public string productWeight { get; set; }
        public string productUnit { get; set; }
        public string productQuantity { get; set; }
        public string productPrice { get; set; }
        public int categoryId { get; set; }
        public string ProductCategory { get; set; }
        public string createdOn { get; set; }
        public string modifiedOn { get; set; }
    }
}