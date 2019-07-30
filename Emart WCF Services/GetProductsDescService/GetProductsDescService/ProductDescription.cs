using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GetProductsDescService
{
    [DataContract]
    public class ProductDescription
    {
        [DataMember]
        public int pdId { get; set; }

        [DataMember]
        public int productId { get; set; }
        
        [DataMember]
        public string longDescription { get; set; }

        [DataMember]
        public string shortDescription { get; set; }

    }
}