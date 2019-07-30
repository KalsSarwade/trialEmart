using System;
using System.Collections.Generic;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Invoice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class InvoiceService : IInvoiceService
    {
        public SqlConnection getconnection()
        {
            SqlConnection sqlconn = new SqlConnection();
            string connstring = ConfigurationManager.ConnectionStrings["prods"].ConnectionString;
            sqlconn.ConnectionString = connstring;
            return sqlconn;
        }

        public List<InvoiceDetails> getInvoiceDetails(string invoiceId)
        {
            SqlConnection sqlconnection = getconnection();
            List<InvoiceDetails> list = new List<InvoiceDetails>();
            try
            {
                string str = "select * from Invoice,ProductDescription,ProductParameters,OrderDetails where Invoice.pId = ProductParameters.pId and Invoice.pdId = ProductDescription.pdId and Invoice.orderId = OrderDetails.orderId and Invoice.invoiceId = @invoiceId";
                
                SqlCommand sqlcmd = new SqlCommand(str, sqlconnection);
                sqlcmd.Parameters.AddWithValue("@invoiceId", invoiceId);
                sqlconnection.Open();
                SqlDataReader sqldata = sqlcmd.ExecuteReader();

                while (sqldata.Read())
                {
                    InvoiceDetails inv = new InvoiceDetails();
                    inv.invoiceId = Convert.ToInt32(sqldata["invoiceId"]);
                    inv.orderId = Convert.ToInt32(sqldata["orderId"]);
                    inv.productId = Convert.ToInt32(sqldata["productId"]);
                    inv.productName = sqldata["productName"].ToString();
                    inv.shortDescription = sqldata["shortDescription"].ToString();
                    inv.value = sqldata["value"].ToString();
                    inv.orderId = Convert.ToInt32(sqldata["orderId"]);
                    inv.customerId = Convert.ToInt32(sqldata["customerId"]);
                    inv.customerAddress = sqldata["customerAddress"].ToString();
                    inv.netAmount = Convert.ToInt32(sqldata["netAmount"]);
                    list.Add(inv);
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
