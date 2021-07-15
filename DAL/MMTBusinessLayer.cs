using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MMTBusinessLayer
    {
        public IEnumerable<Categories> Categories
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Categories> categories = new List<Categories>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AvailableCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Categories objcat = new Categories();
                        objcat.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                        objcat.Category = rdr["Category"].ToString();
                        objcat.SKU = rdr["SKU"].ToString();
                        categories.Add(objcat);
                    }
                    return categories;
                }

            }

        }
    }
}