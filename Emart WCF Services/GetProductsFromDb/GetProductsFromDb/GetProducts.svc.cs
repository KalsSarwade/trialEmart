using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GetProductsFromDb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class GetProducts : IGetProducts
    {
        public SqlConnection getconnection()
        {
            SqlConnection sqlconn = new SqlConnection();
            string connstring = ConfigurationManager.ConnectionStrings["prods"].ConnectionString;
            sqlconn.ConnectionString = connstring;
            return sqlconn;
        }

       public List<Products> getProductsList()
        {
            SqlConnection sqlconnection = getconnection();
            sqlconnection.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from Product", sqlconnection);
            //sqlcmd.Parameters.AddWithValue("@subcat", subcat);
            SqlDataReader sqldata = sqlcmd.ExecuteReader();
            List<Products> list = new List<Products>();
            while (sqldata.Read())
            {
                Products p = new Products();
                p.productId = Convert.ToInt32(sqldata["productId"]);
                p.categoryId = Convert.ToInt32(sqldata["categoryId"]);
                p.productName = sqldata["productName"].ToString();
                p.imageURL = sqldata["imageURL"].ToString();
                p.listPrice = Convert.ToInt32(sqldata["listPrice"]);
                p.cardHolderPrice = Convert.ToInt32(sqldata["cardHolderPrice"]);
                p.point = Convert.ToInt32(sqldata["point"]);

                list.Add(p);
            }

            return list;
        }

       public Products getProduct(string productId)
       {
           SqlConnection sqlconnection = getconnection();
           sqlconnection.Open();
           SqlCommand sqlcmd = new SqlCommand("select * from Product where productId =" + productId, sqlconnection);
           SqlDataReader sqldata = sqlcmd.ExecuteReader();
           Products p = new Products();
           while (sqldata.Read())
           {
               p.productId = Convert.ToInt32(sqldata["productId"]);
               p.categoryId = Convert.ToInt32(sqldata["categoryId"]);
               p.productName = sqldata["productName"].ToString();
               p.imageURL = sqldata["imageURL"].ToString();
               p.listPrice = Convert.ToInt32(sqldata["listPrice"]);
               p.cardHolderPrice = Convert.ToInt32(sqldata["cardHolderPrice"]);
               p.point = Convert.ToInt32(sqldata["point"]);
           }
           return p;
       }
       public List<Products> getProductByCategory(string categoryId)
       {
           SqlConnection sqlconnection = getconnection();
           sqlconnection.Open();
           SqlCommand sqlcmd = new SqlCommand("select * from Product where categoryId =@categoryId", sqlconnection);
           sqlcmd.Parameters.AddWithValue("@categoryId", categoryId);
           SqlDataReader sqldata = sqlcmd.ExecuteReader();
           List<Products> list = new List<Products>();
           while (sqldata.Read())
           {
               Products p = new Products();
               p.productId = Convert.ToInt32(sqldata["productId"]);
               p.categoryId = Convert.ToInt32(sqldata["categoryId"]);
               p.productName = sqldata["productName"].ToString();
               p.imageURL = sqldata["imageURL"].ToString();
               p.listPrice = Convert.ToInt32(sqldata["listPrice"]);
               p.cardHolderPrice = Convert.ToInt32(sqldata["cardHolderPrice"]);
               p.point = Convert.ToInt32(sqldata["point"]);

               list.Add(p);
           }

           return list;
       }
       
    }
}
