using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MMTServices.Models;

namespace MMTServices.DAL
{
    public class DBOperations
    {
        public IEnumerable<Category> GetCategories()
        { 
            List<Category> categories = new List<Category>();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AvailableCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Category category = new Category();
                    category.CategoryName = rdr["CategoryName"].ToString();

                    categories.Add(category);
                }
            }

            return categories;
        }


        public IEnumerable<Products> GetFeaturedProducts()
        {
            List<Products> products = new List<Products>();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("FeaturedProducts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Products product = new Products();
                    product.Id = Convert.ToInt32(rdr["Id"]);
                    product.SKU = rdr["SKU"].ToString();
                    product.Name = rdr["Name"].ToString();
                    product.Description = rdr["Description"].ToString();
                    product.Price = Convert.ToDecimal(rdr["Price"]);
                    products.Add(product);
                }
            }
            return products;
        }

        public IEnumerable<Products> GetProductsByCategory(int id)
        {
            List<Products> products = new List<Products>();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spProductsByCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CategoryId", id));
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Products product = new Products();
                    product.Id = Convert.ToInt32(rdr["Id"]);
                    product.SKU = rdr["SKU"].ToString();
                    product.Name = rdr["Name"].ToString();
                    product.Description = rdr["Description"].ToString();
                    product.Price = Convert.ToDecimal(rdr["Price"]);
                    products.Add(product);
                }
            }
            return products;
        }


    }
}