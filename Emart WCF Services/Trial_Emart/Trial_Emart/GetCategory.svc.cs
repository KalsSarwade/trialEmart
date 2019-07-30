using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Trial_Emart
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class GetCategory : IGetCategory
    {
        public SqlConnection getconnection()
        {
            SqlConnection sqlconn = new SqlConnection();
            string connstring = ConfigurationManager.ConnectionStrings["emartconnect"].ConnectionString;
            sqlconn.ConnectionString = connstring;
            return sqlconn;
        }

        public List<Category> getCategories()
        {
            SqlConnection sqlconnection = getconnection();
            sqlconnection.Open();
            SqlCommand sqlcmd = new SqlCommand("select category,imageURL from Category where subCategory is null", sqlconnection);
            SqlDataReader sqldata = sqlcmd.ExecuteReader();
            List<Category> list = new List<Category>();
            while (sqldata.Read())
            {
                Category c = new Category();
                //c.id = Convert.ToInt32(sqldata["id"]);
                 c.category =sqldata["category"].ToString();
                 c.imageURL = sqldata["imageURL"].ToString();
                //c.subCategoryId = sqldata["subCategoryId"].ToString();
                list.Add(c);
            }

            return list;
        }

        //Method to get Subcategories
        public List<Category> getSubCategories(string category)
        {
            List<Category> list = new List<Category>();
            try
            {
                SqlConnection sqlconnection = getconnection();
                sqlconnection.Open();
                SqlCommand sqlcmd = new SqlCommand("select subCategory,imageURL from Category where category = '"+category+"' and subCategory is NOT null", sqlconnection);
                SqlDataReader sqldata = sqlcmd.ExecuteReader();
                
                while (sqldata.Read())
                {
                    Category c = new Category();
                    c.subCategory = sqldata["subCategory"].ToString();
                    c.imageURL = sqldata["imageURL"].ToString();
                    list.Add(c);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return list;

        }


        public List<Category> getProduct(string subcat)
        {
            List<Category> list = new List<Category>();
            try
            {
                SqlConnection sqlconnection = getconnection();
                sqlconnection.Open();
                SqlCommand sqlcmd = new SqlCommand("select categoryId,subCategory,imageURL,flag from Category where flag = 1 and category =@category", sqlconnection);
                sqlcmd.Parameters.AddWithValue("@category", subcat);
                SqlDataReader sqldata = sqlcmd.ExecuteReader();

                while (sqldata.Read())
                {
                    Category c = new Category();
                    c.categoryId = Convert.ToInt32(sqldata["categoryId"].ToString());
                    c.subCategory = sqldata["subCategory"].ToString();
                    c.imageURL = sqldata["imageURL"].ToString();
                    c.flag = Convert.ToInt32(sqldata["flag"].ToString());
                    list.Add(c);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return list;

        }


    }
}
