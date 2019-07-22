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
        public int id { get; set; }

        [DataMember]
        public String categoryId { get; set; }

        [DataMember]
        public String subCategoryId { get; set; }

        [DataMember]
        public String name { get; set; }

        [DataMember]
        public String imageURL { get; set; }

        [DataMember]
        public int flag { get; set; }


    }

}