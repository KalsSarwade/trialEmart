using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Trial_Emart
{

    [DataContract]
    public class Category
    {
        [DataMember]
        public int categoryId { get; set; }

        [DataMember]
        public String category{ get; set; }

        [DataMember]
        public String subCategory { get; set; }

        [DataMember]
        public String imageURL { get; set; }

        [DataMember]
        public int flag { get; set; }


    }

}