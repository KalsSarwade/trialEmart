using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Invoice
{
    [DataContract]
    public class InvoiceDetails
    {
        [DataMember]
        public int invoiceId;

        [DataMember]
        public int orderId;

        [DataMember]
        public int productId;

        [DataMember]
        public string productName;

        [DataMember]
        public string shortDescription;

        [DataMember]
        public string value;

        [DataMember]
        public string orderDate;

        [DataMember]
        public int customerId;

        [DataMember]
        public string customerAddress;

        [DataMember]
        public int netAmount;
    }
}