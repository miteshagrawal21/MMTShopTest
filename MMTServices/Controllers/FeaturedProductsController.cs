using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MMTServices.DAL;
using MMTServices.Models;

namespace MMTServices.Controllers
{
    public class FeaturedProductsController : ApiController
    {
        public IEnumerable<Products> Get()
        {
            DBOperations dBOperations = new DBOperations();
            List<Products> products = new List<Products>();
            products = dBOperations.GetFeaturedProducts().ToList();
            return products;
        }

    }
}
