using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.ServiceModel.Web;
using System.Text;

namespace Login
{
   public class LoginService : ILoginService
    {

       public SqlConnection getconnection()
       {
           SqlConnection sqlconn = new SqlConnection();
           string connstring = ConfigurationManager.ConnectionStrings["emartconnect"].ConnectionString;
           sqlconn.ConnectionString = connstring;
           return sqlconn;
       }


       public List<Customers> checkLogin(Customers custobj)
       {

           SqlConnection sqlconnection = getconnection();
           sqlconnection.Open();
           string query = "select emailId,password,customerId,name from Customers where emailId = @emailId and password = @password";
           SqlCommand sqlcmd = new SqlCommand(query, sqlconnection);

           sqlcmd.Parameters.AddWithValue("@emailId", custobj.emailId);
           sqlcmd.Parameters.AddWithValue("@password", custobj.password);

           List<Customers> list = new List<Customers>();
           SqlDataReader sqldata = sqlcmd.ExecuteReader();
           Customers cobj = new Customers();

           if (sqldata.Read())
           {
               cobj.emailId = sqldata["emailId"].ToString();
               cobj.password = sqldata["password"].ToString();
               cobj.name = sqldata["name"].ToString();
               cobj.customerId = Convert.ToInt32(sqldata["customerId"]);
               list.Add(cobj);

           }
           else
           {
               sqlconnection.Close();
               return null;
           }

           return list;

       }
       
    }
}
