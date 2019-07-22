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
            string connstring = ConfigurationManager.ConnectionStrings["democonnect"].ConnectionString;
            sqlconn.ConnectionString = connstring;
            return sqlconn;


        }
        public List<String> getCategories()
        {
            SqlConnection sqlconnection = getconnection();
            sqlconnection.Open();
            SqlCommand sqlcmd = new SqlCommand("select categoryId from Category where subCategoryId is null", sqlconnection);
            SqlDataReader sqldata = sqlcmd.ExecuteReader();
            List<String> list = new List<String>();
            while (sqldata.Read())
            {
                //Category c = new Category();
                //c.id = Convert.ToInt32(sqldata["id"]);
                String c =sqldata["categoryId"].ToString();
                //c.subCategoryId = sqldata["subCategoryId"].ToString();
                list.Add(c);
            }

            return list;
        }


    }
}
