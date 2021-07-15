using MMTServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using MMTServices.DAL;

namespace MMTServices.Controllers
{
    public class CategoryController : ApiController
    {
        //public IEnumerable<Category> Get()
        //{
        //    DBOperations dBOperations = new DBOperations();
        //    List<Category> categories = new List<Category>();
        //    categories = dBOperations.GetCategories().ToList();
        //    return categories;
        //}

        public HttpResponseMessage Get()
        {
            DBOperations dBOperations = new DBOperations();
            List<Category> categories = new List<Category>();
            categories = dBOperations.GetCategories().ToList();
            var entites= categories;
            if(entites != null)
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
