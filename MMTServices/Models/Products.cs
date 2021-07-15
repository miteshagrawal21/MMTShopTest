using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMTServices.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}