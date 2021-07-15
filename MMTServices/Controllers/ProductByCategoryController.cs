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
    public class ProductByCategoryController : ApiController
    {
        public HttpResponseMessage Get(int id)
        {
            DBOperations dBOperations = new DBOperations();
            List<Products> products = new List<Products>();
            products = dBOperations.GetProductsByCategory(id).ToList();
            var entites = products;
            if (entites != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entites);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Records Not Found...");
            }
        }


    }
}
