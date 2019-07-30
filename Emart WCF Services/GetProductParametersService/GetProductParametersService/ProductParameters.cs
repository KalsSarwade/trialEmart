using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GetProductParametersService
{
    [DataContract]
    public class ProductParameters
    {
        [DataMember]
        public int productId { get; set; }

        [DataMember]
        public int parameterId { get; set; }

        [DataMember]
        public string value { get; set; }

        [DataMember]
        public string parameterName { get; set; }
    }
}