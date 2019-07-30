using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Login
{
    [DataContract]
    public class Customers
    {
        [DataMember]
        public string emailId { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public int customerId { get; set; }

        [DataMember]
        public string mobileNumber { get; set; }

        [DataMember]
        public string cardNumber { get; set; }

        [DataMember]
        public int points { get; set; }

        [DataMember]
        public string addressLine1 { get; set; }

        [DataMember]
        public string addressline2 { get; set; }

        [DataMember]
        public string city { get; set; }
        
        [DataMember]
        public int pincode { get; set; }

        [DataMember]
        public string state { get; set; }
    }
}