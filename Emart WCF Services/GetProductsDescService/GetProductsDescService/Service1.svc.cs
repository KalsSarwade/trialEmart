using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GetProductsDescService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class GetProductDescriptionService : IGetProductDescriptionService
    {
        public SqlConnection getconnection()
        {
            SqlConnection sqlconn = new SqlConnection();
            string connstring = ConfigurationManager.ConnectionStrings["prods"].ConnectionString;
            sqlconn.ConnectionString = connstring;
            return sqlconn;
        }

        public ProductDescription getProductDescription(string productId)
        {
            SqlConnection sqlconnection = getconnection();
            sqlconnection.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from ProductDescription where productId = "+productId, sqlconnection);
            SqlDataReader sqldata = sqlcmd.ExecuteReader();
            ProductDescription pd = new ProductDescription();
            while (sqldata.Read())
            {
                pd.pdId = Convert.ToInt32(sqldata["pdId"]);
                pd.productId = Convert.ToInt32(sqldata["productId"]);
                pd.longDescription = sqldata["longDescription"].ToString();
                pd.shortDescription = sqldata["shortDescription"].ToString();
            }

            return pd;
        }
    }
}
