using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class DBOperations
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Category> categories = new List<Category>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AvailableCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Category objcat = new Category();
                        objcat.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                        objcat.CategoryName = rdr["CategoryName"].ToString();
                        objcat.SKU = rdr["SKU"].ToString();
                        categories.Add(objcat);
                    }
                    return categories;
                }
            }
        }

    }
}
