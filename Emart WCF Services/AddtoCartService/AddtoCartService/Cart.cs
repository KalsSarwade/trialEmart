using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace AddtoCartInDb
{
    [DataContract]
    public class Cart
    {
        [DataMember]
        public int productId { get; set; }

        [DataMember]
        public string productName { get; set; }

        [DataMember]
        public int listPrice { get; set; }

        [DataMember]
        public int cardHolderPrice { get; set; }

        [DataMember]
        public int point { get; set; }

        [DataMember]
        public int quantity { get; set; }

        [DataMember]
        public int customerId { get; set; }

        [DataMember]
        public string imageURL { get; set; }



    }
}