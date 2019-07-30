using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GetProductParametersService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class GetProductParamsService : IGetProductParamsService
    {
        public SqlConnection getconnection()
        {
            SqlConnection sqlconn = new SqlConnection();
            string connstring = ConfigurationManager.ConnectionStrings["prods"].ConnectionString;
            sqlconn.ConnectionString = connstring;
            return sqlconn;
        }


        public List<ProductParameters> getProductParameters(string productId)
        {
            SqlConnection sqlconnection = getconnection();
            List<ProductParameters> list = new List<ProductParameters>();
            try
            {
                string str = "select * from Product,ParametersMaster,ProductParameters where product.productId=ProductParameters.productId and ParametersMaster.parameterId=ProductParameters.parameterId and Product.productId=@productId";
                SqlCommand sqlcmd = new SqlCommand(str, sqlconnection);
                sqlcmd.Parameters.AddWithValue("@productId", productId);
                sqlconnection.Open();
                SqlDataReader sqldata = sqlcmd.ExecuteReader();


                while (sqldata.Read())
                {
                    ProductParameters pp = new ProductParameters();
                    pp.productId = Convert.ToInt32(sqldata["productId"]);
                    pp.parameterId = Convert.ToInt32(sqldata["parameterId"]);
                    pp.parameterName = sqldata["parameterName"].ToString();
                    pp.value = sqldata["value"].ToString();
                    list.Add(pp);
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