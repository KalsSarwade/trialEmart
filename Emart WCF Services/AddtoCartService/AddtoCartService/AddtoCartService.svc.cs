using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AddtoCartInDb
{
    public class AddtoCartService : IAddtoCartService
    {
        public SqlConnection getconnection()
        {
            SqlConnection sqlconn = new SqlConnection();
            string connstring = ConfigurationManager.ConnectionStrings["emartconnect"].ConnectionString;
            sqlconn.ConnectionString = connstring;
            return sqlconn;
        }

        public void addtoCart(Cart cobj)
        {
            SqlConnection sqlconnection = getconnection();
            string query = "insert into Cart (productId, productName, listPrice, cardHolderPrice,point, quantity, customerId, imageURL)"
            + "values(@productId, @productName, @listPrice, @cardHolderPrice,@point, @quantity, @customerId, @imageURL)";

            try
            {
                sqlconnection.Open();
                SqlCommand sqlcmd = new SqlCommand(query, sqlconnection);
                sqlcmd.Parameters.AddWithValue("@productId", cobj.productId);
                sqlcmd.Parameters.AddWithValue("@productName", cobj.productName);
                sqlcmd.Parameters.AddWithValue("@listPrice", cobj.listPrice);
                sqlcmd.Parameters.AddWithValue("@cardHolderPrice", cobj.cardHolderPrice);
                sqlcmd.Parameters.AddWithValue("@point", cobj.point);
                sqlcmd.Parameters.AddWithValue("@quantity", cobj.quantity);
                sqlcmd.Parameters.AddWithValue("@customerId", cobj.customerId);
                sqlcmd.Parameters.AddWithValue("@imageURL", cobj.imageURL);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                sqlconnection.Close();
            }

        }

        public List<Cart> getCart()
        {
            SqlConnection sqlconnection = getconnection();
            sqlconnection.Open();
            string query = "select * from Cart";
            SqlCommand sqlcmd = new SqlCommand(query, sqlconnection);
            SqlDataReader sqldata = sqlcmd.ExecuteReader();
            List<Cart> list = new List<Cart>();
            
            while (sqldata.Read())
            {
                Cart cobj = new Cart();
                cobj.productName = sqldata["productName"].ToString();
                cobj.productId = Convert.ToInt32(sqldata["productId"]);
                cobj.listPrice = Convert.ToInt32(sqldata["listPrice"]);
                cobj.cardHolderPrice = Convert.ToInt32(sqldata["cardHolderPrice"]);
                cobj.point = Convert.ToInt32(sqldata["point"]);
                cobj.quantity = Convert.ToInt32(sqldata["quantity"]);
                cobj.customerId = Convert.ToInt32(sqldata["customerId"]);
                cobj.imageURL = sqldata["imageURL"].ToString();
                list.Add(cobj);
            }


            return list;

        }
    }
}
