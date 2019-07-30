using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GetProductsFromDb
{
    [DataContract]
    public class Products
    {
        [DataMember]
        public int productId { get; set; }

        [DataMember]
        public int categoryId { get; set; }

        [DataMember]
        public String productName { get; set; }

        [DataMember]
        public String imageURL { get; set; }

        [DataMember]
        public int listPrice { get; set; }

        [DataMember]
        public int point { get; set; }

        [DataMember]
        public int cardHolderPrice { get; set; }

    }
}